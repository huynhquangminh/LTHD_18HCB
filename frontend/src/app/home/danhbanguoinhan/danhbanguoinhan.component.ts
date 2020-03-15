import { Component, OnInit } from '@angular/core';
import { WebStorageSerivce } from 'src/app/shared/services/webstorage.service';
import { DialogService } from 'src/app/shared/services/dialog-service.service';

@Component({
  selector: 'app-danhbanguoinhan',
  templateUrl: './danhbanguoinhan.component.html',
  styleUrls: ['./danhbanguoinhan.component.scss']
})
export class DanhbanguoinhanComponent implements OnInit {

  constructor(
    private webStorageSerivce: WebStorageSerivce,
    private dialogService: DialogService
  ) { }

  ngOnInit() {
  }

  xoaDanhBa() {
    this.dialogService.showDialogComfirm('Bạn có muốn xóa khỏi danh bạ không!').then(res => {
      if (res) {
        //  api delete
      }
    });
  }

  suaDanhBa() {

  }

  taoMoiDanhBa() {

  }

}
