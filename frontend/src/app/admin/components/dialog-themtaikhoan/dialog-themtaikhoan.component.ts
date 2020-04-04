import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-dialog-themtaikhoan',
  templateUrl: './dialog-themtaikhoan.component.html',
  styleUrls: ['./dialog-themtaikhoan.component.scss']
})
export class DialogThemtaikhoanComponent implements OnInit {
  public formthemtk: NgForm;
  public themTaiKhoanModel = {
    tendangnhap: '',
    hoten: '',
    email: '',
    sodienthoai: ''
  };
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
  ) {
    config.backdrop = 'static';
   }

  ngOnInit() {
  }

  onSubmit() {}

}
