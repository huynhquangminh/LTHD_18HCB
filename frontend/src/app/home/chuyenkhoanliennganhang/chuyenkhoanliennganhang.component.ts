import { DanhBaService } from './../../shared/services/danh-ba.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NganhanglienketService } from 'src/app/shared/services/nganhanglienket.service';
import * as moment from 'moment';
import { AuthService } from 'src/app/shared/services/auth.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { LienketnganhangkhacService } from 'src/app/shared/services/lienketnganhangkhac.service';

@Component({
  selector: 'app-chuyenkhoanliennganhang',
  templateUrl: './chuyenkhoanliennganhang.component.html',
  styleUrls: ['./chuyenkhoanliennganhang.component.scss']
})
export class ChuyenkhoanliennganhangComponent implements OnInit {
  public form: NgForm;
  public indexTab = 0;
  public codeOTP = null;
  private codeOTPComfirm = null;
  public dsNganHang: any = [];
  public chuyenkhoanModel: any = {
    tennguoinhan: '',
    sotaikhoan: null,
    tennganhang: null,
    sotiengui: null,
    noidungchuyentien: ''
  };
  private userInfo: any;
  constructor(
    private danhBaService: DanhBaService,
    private nganHangLKService: NganhanglienketService,
    private authService: AuthService,
    private webStorageSerivce: WebStorageSerivce,
    private lienKetNganHangKhacService: LienketnganhangkhacService
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDSNganHangLienKet();
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

  back() {
    this.indexTab = 0;
  }

  chuyenkhoan() {
    if (this.checkOTP()) {
      // goi api chuyen khoan cua ngan hang tuong ung
      this.nganHangLKService.getSignData().subscribe(res => {
        if (res) {
          const params = {
            tenNganHangGui: '18HCB BANK',
            soTaiKhoanGui: this.userInfo.user.soTaiKhoan,
            soTaiKhoanNhan: this.chuyenkhoanModel.sotaikhoan.toString(),
            tenNguoiNhan: this.chuyenkhoanModel.tennguoinhan,
            tenNguoiGui: this.userInfo.user.tenTaiKhoan,
            soTienChuyen: this.chuyenkhoanModel.sotiengui.toString(),
            ngayTao: moment(new Date()).format('YYYY-MM-DD'),
            noiDung: this.chuyenkhoanModel.noidungchuyentien,
            signature: res
          };
          this.lienKetNganHangKhacService.giaoDichTaiKhoanKhachNganHang(params).subscribe(result => {
            if (result.status) {
              this.codeOTP = null;
              this.codeOTPComfirm = null;
              this.luuThongTinGiaoDich();
            }
          });
        }
      });
    }
   }

  getDSNganHangLienKet() {
    this.danhBaService.getDsNganHangLienKet().subscribe(res => {
      if (res) {
        this.dsNganHang = res.filter(item => {
          return item.id !== 0;
        });
      }
    });
  }

  getThongTinTaiKhoan() {
    // gọi api lấy thông tin tài khoản từ ngân hàng khác
    if (this.chuyenkhoanModel.sotaikhoan && this.chuyenkhoanModel.sotaikhoan.toString().length >= 9 && this.chuyenkhoanModel.tennganhang) {
      const timeNow = moment(new Date()).format('YYYYMMDDHHmmss');
      const textStr = this.chuyenkhoanModel.sotaikhoan.toString() + timeNow + 'nhom21';
      this.nganHangLKService.getHashString(textStr).subscribe(res => {
        if (res) {
          const params = {
            soTk: this.chuyenkhoanModel.sotaikhoan.toString(),
            timer: timeNow,
            hashCode: res
          };
          this.lienKetNganHangKhacService.getThongTinTaiKhoan(params).subscribe(result => {
            if (result) {
              this.chuyenkhoanModel.tennguoinhan = result.ten;
            }
          });
        }
      });
    } else {
      this.chuyenkhoanModel.tennguoinhan = '';
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

  luuThongTinGiaoDich() {
    const params = {
      soTKGui: this.userInfo.user.soTaiKhoan,
      tenNganHangGui: '18HCB BANK',
      soTKNhan: this.chuyenkhoanModel.sotaikhoan.toString(),
      tenNganHangNhan: this.chuyenkhoanModel.tennganhang,
      soTien: this.chuyenkhoanModel.sotiengui,
      noiDung: this.chuyenkhoanModel.noidungchuyentien,
      ngayTao: moment(new Date()).format('YYYY-MM-DD'),
    };
    this.nganHangLKService.luuGiaoDichKhacNganHang(params).subscribe(res => {
      if (res) {
        alert('chuyen tien thanh cong');
      }
    });
  }

}
