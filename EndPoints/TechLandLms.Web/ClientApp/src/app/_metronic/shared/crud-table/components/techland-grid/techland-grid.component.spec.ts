import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TechlandGridComponent } from './techland-grid.component';

describe('TechlandGridComponent', () => {
  let component: TechlandGridComponent;
  let fixture: ComponentFixture<TechlandGridComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TechlandGridComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TechlandGridComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
