import { Injectable } from '@angular/core';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';
import { TemplateDialogComfirmComponent } from '../component/template-dialog-comfirm/template-dialog-comfirm.component';
@Injectable({
  providedIn: 'root'
})
export class DialogService {

  constructor(private modalService: NgbModal) { }


  showDialogError(message: string) {
    const dialogRef = this.modalService.open(TemplateDialogComfirmComponent);
    dialogRef.componentInstance.textContent = message;
  }

  showDialogComfirm(message: string) {
    const dialogRef = this.modalService.open(TemplateDialogComfirmComponent);
    dialogRef.componentInstance.textContent = message;
    dialogRef.componentInstance.isDialogComfirm = true;
    return dialogRef.result.then(res => {
      if (res) {
        return true;
      } else {
        return false;
      }
    });
  }

  showDialog(nameComponent: any, data: any = null) {
    const dialogRef = this.modalService.open(nameComponent);
    if (data) {
      dialogRef.componentInstance.data = data;
    }
    return dialogRef.result.then(res => {
      if (res) {
        return true;
      } else {
        return false;
      }
    });
  }
}
