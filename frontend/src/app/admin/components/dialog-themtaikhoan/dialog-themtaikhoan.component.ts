import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { NhanvienService } from 'src/app/shared/services/nhanvien.service';

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
    public nhanvienService: NhanvienService
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
  }

  onSubmit() {
    const params = {
      tenDangNhap: this.themTaiKhoanModel.tendangnhap,
      hoTen: this.themTaiKhoanModel.hoten.toUpperCase(),
      email: this.themTaiKhoanModel.email,
      sdt: this.themTaiKhoanModel.sodienthoai.toString()
    };
    this.nhanvienService.themTaiKhoanKhachHang(params).subscribe(res => {
      if (res) {
        this.modal.close(true);
      }
    });
  }

}
