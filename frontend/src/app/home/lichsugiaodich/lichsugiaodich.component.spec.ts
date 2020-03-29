import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LichsugiaodichComponent } from './lichsugiaodich.component';

describe('LichsugiaodichComponent', () => {
  let component: LichsugiaodichComponent;
  let fixture: ComponentFixture<LichsugiaodichComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LichsugiaodichComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LichsugiaodichComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
