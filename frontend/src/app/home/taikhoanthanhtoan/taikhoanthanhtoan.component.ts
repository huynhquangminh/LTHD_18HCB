import { WebKeyStorage } from './../../shared/globlas/web-key-storage';
import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';

@Component({
  selector: 'app-taikhoanthanhtoan',
  templateUrl: './taikhoanthanhtoan.component.html',
  styleUrls: ['./taikhoanthanhtoan.component.scss']
})
export class TaikhoanthanhtoanComponent implements OnInit {
  thongTinTaiKhoanModel: any = {};
  userInfo: any;
  constructor(
    private taikhoanthanhtoanService: TaikhoanthanhtoanService,
    private webStorageSerivce: WebStorageSerivce
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    if (this.userInfo) {
      this.getThongTinTaiKhoanThanhToan(this.userInfo.user.maTk);
    }
  }

  getThongTinTaiKhoanThanhToan(matk: string) {
    this.taikhoanthanhtoanService.getThongTinTaiKhoanThanhToan(matk).subscribe(res => {
      if (res) {
        this.thongTinTaiKhoanModel = res;
      }
    });
  }

}
