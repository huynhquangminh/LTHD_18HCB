import { Component, OnInit, Input } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { QuanlyService } from 'src/app/shared/services/quanly.service';

@Component({
  selector: 'app-dialog-update-taikhoan',
  templateUrl: './dialog-update-taikhoan.component.html',
  styleUrls: ['./dialog-update-taikhoan.component.scss']
})
export class DialogUpdateTaikhoanComponent implements OnInit {
  @Input() data = null;
  public formthemtk: NgForm;
  public themTaiKhoanModel = {
    email: '',
    sodienthoai: ''
  };
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    private quanlyService: QuanlyService
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
    this.themTaiKhoanModel.email = this.data.email;
    this.themTaiKhoanModel.sodienthoai = this.data.sdt;
  }

  onSubmit() {
    const params = {
      id: this.data.id,
      email: this.themTaiKhoanModel.email,
      sdt: this.themTaiKhoanModel.sodienthoai.toString()
    };
    this.quanlyService.updateThongTinTaiKhoanKhachHang(params).subscribe(res => {
      if (res) {
        this.modal.close(true);
      }
    })
  }

}
