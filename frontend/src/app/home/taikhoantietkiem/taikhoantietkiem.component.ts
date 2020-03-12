import { Component, OnInit } from '@angular/core';
import { TaikhoantietkiemService } from 'src/app/shared/services/taikhoantietkiem.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';

@Component({
  selector: 'app-taikhoantietkiem',
  templateUrl: './taikhoantietkiem.component.html',
  styleUrls: ['./taikhoantietkiem.component.scss']
})
export class TaikhoantietkiemComponent implements OnInit {
  thongTinTaiKhoanModel: any = [];
  userInfo: any;
  constructor(
    private tktietkiemService: TaikhoantietkiemService,
    private webStorageSerivce: WebStorageSerivce
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    if (this.userInfo) {
      this.getDSTaiKhoanTietKiem(this.userInfo.user.maTk);
    }
  }

  getDSTaiKhoanTietKiem(matk: string) {
    this.tktietkiemService.getThongTinTaiKhoanTietKiem(matk).subscribe(res => {
      if (res) {
        this.thongTinTaiKhoanModel = res;
      }
    });
  }

}
