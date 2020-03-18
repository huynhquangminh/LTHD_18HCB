import { NgForm } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { DanhBaService } from 'src/app/shared/services/danh-ba.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';

@Component({
  selector: 'app-dialog-taodanhba',
  templateUrl: './dialog-taodanhba.component.html',
  styleUrls: ['./dialog-taodanhba.component.scss']
})
export class DialogTaodanhbaComponent implements OnInit {
  @Input() data = null;
  public formNewsPhoneBook: NgForm;
  public formNewsPhoneBookModel = {
    id: 0,
    maTk: '',
    tenGoiNho: '',
    tenNganHang: '',
    soTaiKhoan: null
  };
  public userInfo: any;
  constructor(
    public modal: NgbActiveModal,
    public config: NgbModalConfig,
    private danhBaService: DanhBaService,
    private webStorageSerivce: WebStorageSerivce,
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    if (this.data) {
      this.formNewsPhoneBookModel = Object.assign({}, this.data);
    }
  }

  onSubmit() {
    if (!this.data) {
      this.formNewsPhoneBookModel.maTk = this.userInfo.user.maTk;
      this.formNewsPhoneBookModel.soTaiKhoan = this.formNewsPhoneBookModel.soTaiKhoan.toString();
      this.danhBaService.themDanhBa(this.formNewsPhoneBookModel).subscribe(res => {
        if (res) {
          this.modal.close(true);
        }
      });
    } else {
      this.formNewsPhoneBookModel.soTaiKhoan = this.formNewsPhoneBookModel.soTaiKhoan.toString();
      this.danhBaService.suaDanhBa(this.formNewsPhoneBookModel).subscribe(res => {
        if (res) {
          this.modal.close(true);
        }
      });
    }
  }

}
