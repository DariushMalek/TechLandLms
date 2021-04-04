import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AppUserUpdateComponent } from './app-user-update.component';

describe('AppUserUpdateComponent', () => {
  let component: AppUserUpdateComponent;
  let fixture: ComponentFixture<AppUserUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AppUserUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AppUserUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
