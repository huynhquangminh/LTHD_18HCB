import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class NhacNoService extends ApiService {

  getDanhSachNguoiNo(matk: any) {
    return this.httpGet('NhacNo/GetDanhSachNguoiNo?maTaiKhoan=' + matk);
  }

  getDanhSachNo(matk: any) {
    return this.httpGet('NhacNo/GetDanhSachNo?maTaiKhoan=' + matk);
  }

  themNhacNo(params: any) {
    return this.httpPost('NhacNo/Them', params);
  }

  updateTrangThaiNo(params: any) {
    return this.httpPut('NhacNo/UpdateTrangThai', params);
  }

}
