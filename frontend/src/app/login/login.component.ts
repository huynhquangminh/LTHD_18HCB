import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/services/auth.service';
import { WebStorageSerivce } from '../shared/services/webstorage.service';
import { WebKeyStorage } from '../shared/globlas/web-key-storage';

@Component({
    selector: 'app-login',
    templateUrl: './login.component.html',
    styleUrls: ['./login.component.scss'],
    animations: [routerTransition()]
})
export class LoginComponent implements OnInit {
    public formLogin: NgForm;
    public isLoger = false;
    public modelLogin = {
        tenDangNhap: '',
        matKhau: ''
    };
    constructor(
        public router: Router,
        private authService: AuthService,
        private webStorageSerivce: WebStorageSerivce
    ) { }

    ngOnInit() { }

    onSubmit() {
        this.authService.login(this.modelLogin).subscribe(res => {
            if (res) {
                this.authService.isLogin = true;
                const result = res;
                delete result.user.matKhau;
                delete result.user.soDu;
                result['isLogin'] = this.authService.isLogin;
                this.webStorageSerivce.setLocalStorage(WebKeyStorage.user_info, result);
                if (res.user.idLoaiTaiKhoan === 1) {
                    this.router.navigateByUrl('/home');
                } else {
                    this.router.navigateByUrl('/manager');
                }
            }
        });
    }
    public resolved(captchaResponse: string) {
        this.isLoger = true;
    }
}
