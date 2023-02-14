import { ComponentFixture, TestBed } from '@angular/core/testing';

import { NavBardComponent } from './nav-bard.component';

describe('NavBardComponent', () => {
  let component: NavBardComponent;
  let fixture: ComponentFixture<NavBardComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ NavBardComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(NavBardComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
