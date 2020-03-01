import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DanhbanguoinhanComponent } from './danhbanguoinhan.component';

describe('DanhbanguoinhanComponent', () => {
  let component: DanhbanguoinhanComponent;
  let fixture: ComponentFixture<DanhbanguoinhanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DanhbanguoinhanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DanhbanguoinhanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
