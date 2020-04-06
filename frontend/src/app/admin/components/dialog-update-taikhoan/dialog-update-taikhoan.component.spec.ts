import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogUpdateTaikhoanComponent } from './dialog-update-taikhoan.component';

describe('DialogUpdateTaikhoanComponent', () => {
  let component: DialogUpdateTaikhoanComponent;
  let fixture: ComponentFixture<DialogUpdateTaikhoanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogUpdateTaikhoanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogUpdateTaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
