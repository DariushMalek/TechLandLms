import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseManagementListComponent } from './course-management-list.component';

describe('CourseManagementListComponent', () => {
  let component: CourseManagementListComponent;
  let fixture: ComponentFixture<CourseManagementListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseManagementListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseManagementListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
