import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GiaodichnoiboComponent } from './giaodichnoibo.component';

describe('GiaodichnoiboComponent', () => {
  let component: GiaodichnoiboComponent;
  let fixture: ComponentFixture<GiaodichnoiboComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GiaodichnoiboComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GiaodichnoiboComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
