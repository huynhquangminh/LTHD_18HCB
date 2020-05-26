import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogCloseTaikhoanComponent } from './dialog-close-taikhoan.component';

describe('DialogCloseTaikhoanComponent', () => {
  let component: DialogCloseTaikhoanComponent;
  let fixture: ComponentFixture<DialogCloseTaikhoanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogCloseTaikhoanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogCloseTaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
