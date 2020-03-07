import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-quenmatkhau',
  templateUrl: './quenmatkhau.component.html',
  styleUrls: ['./quenmatkhau.component.scss']
})
export class QuenmatkhauComponent implements OnInit {
  public forgotPassword: NgForm;
  public modelForgotPassword = {
    matk: '',
    tendangnhap: '',
    email: ''
  };
  public codeOTP = '';
  public isCodeOTP = false;
  public isCheckCodeOTP = true;
  constructor() { }

  ngOnInit() {
  }

  onSubmit() {
  }

  getCodeOTP() {
    this.isCodeOTP = true;
    this.isCheckCodeOTP = true;
  }

}
