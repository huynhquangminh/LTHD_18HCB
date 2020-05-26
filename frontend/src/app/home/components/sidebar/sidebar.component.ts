import { Component, Output, EventEmitter, OnInit } from '@angular/core';
import { Router, NavigationEnd } from '@angular/router';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { DialogDoimatkhauComponent } from '../dialog-doimatkhau/dialog-doimatkhau.component';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { AuthService } from 'src/app/shared/services/auth.service';
import { DialogCloseTaikhoanComponent } from '../dialog-close-taikhoan/dialog-close-taikhoan.component';

@Component({
    selector: 'app-sidebar',
    templateUrl: './sidebar.component.html',
    styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
    isActive: boolean;
    collapsed: boolean;
    showMenu: any;
    pushRightClass: string;

    @Output() collapsedEvent = new EventEmitter<boolean>();

    constructor(
        public router: Router,
        private dialogServiceService: DialogService,
        private webStorageSerivce: WebStorageSerivce,
        private authSerivce: AuthService,
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
        this.isActive = false;
        this.collapsed = false;
        this.showMenu = ['home', 'home1', 'home2'];
        this.pushRightClass = 'push-right';
    }


    eventCalled() {
        this.isActive = !this.isActive;
    }

    addExpandClass(element: any, index: number) {
        if (element === this.showMenu[index]) {
            this.showMenu[index] = '0';
        } else {
            this.showMenu[index] = element;
        }
    }

    toggleCollapsed() {
        this.collapsed = !this.collapsed;
        this.collapsedEvent.emit(this.collapsed);
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

    showDialogChangePassword() {
        this.dialogServiceService.showDialog(DialogDoimatkhauComponent).then(res => {
            if (res) {
                this.webStorageSerivce.clearLocalStorage();
                this.authSerivce.isLogin = false;
                this.router.navigateByUrl('/login');
            }
        });
    }

    showDialogComfrimCloseAccount() {
        this.dialogServiceService.showDialog(DialogCloseTaikhoanComponent).then(res => {
            if (res) {
                this.webStorageSerivce.clearLocalStorage();
                this.authSerivce.isLogin = false;
                this.router.navigateByUrl('/login');
            }
        });
    }
}
