import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';

@Component({
  selector: 'app-dialog-lienketnganhang',
  templateUrl: './dialog-lienketnganhang.component.html',
  styleUrls: ['./dialog-lienketnganhang.component.scss']
})
export class DialogLienketnganhangComponent implements OnInit {
  public form: NgForm;
  public nganHangLienKetModel = {
    tenNganHang: '',
    secretKey: '',
    publicKey: '',
  };
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    public taikhoanService: TaikhoanthanhtoanService
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
  }

  onSubmit() {
    this.taikhoanService.themNganHangLienKet(this.nganHangLienKetModel).subscribe(res => {
      if (res) {
        this.modal.close(true);
      }
    });
  }

}
