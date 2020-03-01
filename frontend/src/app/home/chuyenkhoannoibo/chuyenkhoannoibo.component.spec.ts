import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ChuyenkhoannoiboComponent } from './chuyenkhoannoibo.component';

describe('ChuyenkhoannoiboComponent', () => {
  let component: ChuyenkhoannoiboComponent;
  let fixture: ComponentFixture<ChuyenkhoannoiboComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ChuyenkhoannoiboComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ChuyenkhoannoiboComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
