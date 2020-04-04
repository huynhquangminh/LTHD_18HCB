import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { CommonService } from 'src/app/shared/services/common.service';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { WebKeyStorage } from 'src/app/shared/globlas/web-key-storage';

@Component({
  selector: 'app-giaodichnoibo',
  templateUrl: './giaodichnoibo.component.html',
  styleUrls: ['./giaodichnoibo.component.scss']
})
export class GiaodichnoiboComponent implements OnInit {
  public formgiaodich: NgForm;
  public tennganhang = '18HCB Bank';
  public giaoDichModel = {
    tennguoigui: '',
    sotaikhoangui: '',
    tennguoinhan: '',
    sotaikhoan: '',
    sotiengui: null,
    noidungchuyentien: '',
    traphi: 0
  };
  userInfo: any;
  constructor(
    private taikhoanService: TaikhoanthanhtoanService,
    private commonService: CommonService,
    private webStorageSerivce: WebStorageSerivce,
    private router: Router
  ) { }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.commonService.objTaikhoan.subscribe(res => {
      if (res) {
        this.giaoDichModel.tennguoigui = res.tenTaiKhoan;
        this.giaoDichModel.sotaikhoangui = res.soTaiKhoan;
      }
    });
  }

  thongtintaikhoagui() {
    if (this.giaoDichModel.sotaikhoan) {
      this.taikhoanService.getThongTinTaiKhoanBySoTaiKhoan(this.giaoDichModel.sotaikhoan).subscribe(res => {
        if (res) {
          this.giaoDichModel.tennguoinhan = res.tenTaiKhoan;
        }
      });
    }
  }

  onSubmitThongTin() {
    if (this.giaoDichModel.sotiengui > 100000) {
      const params: any = {
        id: null,
        MaTk: this.userInfo.user.maTk,
        ngayGd:  new Date().toLocaleDateString(),
        stkGui: this.giaoDichModel.sotaikhoangui,
        stkNhan: this.giaoDichModel.sotaikhoan.toString(),
        soTienGui: this.giaoDichModel.sotiengui,
        noiDung: this.giaoDichModel.noidungchuyentien,
        loaiTraPhi: this.giaoDichModel.traphi ? true : false,
        trangThaiChuyenTien: false
      };
      this.taikhoanService.chuyenKhoanNoiBo(params).subscribe(res => {
        if (res) {
          const request = {
            taiKhoanGui: this.giaoDichModel.sotaikhoangui,
            taiKhoanNhan: this.giaoDichModel.sotaikhoan.toString(),
            soTienGui : this.giaoDichModel.sotiengui
          };
          this.updateThongSoDu(request);
        }
      });
    } else {
      alert('Số tiền phải lớn hơn 100,000 VND');
    }
  }

  updateThongSoDu(params) {
    this.taikhoanService.updateSoDuTaiKhoan(params).subscribe(res => {
      if (res) {
        this.router.navigateByUrl('manager/list-account');
      }
    });
  }

}
