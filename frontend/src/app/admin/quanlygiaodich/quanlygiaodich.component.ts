import { Component, OnInit } from '@angular/core';
import { QuanlyService } from 'src/app/shared/services/quanly.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';

@Component({
  selector: 'app-quanlygiaodich',
  templateUrl: './quanlygiaodich.component.html',
  styleUrls: ['./quanlygiaodich.component.scss']
})
export class QuanlygiaodichComponent implements OnInit {
  public keySearch = '';
  public danhSachGiaoDich: any;
  constructor(
    private quanlyService: QuanlyService,
    private dialogService: DialogService,
  ) { }

  ngOnInit() {
    this.getDanhSachGiaoDich();
  }

  getDanhSachGiaoDich() {
    this.quanlyService.getDanhSachGiaoDich().subscribe(res => {
      if (res) {
        this.danhSachGiaoDich = res;
      }
    });
  }

  timKiemGiaoDich() {
    console.log(this.keySearch);
    if (this.keySearch === '') {
      this.getDanhSachGiaoDich();
    } else {
      this.quanlyService.timKiemGiaoDich(this.keySearch).subscribe(res => {
        if (res) {
          this.danhSachGiaoDich = res;
        }
      });
    }
  }

  xoaGiaoDich(id) {
    this.dialogService.showDialogComfirm('Bạn có muốn thông tin giao dịch không!').then(res => {
      if (res) {
        this.quanlyService.xoaGiaoDich(id).subscribe(result => {
          if (result) {
            this.getDanhSachGiaoDich();
          }
        });
      }
    });
  }
}
