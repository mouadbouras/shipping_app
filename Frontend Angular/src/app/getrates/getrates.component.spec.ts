import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { GetratesComponent } from './getrates.component';

describe('GetratesComponent', () => {
  let component: GetratesComponent;
  let fixture: ComponentFixture<GetratesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ GetratesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(GetratesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
