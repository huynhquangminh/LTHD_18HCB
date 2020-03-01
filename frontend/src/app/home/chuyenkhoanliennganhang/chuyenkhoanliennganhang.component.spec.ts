import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChuyenkhoanliennganhangComponent } from './chuyenkhoanliennganhang.component';

describe('ChuyenkhoanliennganhangComponent', () => {
  let component: ChuyenkhoanliennganhangComponent;
  let fixture: ComponentFixture<ChuyenkhoanliennganhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChuyenkhoanliennganhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChuyenkhoanliennganhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
