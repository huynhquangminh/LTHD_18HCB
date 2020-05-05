import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { DialogLienketnganhangComponent } from './dialog-lienketnganhang.component';

describe('DialogLienketnganhangComponent', () => {
  let component: DialogLienketnganhangComponent;
  let fixture: ComponentFixture<DialogLienketnganhangComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ DialogLienketnganhangComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(DialogLienketnganhangComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
