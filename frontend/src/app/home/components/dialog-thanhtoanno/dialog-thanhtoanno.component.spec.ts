import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogThanhtoannoComponent } from './dialog-thanhtoanno.component';

describe('DialogThanhtoannoComponent', () => {
  let component: DialogThanhtoannoComponent;
  let fixture: ComponentFixture<DialogThanhtoannoComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogThanhtoannoComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogThanhtoannoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
