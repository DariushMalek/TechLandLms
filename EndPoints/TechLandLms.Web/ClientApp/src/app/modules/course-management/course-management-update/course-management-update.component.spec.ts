import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseManagementUpdateComponent } from './course-management-update.component';

describe('CourseManagementUpdateComponent', () => {
  let component: CourseManagementUpdateComponent;
  let fixture: ComponentFixture<CourseManagementUpdateComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseManagementUpdateComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseManagementUpdateComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
