import { Component, OnInit } from '@angular/core';
import { DialogServiceService } from 'src/app/shared/services/dialog-service.service';

@Component({
  selector: 'app-taikhoanthanhtoan',
  templateUrl: './taikhoanthanhtoan.component.html',
  styleUrls: ['./taikhoanthanhtoan.component.scss']
})
export class TaikhoanthanhtoanComponent implements OnInit {

  constructor(private dialogServiceService: DialogServiceService) { }

  ngOnInit() {
  }

  open() {
    this.dialogServiceService.showDialogError('xxxxxxxxxxxxx');
  }

}
