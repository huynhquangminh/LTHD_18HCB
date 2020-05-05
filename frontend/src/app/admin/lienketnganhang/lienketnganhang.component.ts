import { Component, OnInit } from '@angular/core';
import { TaikhoanthanhtoanService } from 'src/app/shared/services/taikhoanthanhtoan.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';
import { DialogLienketnganhangComponent } from 'src/app/admin/components/dialog-lienketnganhang/dialog-lienketnganhang.component';

@Component({
  selector: 'app-lienketnganhang',
  templateUrl: './lienketnganhang.component.html',
  styleUrls: ['./lienketnganhang.component.scss']
})
export class LienketnganhangComponent implements OnInit {
  public listNganHangLienKet: any = [];
  constructor(
    private taiKhoanService: TaikhoanthanhtoanService,
    private dialogService: DialogService,
  ) { }

  ngOnInit() {
    this.getDanhSachNganHangLienKet();
  }

  getDanhSachNganHangLienKet() {
    this.taiKhoanService.getDanhSachNganHangLienKet().subscribe(res => {
      if (res) {
        this.listNganHangLienKet = res.filter(item => {
          return item.id !== 0;
        });
      }
    });
  }

  taoLienKet() {
    this.dialogService.showDialog(DialogLienketnganhangComponent).then(res => {
      if (res) {
        this.getDanhSachNganHangLienKet();
      }
    });
   }
}
