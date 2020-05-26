import { WebKeyStorage } from './../../../shared/globlas/web-key-storage';
import { AuthService } from './../../../shared/services/auth.service';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-dialog-close-taikhoan',
  templateUrl: './dialog-close-taikhoan.component.html',
  styleUrls: ['./dialog-close-taikhoan.component.scss']
})
export class DialogCloseTaikhoanComponent implements OnInit {
  public form: NgForm;
  public closeAccountModel = {
    matKhau: '',
    maXacNhan: ''
  };
  private codeOTPComfirm = '';
  userInfo: any;
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
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
  }

  onSubmit() {
    if (this.closeAccountModel.maXacNhan && this.codeOTPComfirm) {
      if (this.closeAccountModel.maXacNhan === this.codeOTPComfirm) {
        // goi api xoa tai khoan login
        // this.userInfo.user.maTk
        // matkhau
        const params = {
          maTaiKhoan: this.closeAccountModel.matKhau,
          matKhau: this.userInfo.user.maTk
        };
        this.taikhoanService.dongTaiKhoanThanhToan(params).subscribe(res => {
          if (res) {
            this.modal.close(true);
          }
        });
      }
    } else {
      alert('Mã xác nhận hoặc mật khẩu không đúng');
    }
  }

  getOTP() {
    this.authService.getCodeOTP(this.userInfo.user.email).subscribe(res => {
      if (res) {
        this.codeOTPComfirm = res;
      }
    });
  }

}
