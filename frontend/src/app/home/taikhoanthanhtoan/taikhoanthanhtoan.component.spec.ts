import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TaikhoanthanhtoanComponent } from './taikhoanthanhtoan.component';

describe('TaikhoanthanhtoanComponent', () => {
  let component: TaikhoanthanhtoanComponent;
  let fixture: ComponentFixture<TaikhoanthanhtoanComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TaikhoanthanhtoanComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TaikhoanthanhtoanComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
