import { NgForm } from '@angular/forms';
import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { QuanlyService } from 'src/app/shared/services/quanly.service';

@Component({
  selector: 'app-dialog-taikhoan-nhanvien',
  templateUrl: './dialog-taikhoan-nhanvien.component.html',
  styleUrls: ['./dialog-taikhoan-nhanvien.component.scss']
})
export class DialogTaikhoanNhanvienComponent implements OnInit {
  @Input() data = null;
  public formTKNV: NgForm;
  public themTaiKhoanModel = {
    tendangnhap: '',
    tennhanvien: '',
    email: '',
    cmnd: null,
    sodienthoai: null,
    diachi: ''
  };
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    private quanlyService: QuanlyService
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
  }

  onSubmit() {
    const params = {
      tenDangNhap: this.themTaiKhoanModel.tendangnhap,
      tenNhanVien: this.themTaiKhoanModel.tennhanvien.toUpperCase(),
      cmnd: this.themTaiKhoanModel.cmnd.toString(),
      sdt: this.themTaiKhoanModel.sodienthoai.toString(),
      email: this.themTaiKhoanModel.email,
      diaChi: this.themTaiKhoanModel.diachi
    };
    this.quanlyService.themTaiKhoanNhanVien(params).subscribe(res => {
      if (res) {
        this.modal.close(true);
      }
    });
  }

}
