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

  getLichSuChuyenTien(sotaikhoan: any) {
    return this.httpGet('ThongTinChuyenTienNoiBo/GetGiaoDichGuiTienNoiBo?soTaiKhoan=' + sotaikhoan);
  }

  getLichSuNhanTien(sotaikhoan: any) {
    return this.httpGet('ThongTinChuyenTienNoiBo/GetGiaoDichNhanTienNoiBo?soTaiKhoan=' + sotaikhoan);
  }

  updateSoDuTaiKhoan(params: any) {
    return this.httpPut('User/UpdateSoDuSauKhiChuyenKhoanNoiBo', params);
  }

  themNganHangLienKet(params: any) {
    return this.httpPost('NganHangLienKet/ThemNganHangLienKet', params);
  }

  dongTaiKhoanThanhToan(params: any) {
    return this.httpPost('User/DongTaiKhoanThanhToan', params);
  }
}
