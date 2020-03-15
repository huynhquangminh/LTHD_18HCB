import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DanhBaService extends ApiService  {

  getDSDanhBa(matk: string) {
    return this.httpGet('DanhBa/GetDSDanhBa?maTaiKhoan=' + matk);
  }

}
