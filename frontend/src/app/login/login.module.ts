import { BrowserModule } from '@angular/platform-browser';
import { FormModule } from './../layout/form/form.module';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { RecaptchaModule } from 'ng-recaptcha';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { QuenmatkhauComponent } from './quenmatkhau/quenmatkhau.component';
import { FormsModule } from '@angular/forms';

@NgModule({
    imports: [
        // BrowserModule,
        FormsModule,
        CommonModule,
        TranslateModule,
        LoginRoutingModule,
        RecaptchaModule
    ],
    declarations: [LoginComponent, QuenmatkhauComponent]
})
export class LoginModule {}
