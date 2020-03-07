import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogDoimatkhauComponent } from './dialog-doimatkhau.component';

describe('DialogDoimatkhauComponent', () => {
  let component: DialogDoimatkhauComponent;
  let fixture: ComponentFixture<DialogDoimatkhauComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogDoimatkhauComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogDoimatkhauComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
