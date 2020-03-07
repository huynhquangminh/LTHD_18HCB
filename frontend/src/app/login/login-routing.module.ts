import { FormsModule } from '@angular/forms';
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './login.component';
import { QuenmatkhauComponent } from './quenmatkhau/quenmatkhau.component';

const routes: Routes = [
    {
        path: '',
        component: LoginComponent
    },
    {
        path: 'forgot-password',
        component: QuenmatkhauComponent
    }
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class LoginRoutingModule {}
