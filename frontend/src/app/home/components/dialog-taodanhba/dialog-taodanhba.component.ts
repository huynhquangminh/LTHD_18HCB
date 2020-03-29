import { NgForm } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { DanhBaService } from 'src/app/shared/services/danh-ba.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';

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
    soTaiKhoan: null,
    tenTaiKhoan: '',
    idNganHangLienKet: 0
  };
  public dsNganHang: any = [
    // { id: 0, name: '18HCB Bank' }
  ];
  public userInfo: any;
  constructor(
    public modal: NgbActiveModal,
    public config: NgbModalConfig,
    private danhBaService: DanhBaService,
    private webStorageSerivce: WebStorageSerivce,
    private taikhoanService: TaikhoanthanhtoanService
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDSNganHangLienKet();
    if (this.data) {
      this.formNewsPhoneBookModel = Object.assign({}, this.data);
    }
  }

  getDSNganHangLienKet() {
    this.danhBaService.getDsNganHangLienKet().subscribe(res => {
      if (res) {
        this.dsNganHang = res;
      }
    });
  }

  getThongTinTaiKhoan() {
    if (this.formNewsPhoneBookModel.soTaiKhoan) {
      this.taikhoanService.getThongTinTaiKhoanBySoTaiKhoan(this.formNewsPhoneBookModel.soTaiKhoan.toString()).subscribe(res => {
        if (res) {
          this.formNewsPhoneBookModel.tenTaiKhoan = res.tenTaiKhoan;
        }
      });
    }

  }

  onSubmit() {
    if (!this.data) {
      this.formNewsPhoneBookModel.tenNganHang = this.dsNganHang.find(
        item => item.id === this.formNewsPhoneBookModel.idNganHangLienKet
      ).tenNganHang;
      this.formNewsPhoneBookModel.maTk = this.userInfo.user.maTk;
      this.formNewsPhoneBookModel.soTaiKhoan = this.formNewsPhoneBookModel.soTaiKhoan.toString();
      this.formNewsPhoneBookModel.tenGoiNho = this.formNewsPhoneBookModel.tenGoiNho ?
                                              this.formNewsPhoneBookModel.tenGoiNho :
                                              this.formNewsPhoneBookModel.tenTaiKhoan;
      this.danhBaService.themDanhBa(this.formNewsPhoneBookModel).subscribe(res => {
        if (res) {
          this.modal.close(true);
        }
      });
    } else {
      this.formNewsPhoneBookModel.soTaiKhoan = this.formNewsPhoneBookModel.soTaiKhoan.toString();
      this.formNewsPhoneBookModel.tenGoiNho = this.formNewsPhoneBookModel.tenGoiNho ?
                                              this.formNewsPhoneBookModel.tenGoiNho :
                                              this.formNewsPhoneBookModel.tenTaiKhoan;
      this.danhBaService.suaDanhBa(this.formNewsPhoneBookModel).subscribe(res => {
        if (res) {
          this.modal.close(true);
        }
      });
    }
  }

}
