import { AdminComponent } from './admin.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DanhsachtaikhoanComponent } from './danhsachtaikhoan/danhsachtaikhoan.component';
import { GiaodichchuyentienComponent } from './giaodichchuyentien/giaodichchuyentien.component';
import { LichsutaikhoanComponent } from './lichsutaikhoan/lichsutaikhoan.component';
import { GiaodichnoiboComponent } from './giaodichnoibo/giaodichnoibo.component';
import { QuanlytaikhoankhachhangComponent } from './quanlytaikhoankhachhang/quanlytaikhoankhachhang.component';
import { QuanlytaikhoannhanvienComponent } from './quanlytaikhoannhanvien/quanlytaikhoannhanvien.component';
import { QuanlygiaodichComponent } from './quanlygiaodich/quanlygiaodich.component';
const routes: Routes = [
    {
        path: '',
        component: AdminComponent,
        children: [
            { path: '', redirectTo: 'list-account', pathMatch: 'full' },
            { path: 'list-account', component: DanhsachtaikhoanComponent},
            { path: 'money-transactions', component: GiaodichchuyentienComponent },
            { path: 'history-transactions', component: LichsutaikhoanComponent },
            { path: 'internal-transactions', component: GiaodichnoiboComponent },
            { path: 'customer-account-management', component: QuanlytaikhoankhachhangComponent },
            { path: 'employee-account-management', component: QuanlytaikhoannhanvienComponent },
            { path: 'transaction-management', component: QuanlygiaodichComponent },
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class AdminRoutingModule {}
