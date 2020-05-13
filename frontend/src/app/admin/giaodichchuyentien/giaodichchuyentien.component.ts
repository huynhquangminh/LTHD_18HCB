import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NganhanglienketService } from 'src/app/shared/services/nganhanglienket.service';
import { DanhBaService } from 'src/app/shared/services/danh-ba.service';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import * as moment from 'moment';

@Component({
  selector: 'app-giaodichchuyentien',
  templateUrl: './giaodichchuyentien.component.html',
  styleUrls: ['./giaodichchuyentien.component.scss']
})
export class GiaodichchuyentienComponent implements OnInit {
  public formgiaodich: NgForm;
  public giaoDichModel = {
    tennguoigui: '',
    sotaikhoangui: '',
    tennganhanggui: '18HCB BANK',
    tennguoinhan: '',
    sotaikhoannhan: '',
    tennganhangnhan: '--- Tên ngân hàng ---',
    sotiengui: null,
    noidungchuyentien: ''
  };

  public dsNganHang = [];
  constructor(
    private nganHangLKService: NganhanglienketService,
    private danhBaService: DanhBaService,
    private taiKhoanService: TaikhoanthanhtoanService
  ) { }

  ngOnInit() {
    this.getDSNganHangLienKet();
  }

  thongtintaikhoangui() {
    if (this.giaoDichModel.sotaikhoangui) {
      this.taiKhoanService.getThongTinTaiKhoanBySoTaiKhoan(this.giaoDichModel.sotaikhoangui).subscribe(res => {
        if (res) {
          this.giaoDichModel.tennguoigui = res.tenTaiKhoan;
        }
      });
    }
  }

  thongtintaikhoannhan() {

  }

  onSubmitThongTin() {
    if (this.giaoDichModel.sotiengui > 100000) {

    }
  }

  giaoDichKhacNganHangAdmin() {
    const params: any = {
      soTKGui: this.giaoDichModel.sotaikhoangui.toString(),
      tenNganHangGui: this.giaoDichModel.tennganhanggui,
      soTKNhan: this.giaoDichModel.sotaikhoannhan.toString(),
      tenNganHangNhan: this.giaoDichModel.tennganhangnhan,
      soTien: this.giaoDichModel.sotiengui,
      noiDung: this.giaoDichModel.noidungchuyentien,
      ngayTao: moment(new Date()).format('YYYY-MM-DD'),
    };
    this.nganHangLKService.giaoDichKhacNganHangAdmin(params).subscribe(res => {
      if (res) {
      }
    });
  }

  getDSNganHangLienKet() {
    this.danhBaService.getDsNganHangLienKet().subscribe(res => {
      if (res) {
        this.dsNganHang = res.filter(item => {
          return item.id !== 0;
        });
        this.dsNganHang.unshift({ id: -1, tenNganHang: '--- Tên ngân hàng ---' });
      }
    });
  }

}
