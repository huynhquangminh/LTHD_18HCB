import { Router } from '@angular/router';
import { catchError } from 'rxjs/operators';
import { WebKeyStorage } from './../globlas/web-key-storage';
import { Injectable } from '@angular/core';
import { HttpInterceptor, HttpClient, HttpRequest, HttpHandler } from '@angular/common/http';
import 'rxjs/add/operator/mergeMap';
import { WebStorageSerivce } from './webstorage.service';
import { throwError } from 'rxjs';
import { DialogService } from './dialog-service.service';
@Injectable()
export class AuthInterceptorService implements HttpInterceptor {
  URL = 'https://localhost:44364/api/';
  constructor(
    public http: HttpClient,
    public webStorageSerivce: WebStorageSerivce,
    public router: Router,
    public dialogServiceService: DialogService,
  ) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): any {
    const tokenInfo = this.webStorageSerivce.getSessionStorage(WebKeyStorage.token_info);
    if (tokenInfo) {
      req = req.clone({
        setHeaders: {
          'Content-Type': 'application/json',
          'Authorization': 'Bearer ' + tokenInfo.token
        }
      });
    }
    return next.handle(req).pipe(catchError((error: any) => {
      if (error.status === 401) {
        if (req.url.includes('api/user/login')) {
          this.dialogServiceService.showDialogError('Đăng nhập thất bại, vui lòng đăng nhập lại');
          return throwError(error);
        }
        const params = {
          token: tokenInfo.token,
          refreshToken: tokenInfo.refreshToken
        };
        console.log('401');
        return this.http.put(this.URL + 'User/RefreshToken', JSON.stringify(params) )
          .mergeMap((data: any) => {
            if (data) {
              this.webStorageSerivce.setSessionStorage(WebKeyStorage.token_info, { token: data.token, refreshToke: data.refreshToke });
              req = req.clone({
                setHeaders: {
                  'Content-Type': 'application/json',
                  'Authorization': 'Bearer ' + data.token
                }
              });
              return next.handle(req);
            } else {
              this.router.navigateByUrl('/login');
            }
          });
      }
      return throwError(error);
    }));
  }
}
