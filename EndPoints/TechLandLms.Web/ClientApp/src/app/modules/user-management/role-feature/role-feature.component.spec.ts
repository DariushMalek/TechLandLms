import { ComponentFixture, TestBed } from '@angular/core/testing';

import { RoleFeatureComponent } from './role-feature.component';

describe('RoleFeatureComponent', () => {
  let component: RoleFeatureComponent;
  let fixture: ComponentFixture<RoleFeatureComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ RoleFeatureComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(RoleFeatureComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
