import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { PastEventsSectionComponent } from './past-events-section.component';

describe('PastEventsSectionComponent', () => {
  let component: PastEventsSectionComponent;
  let fixture: ComponentFixture<PastEventsSectionComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ PastEventsSectionComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(PastEventsSectionComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
