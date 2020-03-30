import { WebKeyStorage } from './../globlas/web-key-storage';
import { WebStorageSerivce } from './webstorage.service';
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
export class ApiService extends HandleErrorService {
  protected urlApi = 'https://localhost:44364/api/';
  protected headers: HttpHeaders = new HttpHeaders({ 'Content-Type': 'application/json' });
  protected options: any = { headers: this.headers, observe: 'response' };
  protected env = '';
  public isLogin = false;
  constructor(
    dialogServiceService: DialogService,
    router: Router,
    public httpClient: HttpClient,
    private webStorageSerivce: WebStorageSerivce
  ) {
    super(dialogServiceService, router);
  }

  protected setTokenForHeader() {
    const userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    const token = userInfo ? userInfo.token : '';
    this.headers = new HttpHeaders({
      'Content-Type': 'application/json',
      'Authorization': 'Bearer ' + token
    });
    this.options = { headers: this.headers, observe: 'response' };
  }

  public httpGet(
    methodName: string,
    params?: string | URLSearchParams | { [key: string]: any | any[] } | null): Observable<any> {
    this.setTokenForHeader();
    let newOptions = this.options;
    if (params) {
      newOptions = { headers: this.headers, observe: 'response', params };
    }

    return this.httpClient.get(this.urlApi + methodName, newOptions)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError(this.handleError)
      );
  }

  public httpPost(methodName, args, isFormData?: boolean): Observable<any> {
    let newOptions: any;
    let headers: HttpHeaders;
    let formData = '';
    let body;
    this.setTokenForHeader();
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
    return this.httpClient.post(this.urlApi + methodName, body, newOptions)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError(this.handleError)
      );
  }

  public httpPut(methodName, args): Observable<any> {
    this.setTokenForHeader();
    return this.httpClient.put(this.urlApi + methodName, JSON.stringify(args), this.options)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError(this.handleError)
      );
  }

  public httpDelete(methodName): Observable<any> {
    this.setTokenForHeader();
    return this.httpClient.delete(this.urlApi + methodName, this.options)
      .pipe(
        timeoutWith(180000, throwError(new HttpResponse({
          status: HttpStatusCode.InternalServerError
        }))),
        map(d => this.extractData(d)),
        catchError((e) => this.handleError(e))
      );
  }
}
