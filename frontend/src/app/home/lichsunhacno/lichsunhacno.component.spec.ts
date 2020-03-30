import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LichsunhacnoComponent } from './lichsunhacno.component';

describe('LichsunhacnoComponent', () => {
  let component: LichsunhacnoComponent;
  let fixture: ComponentFixture<LichsunhacnoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LichsunhacnoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LichsunhacnoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
