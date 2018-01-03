import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutLocationComponent } from './about-location.component';

describe('AboutLocationComponent', () => {
  let component: AboutLocationComponent;
  let fixture: ComponentFixture<AboutLocationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AboutLocationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutLocationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
