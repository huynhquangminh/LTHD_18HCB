import { Component, OnInit } from '@angular/core';
import { NhanvienService } from 'src/app/shared/services/nhanvien.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { DialogThemtaikhoanComponent } from '../components/dialog-themtaikhoan/dialog-themtaikhoan.component';
import { CommonService } from 'src/app/shared/services/common.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-danhsachtaikhoan',
  templateUrl: './danhsachtaikhoan.component.html',
  styleUrls: ['./danhsachtaikhoan.component.scss']
})
export class DanhsachtaikhoanComponent implements OnInit {
  public listTaiKhoan: any = [];
  public keySearch = '';
  constructor(
    private nhanVienService: NhanvienService,
    private dialogService: DialogService,
    private commonService: CommonService,
    private router: Router
  ) {}

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
  xemLichSuGiaoDich(item) {
    this.commonService.listChangeTaiKhoanDetail(item);
    this.router.navigateByUrl('manager/history-transactions');
  }

  chuyentien(item) {
    this.commonService.listChangeTaiKhoanDetail(item);
    this.router.navigateByUrl('manager/internal-transactions');
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
}
