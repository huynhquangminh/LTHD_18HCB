import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogThemtaikhoanComponent } from './dialog-themtaikhoan.component';

describe('DialogThemtaikhoanComponent', () => {
  let component: DialogThemtaikhoanComponent;
  let fixture: ComponentFixture<DialogThemtaikhoanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogThemtaikhoanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogThemtaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
