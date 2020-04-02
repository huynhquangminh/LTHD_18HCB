import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TranslateModule } from '@ngx-translate/core';
import { RecaptchaModule } from 'ng-recaptcha';
import { LoginRoutingModule } from './login-routing.module';
import { LoginComponent } from './login.component';
import { QuenmatkhauComponent } from './quenmatkhau/quenmatkhau.component';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

@NgModule({
    imports: [
        FormsModule,
        CommonModule,
        TranslateModule,
        LoginRoutingModule,
        RecaptchaModule,
        HttpClientModule
    ],
    declarations: [LoginComponent, QuenmatkhauComponent]
})
export class LoginModule {}
