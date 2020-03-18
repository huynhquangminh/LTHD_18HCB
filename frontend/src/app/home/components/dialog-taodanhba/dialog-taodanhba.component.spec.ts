import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogTaodanhbaComponent } from './dialog-taodanhba.component';

describe('DialogTaodanhbaComponent', () => {
  let component: DialogTaodanhbaComponent;
  let fixture: ComponentFixture<DialogTaodanhbaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogTaodanhbaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogTaodanhbaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
