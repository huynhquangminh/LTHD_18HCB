import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbDropdownModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { TaikhoanthanhtoanComponent } from './taikhoanthanhtoan/taikhoanthanhtoan.component';
import { TaikhoantietkiemComponent } from './taikhoantietkiem/taikhoantietkiem.component';
import { DanhbanguoinhanComponent } from './danhbanguoinhan/danhbanguoinhan.component';
import { ChuyenkhoannoiboComponent } from './chuyenkhoannoibo/chuyenkhoannoibo.component';
import { ChuyenkhoanliennganhangComponent } from './chuyenkhoanliennganhang/chuyenkhoanliennganhang.component';

@NgModule({
  declarations: [
    HomeComponent,
    SidebarComponent,
    HeaderComponent,
    TaikhoanthanhtoanComponent,
    TaikhoantietkiemComponent,
    DanhbanguoinhanComponent,
    ChuyenkhoannoiboComponent,
    ChuyenkhoanliennganhangComponent
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    NgbDropdownModule,
    TranslateModule,
  ]
})
export class HomeModule { }
