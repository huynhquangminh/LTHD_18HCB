import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GiaodichchuyentienComponent } from './giaodichchuyentien.component';

describe('GiaodichchuyentienComponent', () => {
  let component: GiaodichchuyentienComponent;
  let fixture: ComponentFixture<GiaodichchuyentienComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GiaodichchuyentienComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GiaodichchuyentienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
