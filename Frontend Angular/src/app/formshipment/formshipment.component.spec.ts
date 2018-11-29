import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FormshipmentComponent } from './formshipment.component';

describe('FormshipmentComponent', () => {
  let component: FormshipmentComponent;
  let fixture: ComponentFixture<FormshipmentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FormshipmentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FormshipmentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
