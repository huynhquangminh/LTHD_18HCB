import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { QuanlytaikhoannhanvienComponent } from './quanlytaikhoannhanvien.component';

describe('QuanlytaikhoannhanvienComponent', () => {
  let component: QuanlytaikhoannhanvienComponent;
  let fixture: ComponentFixture<QuanlytaikhoannhanvienComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ QuanlytaikhoannhanvienComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(QuanlytaikhoannhanvienComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
