import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ThemnhacnoComponent } from './themnhacno.component';

describe('ThemnhacnoComponent', () => {
  let component: ThemnhacnoComponent;
  let fixture: ComponentFixture<ThemnhacnoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ThemnhacnoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ThemnhacnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
