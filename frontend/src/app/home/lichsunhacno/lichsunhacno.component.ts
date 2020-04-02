import { DialogService } from './../../shared/services/dialog-service.service';
import { NhacNoService } from './../../shared/services/nhac-no.service';
import { Component, OnInit } from '@angular/core';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';
import { ThongBaoService } from 'src/app/shared/services/thong-bao.service';
import { DialogThanhtoannoComponent } from '../components/dialog-thanhtoanno/dialog-thanhtoanno.component';

@Component({
  selector: 'app-lichsunhacno',
  templateUrl: './lichsunhacno.component.html',
  styleUrls: ['./lichsunhacno.component.scss']
})
export class LichsunhacnoComponent implements OnInit {
  public userInfo: any;
  public listDanhSachNo: any = [];
  public listDanhSachNguoiNo: any = [];
  constructor(
    private nhacNoService: NhacNoService,
    private webStorageSerivce: WebStorageSerivce,
    private thongBaoService: ThongBaoService,
    private dialogService: DialogService
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDanhSachNo(this.userInfo.user.maTk);
    this.getDanhSachNguoiNo(this.userInfo.user.maTk);
  }

  getDanhSachNo(matk: any) {
    this.nhacNoService.getDanhSachNo(matk).subscribe(res => {
      if (res) {
        this.listDanhSachNo = res;
      }
    });
  }

  getDanhSachNguoiNo(matk: any) {
    this.nhacNoService.getDanhSachNguoiNo(matk).subscribe(res => {
      if (res) {
        this.listDanhSachNguoiNo = res;
      }
    });
  }

  huynhacno(item) {
    const params = {
      id: item.id,
      maTk: this.userInfo.user.maTk,
      trangThai: -1,
      noiDungHuyNhacNo: 'Nhac no da duoc thanh toan hoac ly do khac'
    };
    this.nhacNoService.updateTrangThaiNo(params).subscribe(res => {
      if (res) {
        const pr = {
          maTaiKhoan: item.maTkNo,
          noiDung: 'Ban co 1 nhac no da huy tu tai khoan ten : : ' + this.userInfo.user.tenTaiKhoan
        };
        this.thongBaoService.themThongBao(pr).subscribe(result => {
          if (result) {
            this.getDanhSachNguoiNo(this.userInfo.user.maTk);
          }
        });
      }
    });
  }

  showDialogThanhToanNo(item) {
    this.dialogService.showDialog(DialogThanhtoannoComponent, item).then(res => {
      if (res) {
        const params = {
          id: item.id,
          maTk: this.userInfo.user.maTk,
          trangThai: 1,
          noiDungHuyNhacNo: ''
        };
        this.nhacNoService.updateTrangThaiNo(params).subscribe(result => {
          if (result) {
            const pr = {
              maTaiKhoan: item.maTkTao,
              noiDung: 'Ban co 1 thanh toan no tu tai khoan  : ' + this.userInfo.user.tenTaiKhoan
            };
            this.thongBaoService.themThongBao(pr).subscribe(data => {
              if (data) {
                this.getDanhSachNo(this.userInfo.user.maTk);
              }
            });
          }
        });
      }
    });
  }
}
