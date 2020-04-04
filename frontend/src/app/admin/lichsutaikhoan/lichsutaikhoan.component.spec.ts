import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LichsutaikhoanComponent } from './lichsutaikhoan.component';

describe('LichsutaikhoanComponent', () => {
  let component: LichsutaikhoanComponent;
  let fixture: ComponentFixture<LichsutaikhoanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LichsutaikhoanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LichsutaikhoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
