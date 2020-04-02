import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AdminComponent } from './admin.component';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './components/header/header.component';
import { DanhsachtaikhoanComponent } from './danhsachtaikhoan/danhsachtaikhoan.component';
import { GiaodichchuyentienComponent } from './giaodichchuyentien/giaodichchuyentien.component';
import { AdminRoutingModule } from './admin-routing.module';
import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';

@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    HeaderComponent,
    DanhsachtaikhoanComponent,
    GiaodichchuyentienComponent,
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbDropdownModule,
    TranslateModule,
    NgbModule,
  ]
})
export class AdminModule { }
