import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FutureEventsSectionComponent } from './future-events-section.component';

describe('FutureEventsSectionComponent', () => {
  let component: FutureEventsSectionComponent;
  let fixture: ComponentFixture<FutureEventsSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FutureEventsSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FutureEventsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
