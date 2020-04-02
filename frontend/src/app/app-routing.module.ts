import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared';
import { NotfoundpageComponent } from './notfoundpage/notfoundpage.component';
import { CanActiveGuardService } from './shared/services/guard/can-active-guard.service';

const routes: Routes = [
    { path: '',  redirectTo: 'login', pathMatch: 'full' },
    { path: 'home', loadChildren: () => import('./home/home.module').then(m => m.HomeModule), canActivate: [CanActiveGuardService]  },
    { path: 'login', loadChildren: () => import('./login/login.module').then(m => m.LoginModule) },
    { path: '**', component: NotfoundpageComponent },
];

@NgModule({
    imports: [RouterModule.forRoot(routes)],
    exports: [RouterModule]
})
export class AppRoutingModule {}
