import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogThongbaoComponent } from './dialog-thongbao.component';

describe('DialogThongbaoComponent', () => {
  let component: DialogThongbaoComponent;
  let fixture: ComponentFixture<DialogThongbaoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogThongbaoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogThongbaoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
