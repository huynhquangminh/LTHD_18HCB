import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class QuanlyService extends ApiService {

  xoaTaiKhoan(id: any) {
    return this.httpDelete('User/XoaTaiKhoan?maTaiKhoan=' + id);
  }

  updateThongTinTaiKhoanKhachHang(params: any) {
    return this.httpPut('User/UpdateThongTinTaiKhoanKhachHang', params);
  }

  updateThongTinTaiKhoanNhanVien(params: any) {
    return this.httpPut('User/UpdateThongTinTaiKhoanNhanVien', params);
  }

  getDanhSachTaiKhoanNhanVien() {
    return this.httpGet('User/GetDanhSachTaiKhoanAdmin');
  }

  themTaiKhoanNhanVien(params: any) {
    return this.httpPost('User/DangKyTaiKhoanNhanVien', params);
  }

  getDanhSachGiaoDich() {
    return this.httpGet('ThongTinChuyenTienNoiBo/GetDanhSachGiaoDich');
  }

  xoaGiaoDich(id) {
    return this.httpDelete('ThongTinChuyenTienNoiBo/XoaGiaoDich?id=' + id);
  }

  timKiemGiaoDich(key) {
    return this.httpGet('ThongTinChuyenTienNoiBo/TimKiemGiaoDich?key=' + key);
  }
}
