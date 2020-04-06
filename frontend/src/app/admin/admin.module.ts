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
import { FormsModule } from '@angular/forms';
import { LichsutaikhoanComponent } from './lichsutaikhoan/lichsutaikhoan.component';
import { GiaodichnoiboComponent } from './giaodichnoibo/giaodichnoibo.component';
import { MatRadioModule } from '@angular/material/radio';
import { QuanlytaikhoankhachhangComponent } from './quanlytaikhoankhachhang/quanlytaikhoankhachhang.component';
import { QuanlytaikhoannhanvienComponent } from './quanlytaikhoannhanvien/quanlytaikhoannhanvien.component';
import { QuanlygiaodichComponent } from './quanlygiaodich/quanlygiaodich.component';

@NgModule({
  declarations: [
    AdminComponent,
    SidebarComponent,
    HeaderComponent,
    DanhsachtaikhoanComponent,
    GiaodichchuyentienComponent,
    LichsutaikhoanComponent,
    GiaodichnoiboComponent,
    QuanlytaikhoankhachhangComponent,
    QuanlytaikhoannhanvienComponent,
    QuanlygiaodichComponent
  ],
  imports: [
    CommonModule,
    AdminRoutingModule,
    NgbDropdownModule,
    TranslateModule,
    NgbModule,
    FormsModule,
    MatRadioModule,
  ]
})
export class AdminModule { }
