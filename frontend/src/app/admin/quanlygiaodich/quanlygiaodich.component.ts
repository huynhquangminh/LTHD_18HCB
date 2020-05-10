import { DanhBaService } from './../../shared/services/danh-ba.service';
import { Component, OnInit } from '@angular/core';
import { QuanlyService } from 'src/app/shared/services/quanly.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { NganhanglienketService } from 'src/app/shared/services/nganhanglienket.service';

@Component({
  selector: 'app-quanlygiaodich',
  templateUrl: './quanlygiaodich.component.html',
  styleUrls: ['./quanlygiaodich.component.scss']
})
export class QuanlygiaodichComponent implements OnInit {
  public keySearch = '';
  public sotaikhoan = '';
  public tennganhang = '--- Tên ngân hàng ---';
  public danhSachGiaoDich: any;
  public listGiaoDichKhacNganHang: any = [];
  public dsNganHang = [];
  constructor(
    private quanlyService: QuanlyService,
    private dialogService: DialogService,
    private nganHangLienKetService: NganhanglienketService,
    private danhBaService: DanhBaService
  ) { }

  ngOnInit() {
    this.getDanhSachGiaoDich();
    this.getDsGiaoDichKhacNganHang();
    this.getDSNganHangLienKet();
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

  getDsGiaoDichKhacNganHang() {
    this.nganHangLienKetService.getLichSuGiaoDichAll().subscribe(res => {
      if (res) {
        this.listGiaoDichKhacNganHang = res;
      }
    });
  }

  xoaGiaoDichKhacNganHang(id) {
    this.dialogService.showDialogComfirm('Bạn có muốn thông tin giao dịch không!').then(res => {
      if (res) {
        this.nganHangLienKetService.xoaGiaoDichKhacNganHang(id).subscribe(result => {
          if (result) {
            this.getDsGiaoDichKhacNganHang();
          }
        });
      }
    });
  }

  getDSNganHangLienKet() {
    this.danhBaService.getDsNganHangLienKet().subscribe(res => {
      if (res) {
        this.dsNganHang = res.filter(item => {
          return item.id !== 0;
        });
        this.dsNganHang.unshift({ id: -1, tenNganHang: '--- Tên ngân hàng ---' });
      }
    });
  }

  timKiemGiaoDichKhacNganHang() {
    if (this.sotaikhoan === '' && this.tennganhang === '--- Tên ngân hàng ---') {
      this.getDsGiaoDichKhacNganHang();
    } else {
      this.nganHangLienKetService.timKiemGiaoDichKhacNganHang(this.sotaikhoan, this.tennganhang).subscribe(res => {
        if (res) {
          this.listGiaoDichKhacNganHang = res;
        }
      });
    }
  }

}
