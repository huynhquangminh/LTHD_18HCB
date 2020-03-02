import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { routerTransition } from '../router.animations';
import { NgForm } from '@angular/forms';
import { AuthService } from '../shared/services/auth.service';

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
        tendangnhap: '',
        matkhau: '',
        typeLogin: true
    };
    constructor(
        public router: Router,
        private authService: AuthService
    ) { }

    ngOnInit() { }

    onSubmit() {
        // this.authService.login(this.modelLogin).subscribe(res => {
        //     if (res) {
                this.authService.isLogin = true;
                this.router.navigateByUrl('/home');
        //     }
        // });
    }
    public resolved(captchaResponse: string) {
        this.isLoger = true;
    }
}
