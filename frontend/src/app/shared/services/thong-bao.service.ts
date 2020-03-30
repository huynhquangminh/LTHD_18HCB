import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class ThongBaoService extends ApiService {

  getThongBaoUser(maTaiKhoan: string) {
    return this.httpGet('thongbao/getdsthongbao?maTaiKhoan=' + maTaiKhoan );
  }

  themThongBao(params: any) {
    return this.httpPost('ThongBao/Them', params);
  }

  updateThongBao(id: any) {
    return this.httpPut('ThongBao/Update?id=' + id, null);
  }
}
