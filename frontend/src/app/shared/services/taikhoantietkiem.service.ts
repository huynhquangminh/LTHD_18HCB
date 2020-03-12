import { ApiService } from './api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class TaikhoantietkiemService extends ApiService {
  getThongTinTaiKhoanTietKiem(matk: string) {
    return this.httpGet('TaiKhoanTietKiem/GetDanhSachTheoMaTaiKhoan?maTaiKhoan=' + matk);
  }
}
