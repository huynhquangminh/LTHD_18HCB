import { Observable, throwError } from 'rxjs';
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpResponse, HttpErrorResponse } from '@angular/common/http';
import { map, catchError, timeoutWith } from 'rxjs/operators';
import { HandleErrorService } from './handle-error.service';
import { HttpStatusCode } from '../globlas/enums';
import { DialogService } from './dialog-service.service';
import { Router } from '@angular/router';

@Injectable({
  providedIn: 'root'
})
export class ApiLienKetService extends HandleErrorService {
  protected urlApi = 'http://122.41.175.115:3000/api/';
  protected headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  protected options: any = { headers: this.headers, observe: 'response' };
  protected env = '';
  public isLogin = false;
  constructor(
    dialogServiceService: DialogService,
    router: Router,
    public httpClient: HttpClient) {
    super(dialogServiceService, router);
  }
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
    return this.httpClient.post(this.urlApi + methodName, args, newOptions)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError(this.handleError)
      );
  }

  login(model: any): Observable<any> {
    // Call POST API to login user
    return this.httpPost('user/login?tenDangNhap=' + model.tenDangNhap + '&matKhau=' + model.matKhau, model).pipe(
      map((result: any) => {
        try {
          return result;
        } catch (error) {
          console.log(error);
        }
      }),
    );
  }

  getCodeOTP(email: string) {
    return this.httpPost('User/SendMailOTP?email=' + email, null);
  }

  getMatKhauMoi(params: any) {
    return this.httpPost('User/QuenMatKhau', params);
  }
}
