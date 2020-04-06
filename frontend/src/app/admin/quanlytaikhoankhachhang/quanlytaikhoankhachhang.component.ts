import { Component, OnInit } from '@angular/core';
import { NhanvienService } from 'src/app/shared/services/nhanvien.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { CommonService } from 'src/app/shared/services/common.service';
import { Router } from '@angular/router';
import { DialogThemtaikhoanComponent } from '../components/dialog-themtaikhoan/dialog-themtaikhoan.component';
import { QuanlyService } from 'src/app/shared/services/quanly.service';
import { DialogUpdateTaikhoanComponent } from '../components/dialog-update-taikhoan/dialog-update-taikhoan.component';

@Component({
  selector: 'app-quanlytaikhoankhachhang',
  templateUrl: './quanlytaikhoankhachhang.component.html',
  styleUrls: ['./quanlytaikhoankhachhang.component.scss']
})
export class QuanlytaikhoankhachhangComponent implements OnInit {
  public listTaiKhoan: any = [];
  public keySearch = '';
  constructor(
    private nhanVienService: NhanvienService,
    private dialogService: DialogService,
    private quanlyService: QuanlyService,
    private commonService: CommonService,
    private router: Router
  ) { }

  ngOnInit() {
    this.getDanhSachTaiKhoan();
  }

  getDanhSachTaiKhoan() {
    this.nhanVienService.getDanhSachTaiKhoan().subscribe(res => {
      if (res) {
        this.listTaiKhoan = res;
      }
    });
  }

  taoMoiTaiKhoan() {
    this.dialogService.showDialog(DialogThemtaikhoanComponent).then(res => {
      if (res) {
        this.getDanhSachTaiKhoan();
      }
    });
  }

  timkiemTaiKhoan() {
    if (this.keySearch === '') {
      this.getDanhSachTaiKhoan();
    } else {
      this.nhanVienService.timkiemTaiKhoan(this.keySearch).subscribe(res => {
        if (res) {
          this.listTaiKhoan = res;
        }
      });
    }
  }

  xoaTaiKhoan(id) {
    this.dialogService.showDialogComfirm('Bạn có muốn xóa tài khoản không!').then(res => {
      if (res) {
        this.quanlyService.xoaTaiKhoan(id).subscribe(result => {
          if (result) {
            this.getDanhSachTaiKhoan();
          }
        });
      }
    });
  }

  suaThongTinTaiKhoan (item) {
    this.dialogService.showDialog(DialogUpdateTaikhoanComponent, item).then(res => {
      if (res) {
        this.getDanhSachTaiKhoan();
      }
    });
  }

}
