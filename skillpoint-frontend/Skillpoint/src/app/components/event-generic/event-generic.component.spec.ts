import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { EventGenericComponent } from './event-generic.component';

describe('EventGenericComponent', () => {
  let component: EventGenericComponent;
  let fixture: ComponentFixture<EventGenericComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ EventGenericComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(EventGenericComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
