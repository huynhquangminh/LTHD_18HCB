import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaikhoantietkiemComponent } from './taikhoantietkiem.component';

describe('TaikhoantietkiemComponent', () => {
  let component: TaikhoantietkiemComponent;
  let fixture: ComponentFixture<TaikhoantietkiemComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaikhoantietkiemComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaikhoantietkiemComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
