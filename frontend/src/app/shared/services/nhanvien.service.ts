import { Injectable } from '@angular/core';
import { ApiService } from './api.service';

@Injectable({
  providedIn: 'root'
})
export class NhanvienService extends ApiService {

  getDanhSachTaiKhoan() {
    return this.httpGet('User/GetAllUsers');
  }

  timkiemTaiKhoan(key: any) {
    return this.httpGet('User/TimKiemThongTinTaiKhoan?key=' + key);
  }
}
