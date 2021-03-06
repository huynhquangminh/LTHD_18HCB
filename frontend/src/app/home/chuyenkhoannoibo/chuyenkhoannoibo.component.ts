import { Router } from '@angular/router';
import { AuthService } from './../../shared/services/auth.service';
import { map } from 'rxjs/operators';
import { DanhBaService } from './../../shared/services/danh-ba.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';

@Component({
  selector: 'app-chuyenkhoannoibo',
  templateUrl: './chuyenkhoannoibo.component.html',
  styleUrls: ['./chuyenkhoannoibo.component.scss']
})
export class ChuyenkhoannoiboComponent implements OnInit {
  public cknoiboform: NgForm;
  public indexTab = 0;
  public codeOTP = null;
  private codeOTPComfirm = null;
  public chuyenkhoanModel: any = {
    tennguoinhan: '',
    sotaikhoan: null,
    sotiengui: null,
    noidungchuyentien: '',
    traphi: 0
  };
  private userInfo: any;
  public listDanhBaModel: any[];
  public tennganhang = '18HCB BANK';
  constructor(
    private taikhoanService: TaikhoanthanhtoanService,
    private danhBaService: DanhBaService,
    private webStorageSerivce: WebStorageSerivce,
    private authService: AuthService,
    private router: Router
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDanhBa(this.userInfo.user.maTk);
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
            tentaikhoan: result.tenTaiKhoan
          };
        });
      }
    });
  }

  onSubmitThongTin() {
    if (this.chuyenkhoanModel.sotiengui >= 100000) {
      this.indexTab = 1;
      this.codeOTP = null;
      this.codeOTPComfirm = null;
    } else {
      alert('Số tiền phải lớn hơn 100,000 VND');
    }
  }

  getCodeOTP() {
    this.authService.getCodeOTP(this.userInfo.user.email).subscribe(res => {
      if (res) {
        this.codeOTPComfirm = res;
      }
    });
  }

  chondanhba(item) {
    this.chuyenkhoanModel.tennguoinhan = item.tentaikhoan;
    this.chuyenkhoanModel.sotaikhoan = item.sotaikhoan;
  }

  back() {
    this.indexTab = 0;
  }

  chuyenkhoan() {
    if (this.checkOTP()) {
      const params: any = {
        id: null,
        MaTk: this.userInfo.user.maTk,
        ngayGd:  new Date().toLocaleDateString(),
        stkGui: this.userInfo.user.soTaiKhoan,
        stkNhan: this.chuyenkhoanModel.sotaikhoan,
        soTienGui: this.chuyenkhoanModel.sotiengui,
        noiDung: this.chuyenkhoanModel.noidungchuyentien,
        loaiTraPhi: this.chuyenkhoanModel.traphi ? true : false,
        trangThaiChuyenTien: false
      };
      this.taikhoanService.chuyenKhoanNoiBo(params).subscribe(res => {
        if (res) {
          const request = {
            taiKhoanGui: this.userInfo.user.soTaiKhoan,
            taiKhoanNhan: this.chuyenkhoanModel.sotaikhoan,
            soTienGui : this.chuyenkhoanModel.sotiengui
          };
          this.updateThongSoDu(request);
        }
      });
    }
  }

  checkOTP() {
    if (this.codeOTPComfirm === null) {
      alert('Bạn chưa có mã xác nhận!');
      return false;
    }
    if (this.codeOTP === null) {
      alert('Bạn chưa nhập mã xác nhận!');
      return false;
    }
    if (this.codeOTPComfirm !== this.codeOTP.toString()) {
      alert('Mã xác nhận không đúng!');
      return false;
    }
    return true;
  }

  updateThongSoDu(params) {
    this.taikhoanService.updateSoDuTaiKhoan(params).subscribe(res => {
      if (res) {
        this.router.navigateByUrl('/home');
      }
    });
  }

  thongtintaikhoan() {
    if (this.chuyenkhoanModel.sotaikhoan) {
      this.taikhoanService.getThongTinTaiKhoanBySoTaiKhoan(this.chuyenkhoanModel.sotaikhoan).subscribe(res => {
        if (res) {
          this.chuyenkhoanModel.tennguoinhan = res.tenTaiKhoan;
        } else {
          this.chuyenkhoanModel.tennguoinhan = '';
        }
      });
    } else {
      this.chuyenkhoanModel.tennguoinhan = '';
    }
  }
}
