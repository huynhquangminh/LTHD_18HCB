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

  getDanhSachNganHangLienKet() {
    return this.httpGet('NganHangLienKet/GetDanhSach');
  }

  chuyenKhoanNoiBo(params: any = {}) {
    return this.httpPost('ThongTinChuyenTienNoiBo/ChuyenKhoanNoiBo', params);
  }

  getThongTinTaiKhoanBySoTaiKhoan(stk: any) {
    return this.httpGet('User/GetThongTinTaiKhoanBySoTaiKhoan?soTaiKhoan=' + stk);
  }

  getLichSuChuyenTien(matk: any) {
    return this.httpGet('ThongTinChuyenTienNoiBo/GetGiaoDichGuiTienNoiBo?maTaiKhoan=' + matk);
  }

  getLichSuNhanTien(matk: any) {
    return this.httpGet('ThongTinChuyenTienNoiBo/GetGiaoDichNhanTienNoiBo?soTaiKhoan=' + matk);
  }

  updateSoDuTaiKhoan(params: any) {
    return this.httpPut('User/UpdateSoDuSauKhiChuyenKhoanNoiBo', params);
  }
}
