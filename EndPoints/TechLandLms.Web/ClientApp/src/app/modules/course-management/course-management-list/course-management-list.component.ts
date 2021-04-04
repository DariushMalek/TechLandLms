import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { CourseModel } from '../../../AppCore/models/CourseModel/course.model';
import { CourseService } from '../../../AppCore/services/CourseService/course.service';
import { TechlandGridComponent } from '../../../_metronic/shared/crud-table/components/techland-grid/techland-grid.component';

@Component({
    selector: 'app-course-management-list',
    templateUrl: './course-management-list.component.html',
    styleUrls: ['./course-management-list.component.scss']
})
export class CourseManagementListComponent implements
    OnInit {
    @ViewChild('techLandGrid') techLandGrid: TechlandGridComponent<CourseModel>;

    constructor(public courseService: CourseService,
        private router: Router,) {
        //this.techLandGrid.edit = this.onEdit;
    }
 
    ngOnInit(): void {
    }

    
    public onEdit(id: number){
        this.router.navigate(['./course-management/course/add'+ id]);
    }

    deleteCourse(course: CourseModel) {
        //if (confirm("آیا برای حذف اطمینان دارید ")) {
        //    console.log("Implement delete functionality here");
        //}
        //this.courseService.delete(course.id)
        //    .subscribe(data => {
        //        this.techLandGrid.entityService.gridColumns = this.techLandGrid.entityService.gridColumns.filter(u => u !== course);
        //    })
    }


}
