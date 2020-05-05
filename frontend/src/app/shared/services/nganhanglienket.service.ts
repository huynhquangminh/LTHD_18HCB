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

}
