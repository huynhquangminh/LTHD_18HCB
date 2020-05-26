import { ApiLienKetService } from './api.lienket.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class LienketnganhangkhacService extends ApiLienKetService {

  getThongTinTaiKhoan(params: any) {
    return this.httpPost('ib-hn/info-account', params, true);
  }

  giaoDichTaiKhoanKhachNganHang(params: any) {
    return this.httpPost('ib-hn/payInto', params, true);
  }

  getTokenNhom9() {
    const params = {
      user: 'nhom9',
      pwd: 'abc9'
    };
    return this.httpPost('auth/login', params, false);
  }
}
