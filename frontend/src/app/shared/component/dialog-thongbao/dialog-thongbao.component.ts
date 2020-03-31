import { Component, OnInit } from '@angular/core';
import { NgbActiveModal, NgbModalConfig } from '@ng-bootstrap/ng-bootstrap';
import { ThongBaoService } from '../../services/thong-bao.service';
import { WebStorageSerivce } from '../../services/webstorage.service';
import { WebKeyStorage } from '../../globlas/web-key-storage';

@Component({
  selector: 'app-dialog-thongbao',
  templateUrl: './dialog-thongbao.component.html',
  styleUrls: ['./dialog-thongbao.component.scss']
})
export class DialogThongbaoComponent implements OnInit {
  public listThongBao: any = [];
  userInfo: any;
  constructor(
    public modal: NgbActiveModal,
    config: NgbModalConfig,
    private thongBaoService: ThongBaoService,
    private webStorageSerivce: WebStorageSerivce
  ) {
    config.backdrop = 'static';
  }

  ngOnInit() {
    this.userInfo = this.webStorageSerivce.getLocalStorage(WebKeyStorage.user_info);
    this.getDSThongBao(this.userInfo.user.maTk);
  }

  getDSThongBao(matk: string) {
    this.thongBaoService.getThongBaoUser(matk).subscribe(res => {
      if (res) {
        this.listThongBao = res;
      }
    });
  }

  updateThongBao(item) {
    if (!item.trangThai) {
      this.thongBaoService.updateThongBao(item.id).subscribe(res => {
        if (res) {
          this.getDSThongBao(this.userInfo.user.maTk);
        }
      });
    }

  }

}
