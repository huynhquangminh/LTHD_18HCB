import { NgForm } from '@angular/forms';
import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-chuyenkhoannoibo',
  templateUrl: './chuyenkhoannoibo.component.html',
  styleUrls: ['./chuyenkhoannoibo.component.scss']
})
export class ChuyenkhoannoiboComponent implements OnInit {
  public cknoiboform: NgForm;
  public indexTab = 0;
  public codeOTP = null;
  public chuyenkhoanModel: any = {
    tennguoinhan: '',
    sotaikhoan: null,
    sotiengui: null,
    noidungchuyentien: '',
    traphi: 0
  };

  public listDanhBaModel: any[] = [
    {
      tendanhba: 'Minh',
      sotaikhoan: 4324234421423,
      tentaikhoan: 'Minh Huynh'
    },
    {
      tendanhba: 'Minh',
      sotaikhoan: 4324234421423,
      tentaikhoan: 'Minh Huynh'
    },
    {
      tendanhba: 'Minh',
      sotaikhoan: 4324234421423,
      tentaikhoan: 'Minh Huynh'
    },
    {
      tendanhba: 'Minh',
      sotaikhoan: 4324234421423,
      tentaikhoan: 'Minh Huynh'
    }
  ];
  public tennganhang = '18HCB BANK';
  constructor() { }

  ngOnInit() {
  }

  onSubmitThongTin() {
    this.indexTab = 1;
  }

  chondanhba(item) {
    this.chuyenkhoanModel.tennguoinhan = item.tentaikhoan;
    this.chuyenkhoanModel.sotaikhoan = item.sotaikhoan;
  }

  back() {
    this.indexTab = 0;
  }

  xacnhan() {

  }
}
