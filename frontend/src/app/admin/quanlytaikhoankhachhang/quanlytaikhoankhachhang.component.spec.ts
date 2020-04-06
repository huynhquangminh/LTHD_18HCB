import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanlytaikhoankhachhangComponent } from './quanlytaikhoankhachhang.component';

describe('QuanlytaikhoankhachhangComponent', () => {
  let component: QuanlytaikhoankhachhangComponent;
  let fixture: ComponentFixture<QuanlytaikhoankhachhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanlytaikhoankhachhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanlytaikhoankhachhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
