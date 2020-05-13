import { ApiService } from './api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class NganhanglienketService extends ApiService {
  getThongTinTaiKhoan(params: any) {
   return this.httpPost('NganHangLienKet/GetThongTinTaiKhoan', params);
  }

  getHashString(textStr: string) {
    return this.httpGet('NganHangLienKet/GetHashString?hashString=' + textStr);
  }

  getSignData(keyStr = 'nhom9') {
    return this.httpGet('NganHangLienKet/GetSignDataRSA?secretKey=' + keyStr);
  }

  giaoDichKhacNganHang(params: any) {
    return this.httpPost('NganHangLienKet/GiaoDichKhacNganHang', params);
  }

  getLichSuGiaoDich(stk: string) {
    return this.httpGet('NganHangLienKet/XemGiaoDichKhacNganHang?soTaiKhoan=' + stk);
  }

  getLichSuGiaoDichAll() {
    return this.httpGet('NganHangLienKet/GetAllGiaoDichKhacNganHang');
  }

  xoaGiaoDichKhacNganHang(id) {
    return this.httpDelete('NganHangLienKet/XoaThongTinGiaoDichKhacNganHang?id=' + id);
  }

  timKiemGiaoDichKhacNganHang(stk: string = '', tenNganHang: string = ''){
    return this.httpGet('NganHangLienKet/TimKiemGiaoDichKhacNganHang?soTaiKhoan=' + stk + '&tenNganHang=' + tenNganHang);
  }

  giaoDichKhacNganHangAdmin(params: any = {}) {
    return this.httpPost('NganHangLienKet/GiaoDichChuyenTienAdmin', params);
  }

}
