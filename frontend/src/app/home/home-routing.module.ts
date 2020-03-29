import { ChuyenkhoanliennganhangComponent } from './chuyenkhoanliennganhang/chuyenkhoanliennganhang.component';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home.component';
import { TaikhoanthanhtoanComponent } from './taikhoanthanhtoan/taikhoanthanhtoan.component';
import { TaikhoantietkiemComponent } from './taikhoantietkiem/taikhoantietkiem.component';
import { DanhbanguoinhanComponent } from './danhbanguoinhan/danhbanguoinhan.component';
import { ChuyenkhoannoiboComponent } from './chuyenkhoannoibo/chuyenkhoannoibo.component';
import { LichsugiaodichComponent } from './lichsugiaodich/lichsugiaodich.component';
const routes: Routes = [
    {
        path: '',
        component: HomeComponent,
        children: [
            { path: '', redirectTo: 'payment-account', pathMatch: 'full' },
            { path: 'payment-account', component: TaikhoanthanhtoanComponent},
            { path: 'saving-account', component: TaikhoantietkiemComponent },
            { path: 'recipient-contacts', component: DanhbanguoinhanComponent },
            { path: 'internal-transfer', component: ChuyenkhoannoiboComponent },
            { path: 'interbank-transfer', component: ChuyenkhoanliennganhangComponent },
            { path: 'transaction-history', component: LichsugiaodichComponent },
            // { path: 'grid', loadChildren: () => import('./grid/grid.module').then(m => m.GridModule) },
            // { path: 'components', loadChildren: () => import('./bs-component/bs-component.module').then(m => m.BsComponentModule) },
            // { path: 'blank-page', loadChildren: () => import('./blank-page/blank-page.module').then(m => m.BlankPageModule) }
        ]
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class HomeRoutingModule {}
