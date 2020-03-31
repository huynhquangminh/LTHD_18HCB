import { WebKeyStorage } from './../../../shared/globlas/web-key-storage';
import { AuthService } from './../../../shared/services/auth.service';
import { NgForm } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';

@Component({
  selector: 'app-dialog-thanhtoanno',
  templateUrl: './dialog-thanhtoanno.component.html',
  styleUrls: ['./dialog-thanhtoanno.component.scss']
})
export class DialogThanhtoannoComponent implements OnInit {
  @Input() data = null;
  public formthanhtoanno: NgForm;
  public thanhToanNoModel = {
    tennguoinhan: '',
    sotaikhoan: '',
    sotiengui: 0,
    noidungchuyentien: ''
  };
  public tennganhang = '18HCB Bank';
  public codeOTP = null;
  userInfo: any;
  private codeOTPComfirm = null;
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    private webStorageSerivce: WebStorageSerivce,
    private taikhoanService: TaikhoanthanhtoanService,
    private authService: AuthService,
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
    console.log('data', this.data);
    this.thanhToanNoModel.tennguoinhan = this.data.tenTaiKhoan;
    this.thanhToanNoModel.sotaikhoan = this.data.soTaiKhoan;
    this.thanhToanNoModel.sotiengui = this.data.soTienNo;
    this.thanhToanNoModel.noidungchuyentien = 'Thanh toan no cho tai khoan :' + this.data.tenTaiKhoan;
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
  }

  onSubmit() {
    if (this.checkOTP()) {
      const params: any = {
        id: null,
        MaTk: this.userInfo.user.maTk,
        ngayGd: new Date().toLocaleDateString(),
        stkGui: this.userInfo.user.soTaiKhoan,
        stkNhan: this.thanhToanNoModel.sotaikhoan,
        soTienGui: this.thanhToanNoModel.sotiengui,
        noiDung: this.thanhToanNoModel.noidungchuyentien,
        loaiTraPhi: false,
        trangThaiChuyenTien: false
      };
      this.taikhoanService.chuyenKhoanNoiBo(params).subscribe(res => {
        if (res) {
          const request = {
            taiKhoanGui: this.userInfo.user.soTaiKhoan,
            taiKhoanNhan: this.thanhToanNoModel.sotaikhoan,
            soTienGui : this.thanhToanNoModel.sotiengui
          };
          this.updateThongSoDu(request);
        }
      });
    }
  }
  getCodeOTP() {
    this.authService.getCodeOTP(this.userInfo.user.email).subscribe(res => {
      if (res) {
        this.codeOTPComfirm = res;
      }
    });
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
        this.modal.close(true);
      }
    });
  }
}
