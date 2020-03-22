import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HomeComponent } from './home.component';
import { HomeRoutingModule } from './home-routing.module';
import { SidebarComponent } from './components/sidebar/sidebar.component';
import { HeaderComponent } from './components/header/header.component';
import { NgbDropdownModule, NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { TranslateModule } from '@ngx-translate/core';
import { TaikhoanthanhtoanComponent } from './taikhoanthanhtoan/taikhoanthanhtoan.component';
import { TaikhoantietkiemComponent } from './taikhoantietkiem/taikhoantietkiem.component';
import { DanhbanguoinhanComponent } from './danhbanguoinhan/danhbanguoinhan.component';
import { ChuyenkhoannoiboComponent } from './chuyenkhoannoibo/chuyenkhoannoibo.component';
import { ChuyenkhoanliennganhangComponent } from './chuyenkhoanliennganhang/chuyenkhoanliennganhang.component';
import {MatIconModule} from '@angular/material/icon';
import {MatBadgeModule} from '@angular/material/badge';
import {MatTabsModule} from '@angular/material/tabs';
import { FormsModule } from '@angular/forms';
import {MatFormFieldModule} from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatRadioModule} from '@angular/material/radio';
import {MatMenuModule} from '@angular/material/menu';
@NgModule({
  declarations: [
    HomeComponent,
    SidebarComponent,
    HeaderComponent,
    TaikhoanthanhtoanComponent,
    TaikhoantietkiemComponent,
    DanhbanguoinhanComponent,
    ChuyenkhoannoiboComponent,
    ChuyenkhoanliennganhangComponent,
  ],
  imports: [
    CommonModule,
    HomeRoutingModule,
    NgbDropdownModule,
    TranslateModule,
    NgbModule,
    MatIconModule,
    MatBadgeModule,
    MatTabsModule,
    FormsModule,
    MatFormFieldModule,
    MatInputModule,
    MatRadioModule,
    MatMenuModule
  ],
})
export class HomeModule { }
