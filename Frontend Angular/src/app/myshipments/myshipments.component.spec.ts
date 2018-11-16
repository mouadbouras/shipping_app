import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { MyshipmentsComponent } from './myshipments.component';

describe('MyshipmentsComponent', () => {
  let component: MyshipmentsComponent;
  let fixture: ComponentFixture<MyshipmentsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ MyshipmentsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(MyshipmentsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
