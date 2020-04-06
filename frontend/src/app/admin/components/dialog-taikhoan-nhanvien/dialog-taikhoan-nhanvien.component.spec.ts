import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogTaikhoanNhanvienComponent } from './dialog-taikhoan-nhanvien.component';

describe('DialogTaikhoanNhanvienComponent', () => {
  let component: DialogTaikhoanNhanvienComponent;
  let fixture: ComponentFixture<DialogTaikhoanNhanvienComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogTaikhoanNhanvienComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogTaikhoanNhanvienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
