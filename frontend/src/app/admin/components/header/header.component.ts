import { DialogService } from './../../../shared/services/dialog-service.service';
import { AuthService } from './../../../shared/services/auth.service';
import { WebKeyStorage } from './../../../shared/globlas/web-key-storage';
import { Component, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { TranslateService } from '@ngx-translate/core';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { ThongBaoService } from 'src/app/shared/services/thong-bao.service';
import { DialogThongbaoComponent } from 'src/app/shared/component/dialog-thongbao/dialog-thongbao.component';

@Component({
    selector: 'app-header',
    templateUrl: './header.component.html',
    styleUrls: ['./header.component.scss']
})
export class HeaderComponent implements OnInit {
    public pushRightClass: string;

    constructor(
        public router: Router,
        private webStorageSerivce: WebStorageSerivce,
        private authSerivce: AuthService
    ) {

        this.router.events.subscribe(val => {
            if (
                val instanceof NavigationEnd &&
                window.innerWidth <= 992 &&
                this.isToggled()
            ) {
                this.toggleSidebar();
            }
        });
    }

    ngOnInit() {
        this.pushRightClass = 'push-right';
    }

    isToggled(): boolean {
        const dom: Element = document.querySelector('body');
        return dom.classList.contains(this.pushRightClass);
    }

    toggleSidebar() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle(this.pushRightClass);
    }

    rltAndLtr() {
        const dom: any = document.querySelector('body');
        dom.classList.toggle('rtl');
    }

    onLoggedout() {
        this.webStorageSerivce.clearLocalStorage();
        this.authSerivce.isLogin = false;
        this.router.navigateByUrl('/login');
    }
}
