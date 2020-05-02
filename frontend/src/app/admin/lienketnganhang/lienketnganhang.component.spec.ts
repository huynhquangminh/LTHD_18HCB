import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LienketnganhangComponent } from './lienketnganhang.component';

describe('LienketnganhangComponent', () => {
  let component: LienketnganhangComponent;
  let fixture: ComponentFixture<LienketnganhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LienketnganhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LienketnganhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
