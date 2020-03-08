import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/services/auth.service';
import { AppService } from '../shared/services/app-service';

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
        private appService: AppService
    ) { }

    ngOnInit() { }

    onSubmit() {
        this.authService.login(this.modelLogin).subscribe(res => {
            if (res) {
                this.authService.isLogin = true;
                this.router.navigateByUrl('/home');
            }
        });
    }
    public resolved(captchaResponse: string) {
        this.isLoger = true;
    }
}
