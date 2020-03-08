import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { HttpClient, HttpHeaders } from '@angular/common/http';

// npm install rxjs@6 rxjs-compat@6 --save
@Injectable()
export class AppService {
    options: any = {
        headers: new HttpHeaders({
            'Content-Type': 'application/json',
        })
    };
    constructor(private http: HttpClient) { }

    CallAllService(apiUrl: string) {
        // return this.http.post(apiUrl, null, null).map((data: Response) => data.json());
        return this.http.post(apiUrl, null, this.options).map((result: any) => {
            return result;
        });
    }
    CallByResquestService(apiUrl: string, request: any) {
        return this.http.post(apiUrl, request, this.options).map((result: any) => {
            return result;
        });
        // return this.http.post(apiUrl, request, null).map((data: Response) => data.json());
    }
}
