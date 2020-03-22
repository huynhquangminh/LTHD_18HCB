import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { NgForm } from '@angular/forms';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';

@Component({
  selector: 'app-dialog-doimatkhau',
  templateUrl: './dialog-doimatkhau.component.html',
  styleUrls: ['./dialog-doimatkhau.component.scss']
})
export class DialogDoimatkhauComponent implements OnInit {
  public changePassword: NgForm;
  public changePassModel = {
    maTaiKhoan: '',
    matKhau: '',
    matkhaumoi: ''
  };
  userInfo: any;
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    private webStorageSerivce: WebStorageSerivce,
    private taikhoanService: TaikhoanthanhtoanService
    ) {
    config.backdrop = 'static';
   }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
  }

  onSubmit() {
    this.changePassModel.maTaiKhoan = this.userInfo.user.maTk;
    this.taikhoanService.doiMatKhau(this.changePassModel).subscribe(res => {
      if (res) {
        this.modal.close(true);
      }
    });
  }

}
