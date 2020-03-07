import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-dialog-doimatkhau',
  templateUrl: './dialog-doimatkhau.component.html',
  styleUrls: ['./dialog-doimatkhau.component.scss']
})
export class DialogDoimatkhauComponent implements OnInit {
  public changePassword: NgForm;
  public changePassModel = {
    matk: '',
    tendangnhap: '',
    matkhau: '',
    matkhaumoi: ''
  };
  constructor(public modal: NgbActiveModal, config: NgbModalConfig) {
    config.backdrop = 'static';
   }

  ngOnInit() {
  }

  onSubmit() {}

}
