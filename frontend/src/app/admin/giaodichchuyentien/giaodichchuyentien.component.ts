import { LienketnganhangkhacService } from 'src/app/shared/services/lienketnganhangkhac.service';
import { WebStorageSerivce } from './../../shared/services/webstorage.service';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { NganhanglienketService } from 'src/app/shared/services/nganhanglienket.service';
import { DanhBaService } from 'src/app/shared/services/danh-ba.service';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import * as moment from 'moment';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';

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
    private taiKhoanService: TaikhoanthanhtoanService,
    private webStorageSerivce: WebStorageSerivce,
    private lienKetNganHangKhacService: LienketnganhangkhacService
  ) { }

  ngOnInit() {
    this.getDSNganHangLienKet();
    const nganhangLKInfo = this.webStorageSerivce.getSessionStorage(WebKeyStorage.token_nganhanglienket);
    if (!nganhangLKInfo) {
      this.lienKetNganHangKhacService.getTokenNhom9().subscribe(res => {
        if (res && res.auth) {
          this.webStorageSerivce.setSessionStorage(WebKeyStorage.token_nganhanglienket, {token_nhom9: res.access_token});
        }
      });
    }
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
    if (this.giaoDichModel.sotaikhoannhan && this.giaoDichModel.sotaikhoannhan.toString().length >= 9
        && this.giaoDichModel.tennganhangnhan !== '--- Tên ngân hàng ---') {
      const timeNow = moment(new Date()).format('YYYYMMDDHHmmss');
      const textStr = this.giaoDichModel.sotaikhoannhan.toString() + timeNow + 'nhom21';
      this.nganHangLKService.getHashString(textStr).subscribe(res => {
        if (res) {
          const params = {
            soTk: this.giaoDichModel.sotaikhoannhan.toString(),
            timer: timeNow,
            hashCode: res
          };
          this.lienKetNganHangKhacService.getThongTinTaiKhoan(params).subscribe(result => {
            if (result) {
              this.giaoDichModel.tennguoinhan = result.ten;
            }
          });
        }
      });
    } else {
      this.giaoDichModel.tennguoinhan = '';
    }
  }

  onSubmitThongTin() {
    if (this.giaoDichModel.sotiengui > 100000) {
      this.nganHangLKService.getSignData().subscribe(res => {
        if (res) {
          const params = {
            tenNganHangGui: '18HCB BANK',
            soTaiKhoanGui: this.giaoDichModel.sotaikhoangui.toString(),
            soTaiKhoanNhan: this.giaoDichModel.sotaikhoannhan.toString(),
            tenNguoiNhan: this.giaoDichModel.tennguoinhan,
            tenNguoiGui: this.giaoDichModel.tennguoigui,
            soTienChuyen: this.giaoDichModel.sotiengui.toString(),
            ngayTao: moment(new Date()).format('YYYY-MM-DD'),
            noiDung: this.giaoDichModel.noidungchuyentien,
            signature: res
          };
          this.lienKetNganHangKhacService.giaoDichTaiKhoanKhachNganHang(params).subscribe(result => {
            if (result.status) {
              this.luuThongTinGiaoDich();
            }
          });
        }
      });
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

  luuThongTinGiaoDich() {
    const params = {
      soTKGui: this.giaoDichModel.sotaikhoangui.toString(),
      tenNganHangGui: '18HCB BANK',
      soTKNhan: this.giaoDichModel.sotaikhoannhan.toString(),
      tenNganHangNhan: this.giaoDichModel.tennganhangnhan,
      soTien: this.giaoDichModel.sotiengui,
      noiDung: this.giaoDichModel.noidungchuyentien,
      ngayTao: moment(new Date()).format('YYYY-MM-DD'),
    };
    this.nganHangLKService.luuGiaoDichKhacNganHang(params).subscribe(res => {
      if (res) {
        alert('chuyen tien thanh cong');
      }
    });
  }

}
