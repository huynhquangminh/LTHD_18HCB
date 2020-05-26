import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { DanhBaService } from 'src/app/shared/services/danh-ba.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { Router } from '@angular/router';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { NhacNoService } from 'src/app/shared/services/nhac-no.service';
import { ThongBaoService } from 'src/app/shared/services/thong-bao.service';

@Component({
  selector: 'app-themnhacno',
  templateUrl: './themnhacno.component.html',
  styleUrls: ['./themnhacno.component.scss']
})
export class ThemnhacnoComponent implements OnInit {
  public formthemnhacno: NgForm;
  public themNhacNoModel = {
    maTkTao: '',
    maTkNo: '',
    soTienNo: null,
    noiDungNhacNo: '',
    ngayTao: '',
    noiDungHuyNhacNo: '',
    trangThai: 0,
    tennguoino: '',
    sotaikhoanno: null
  };
  public listDanhBaModel: any = [];
  public userInfo: any;
  public tennganhang = '18HCB BANK';
  constructor(
    private danhBaService: DanhBaService,
    private webStorageSerivce: WebStorageSerivce,
    private router: Router,
    private taikhoanService: TaikhoanthanhtoanService,
    private nhacNoService: NhacNoService,
    private thongBaoService: ThongBaoService
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDanhBa(this.userInfo.user.maTk);
  }

  onSubmit() {
    this.themNhacNoModel.maTkTao = this.userInfo.user.maTk;
    this.themNhacNoModel.ngayTao = new Date().toLocaleDateString();
    delete this.themNhacNoModel.tennguoino;
    delete this.themNhacNoModel.sotaikhoanno;
    if (this.themNhacNoModel.soTienNo >= 100000) {
      this.nhacNoService.themNhacNo(this.themNhacNoModel).subscribe(res => {
        if (res) {
          const params = {
            maTaiKhoan: this.themNhacNoModel.maTkNo,
            noiDung: 'Bạn có 1 nhắc nợ từ tài khoản tên : ' + this.userInfo.user.tenTaiKhoan
          };
          this.thongBaoService.themThongBao(params).subscribe(result => {
            if (result) {
              this.router.navigateByUrl('/home/debt-reminder');
            }
          });
        }
      });
    }
  }

  getDanhBa(maTk: any) {
    this.danhBaService.getDSDanhBa(maTk).subscribe(res => {
      if (res) {
        this.listDanhBaModel = res.filter(data => {
          return data.idNganHangLienKet === 0;
        }).map(result => {
          return {
            tendanhba: result.tenGoiNho,
            sotaikhoan: result.soTaiKhoan,
            tentaikhoan: result.tenTaiKhoan,
          };
        });
      }
    });
  }

  chondanhba(item) {
    this.themNhacNoModel.sotaikhoanno = item.sotaikhoan;
    this.getThongTinTaiKhoan();
  }

  getThongTinTaiKhoan() {
    if (this.themNhacNoModel.sotaikhoanno) {
      this.taikhoanService.getThongTinTaiKhoanBySoTaiKhoan(this.themNhacNoModel.sotaikhoanno.toString()).subscribe(res => {
        if (res) {
          this.themNhacNoModel.tennguoino = res.tenTaiKhoan;
          this.themNhacNoModel.maTkNo = res.maTk;
        }
      });
    } else {
      this.themNhacNoModel.tennguoino = '';
    }
  }
}
