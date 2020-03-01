import { CommonModule } from '@angular/common';
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
import { DialogServiceService } from './shared/services/dialog-service.service';
import { NgbModalModule, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';
import { DialogErrorComponent } from './shared/component/dialog-error/dialog-error.component';

@NgModule({
    imports: [
        CommonModule,
        BrowserModule,
        BrowserAnimationsModule,
        HttpClientModule,
        LanguageTranslationModule,
        AppRoutingModule,
        NgbModalModule
    ],
    declarations: [
        AppComponent,
        NotfoundpageComponent,
        TemplateDialogComfirmComponent,
        DialogErrorComponent
    ],
    providers: [AuthGuard],
    bootstrap: [AppComponent],
    entryComponents: [
        TemplateDialogComfirmComponent,
        DialogErrorComponent]
})
export class AppModule { }
