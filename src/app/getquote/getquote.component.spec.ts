import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetquoteComponent } from './getquote.component';

describe('GetquoteComponent', () => {
  let component: GetquoteComponent;
  let fixture: ComponentFixture<GetquoteComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetquoteComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetquoteComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
