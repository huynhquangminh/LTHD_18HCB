import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, timeoutWith } from 'rxjs/operators';
import { HandleErrorService } from './handle-error.service';
import { HttpStatusCode } from '../globlas/enums';

@Injectable({
  providedIn: 'root'
})
export class AuthService extends HandleErrorService {
  protected urlApi = '';
  protected headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  protected options: any = { headers: this.headers, observe: 'response' };
  protected env = '';
  authHttp: HttpClient;
  public httpPost(methodName, args, isFormData?: boolean): Observable<any> {
    let newOptions: any;
    let headers: HttpHeaders;
    let formData = '';
    let body;
    if (isFormData) {
      Object.keys(args).forEach((key, index) => {
        const arg = `${key}=${args[key]}`;
        formData = index === 0 ? arg : `${formData}&${arg}`;
      });
      body = formData;
      headers = new HttpHeaders({ 'Content-Type': 'application/x-www-form-urlencoded; charset=UTF-8' });
      newOptions = { headers: headers, observe: 'response' };

    } else {
      newOptions = this.options;
      body = JSON.stringify(args);
    }
    return this.authHttp.post(this.urlApi + methodName, body, newOptions)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError(this.handleError)
      );
  }

  login(model: any): Observable<any> {
    // Data request
    const request = {
      mailAddress: model.loginId,
      password: model.password
    };
    // Call POST API to login user
    return this.httpPost('login', request).pipe(
      map((result: any) => {
        try {

          // save result login to session
          // return this.userInfo;
        } catch (error) {
          console.log(error);
        }
      }),
    );
  }

  logout() {
    // this.webstorageService.sessionClear();
    // this.webstorageService.localClear();
    window.location.href = '/';
  }
}
