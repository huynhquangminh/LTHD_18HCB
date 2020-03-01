import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateDialogComfirmComponent } from './template-dialog-comfirm.component';

describe('TemplateDialogComfirmComponent', () => {
  let component: TemplateDialogComfirmComponent;
  let fixture: ComponentFixture<TemplateDialogComfirmComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateDialogComfirmComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateDialogComfirmComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
