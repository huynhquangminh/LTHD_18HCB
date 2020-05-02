import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';

@Component({
  selector: 'app-lienketnganhang',
  templateUrl: './lienketnganhang.component.html',
  styleUrls: ['./lienketnganhang.component.scss']
})
export class LienketnganhangComponent implements OnInit {
  public listNganHangLienKet: any = [];
  constructor(
    private taiKhoanService: TaikhoanthanhtoanService
  ) { }

  ngOnInit() {
    this.getDanhSachNganHangLienKet();
  }

  getDanhSachNganHangLienKet() {
    this.taiKhoanService.getDanhSachNganHangLienKet().subscribe(res => {
      if (res) {
        this.listNganHangLienKet = res.filter(item => {
          return item.id !== 0;
        });
      }
    });
  }

  taoLienKet() { }
}
