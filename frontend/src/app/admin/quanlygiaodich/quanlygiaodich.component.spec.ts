import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanlygiaodichComponent } from './quanlygiaodich.component';

describe('QuanlygiaodichComponent', () => {
  let component: QuanlygiaodichComponent;
  let fixture: ComponentFixture<QuanlygiaodichComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanlygiaodichComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanlygiaodichComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
