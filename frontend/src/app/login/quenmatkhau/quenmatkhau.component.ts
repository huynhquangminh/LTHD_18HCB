import { Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/shared/services/auth.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';

@Component({
  selector: 'app-quenmatkhau',
  templateUrl: './quenmatkhau.component.html',
  styleUrls: ['./quenmatkhau.component.scss']
})
export class QuenmatkhauComponent implements OnInit {
  public forgotPassword: NgForm;
  public modelForgotPassword = {
    tenDangNhap: '',
    email: ''
  };
  public codeOTP = '';
  public isCodeOTP = false;
  public isCheckCodeOTP = true;
  resultOTP = '';
  constructor(
    private authService: AuthService,
    private router: Router,
    private dialogService: DialogService
  ) { }

  ngOnInit() {
  }

  onSubmit() {
    console.log('log');
    this.isCodeOTP = false;
    if (!this.codeOTP.localeCompare(this.resultOTP)) {
      this.authService.getMatKhauMoi(this.modelForgotPassword).subscribe(res => {
        if (res) {
          const mes = 'Mật khẩu mới đã được gửi xuống mail của bạn, vui lòng đăng nhập lai!'
          this.dialogService.showDialogComfirm(mes).then(result => {
            this.router.navigateByUrl('/login');
          });
        }
      });
    } else {
      this.isCheckCodeOTP = false;
    }
  }

  getCodeOTP() {
    this.authService.getCodeOTP(this.modelForgotPassword.email).subscribe(res => {
      if (res) {
        this.isCodeOTP = true;
        this.resultOTP = res;
      }
    });
  }

}
