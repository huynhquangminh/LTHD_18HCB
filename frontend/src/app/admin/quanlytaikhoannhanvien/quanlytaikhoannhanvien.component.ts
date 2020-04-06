import { Component, OnInit } from '@angular/core';
import { QuanlyService } from 'src/app/shared/services/quanly.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { DialogTaikhoanNhanvienComponent } from '../components/dialog-taikhoan-nhanvien/dialog-taikhoan-nhanvien.component';

@Component({
  selector: 'app-quanlytaikhoannhanvien',
  templateUrl: './quanlytaikhoannhanvien.component.html',
  styleUrls: ['./quanlytaikhoannhanvien.component.scss']
})
export class QuanlytaikhoannhanvienComponent implements OnInit {
  public listTaiKhoanNhanVien: any;
  constructor(
    private quanlyService: QuanlyService,
    private dialogService: DialogService,
  ) { }

  ngOnInit() {
    this.getDanhSachTaiKhoanNhanVien();
  }

  getDanhSachTaiKhoanNhanVien() {
    this.quanlyService.getDanhSachTaiKhoanNhanVien().subscribe(res => {
      if (res) {
        this.listTaiKhoanNhanVien = res;
      }
    });
  }

  taoMoiTaiKhoan() {
    this.dialogService.showDialog(DialogTaikhoanNhanvienComponent).then(res => {
      if (res) {
        this.getDanhSachTaiKhoanNhanVien();
      }
    });
  }

  xoaTaiKhoan(matk) {
    this.dialogService.showDialogComfirm('Bạn có muốn xóa tài khoản không!').then(res => {
      if (res) {
        this.quanlyService.xoaTaiKhoan(matk).subscribe(result => {
          if (result) {
            this.getDanhSachTaiKhoanNhanVien();
          }
        });
      }
    });
  }

  suaThongTinTaiKhoan() { }
}
