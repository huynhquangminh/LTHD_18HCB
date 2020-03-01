import { Component, OnInit, Input } from '@angular/core';
import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-template-dialog-comfirm',
  templateUrl: './template-dialog-comfirm.component.html',
  styleUrls: ['./template-dialog-comfirm.component.scss']
})
export class TemplateDialogComfirmComponent implements OnInit {

  @Input() textContent;
  constructor(public modal: NgbActiveModal) { }

  ngOnInit() {
  }
}
