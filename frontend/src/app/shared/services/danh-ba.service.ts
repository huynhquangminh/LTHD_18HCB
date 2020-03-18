import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class DanhBaService extends ApiService {

  getDSDanhBa(matk: string) {
    return this.httpGet('DanhBa/GetDSDanhBa?maTaiKhoan=' + matk);
  }

  deleteDanhBa(id: any) {
    return this.httpDelete('DanhBa/XoaDanhBa?id=' + id);
  }

  themDanhBa(request: any = {}) {
    return this.httpPost('DanhBa/ThemDanhBa', request);
  }

  suaDanhBa(request: any = {}) {
    return this.httpPut('DanhBa/SuaDanhBa', request);
  }

}
