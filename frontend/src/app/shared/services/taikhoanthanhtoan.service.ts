import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class TaikhoanthanhtoanService extends ApiService {

  getThongTinTaiKhoanThanhToan(matk: string) {
    return this.httpGet('user/thongtintaiKhoan?maTaiKhoan=' + matk);
  }

  doiMatKhau(params: any = {}) {
    return this.httpPut('user/doimatkhau', params);
  }
}
