import { Injectable } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { TemplateDialogComfirmComponent } from '../component/template-dialog-comfirm/template-dialog-comfirm.component';
@Injectable({
  providedIn: 'root'
})
export class DialogServiceService {

  constructor(private modalService: NgbModal) { }


  showDialogError(message: string) {
    const dialogRef = this.modalService.open(TemplateDialogComfirmComponent);
    dialogRef.componentInstance.textContent = message;
  }
}
