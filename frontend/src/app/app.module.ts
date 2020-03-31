import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LanguageTranslationModule } from './shared/modules/language-translation/language-translation.module';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AuthGuard } from './shared';
import { NotfoundpageComponent } from './notfoundpage/notfoundpage.component';
import { TemplateDialogComfirmComponent } from './shared/component/template-dialog-comfirm/template-dialog-comfirm.component';
import { NgbModalModule, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { DialogErrorComponent } from './shared/component/dialog-error/dialog-error.component';
import { FormsModule } from '@angular/forms';
import { DialogDoimatkhauComponent } from './home/components/dialog-doimatkhau/dialog-doimatkhau.component';
import { AngularWebStorageModule } from 'angular-web-storage';
import { WebStorageSerivce } from './shared/services/webstorage.service';
import { DialogTaodanhbaComponent } from './home/components/dialog-taodanhba/dialog-taodanhba.component';
import { MatSelectModule } from '@angular/material/select';
import { DialogThongbaoComponent } from './shared/component/dialog-thongbao/dialog-thongbao.component';
import {MatRippleModule} from '@angular/material/core';
import { DialogThanhtoannoComponent } from './home/components/dialog-thanhtoanno/dialog-thanhtoanno.component';
@NgModule({
    imports: [
        // CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        LanguageTranslationModule,
        AppRoutingModule,
        NgbModalModule,
        FormsModule,
        AngularWebStorageModule,
        MatSelectModule,
        MatRippleModule
    ],
    declarations: [
        AppComponent,
        NotfoundpageComponent,
        TemplateDialogComfirmComponent,
        DialogErrorComponent,
        DialogDoimatkhauComponent,
        DialogTaodanhbaComponent,
        DialogThongbaoComponent,
        DialogThanhtoannoComponent
    ],
    providers: [
        AuthGuard,
        NgbModalConfig,
        WebStorageSerivce
    ],
    bootstrap: [AppComponent],
    entryComponents: [
        TemplateDialogComfirmComponent,
        DialogErrorComponent,
        DialogDoimatkhauComponent,
        DialogTaodanhbaComponent,
        DialogThongbaoComponent,
        DialogThanhtoannoComponent
    ]
})
export class AppModule { }
