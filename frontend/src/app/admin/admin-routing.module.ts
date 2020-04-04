import { AdminComponent } from './admin.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DanhsachtaikhoanComponent } from './danhsachtaikhoan/danhsachtaikhoan.component';
import { GiaodichchuyentienComponent } from './giaodichchuyentien/giaodichchuyentien.component';
import { LichsugiaodichComponent } from '../home/lichsugiaodich/lichsugiaodich.component';
import { LichsutaikhoanComponent } from './lichsutaikhoan/lichsutaikhoan.component';
const routes: Routes = [
    {
        path: '',
        component: AdminComponent,
        children: [
            { path: '', redirectTo: 'list-account', pathMatch: 'full' },
            { path: 'list-account', component: DanhsachtaikhoanComponent},
            { path: 'money-transactions', component: GiaodichchuyentienComponent },
            { path: 'history-transactions', component: LichsutaikhoanComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule {}
