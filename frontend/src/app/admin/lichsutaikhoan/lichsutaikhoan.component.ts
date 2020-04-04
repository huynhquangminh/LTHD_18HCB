import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { CommonService } from 'src/app/shared/services/common.service';

@Component({
  selector: 'app-lichsutaikhoan',
  templateUrl: './lichsutaikhoan.component.html',
  styleUrls: ['./lichsutaikhoan.component.scss']
})
export class LichsutaikhoanComponent implements OnInit {
  public listChuyenTien: any = [];
  public listNhanTien: any = [];
  public tentaikhoan: any;
  public sotaikhoan: any;
  constructor(
    private taikhoanService: TaikhoanthanhtoanService,
    private commonService: CommonService,
  ) { }

  ngOnInit() {
    this.commonService.objTaikhoan.subscribe(res => {
      if (res) {
        this.tentaikhoan = res.tenTaiKhoan;
        this.sotaikhoan = res.soTaiKhoan;
        this.getLichSuChuyenTien(res.soTaiKhoan);
        this.getLichSuNhanTien(res.soTaiKhoan);
      }
    });
  }

  getLichSuChuyenTien(sotaikhoan) {
    this.taikhoanService.getLichSuChuyenTien(sotaikhoan).subscribe(res => {
      if (res) {
        this.listChuyenTien = res;
      }
    });
  }

  getLichSuNhanTien(sotaikhoan) {
    this.taikhoanService.getLichSuNhanTien(sotaikhoan).subscribe(res => {
      if (res) {
        this.listNhanTien = res;
      }
    });
  }

}
