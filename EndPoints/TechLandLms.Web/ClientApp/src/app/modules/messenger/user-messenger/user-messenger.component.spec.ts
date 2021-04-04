import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserMessengerComponent } from './user-messenger.component';

describe('UserMessengerComponent', () => {
  let component: UserMessengerComponent;
  let fixture: ComponentFixture<UserMessengerComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ UserMessengerComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(UserMessengerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
