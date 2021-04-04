import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CourseManagementListComponent } from './course-management-list/course-management-list.component';
import { CourseManagementUpdateComponent } from './course-management-update/course-management-update.component';
import { CourseManagementComponent } from './course-management.component';

const routes: Routes = [
    {
        path: '',
        component: CourseManagementComponent,
        children: [
            {
                path: 'courseList',
                component: CourseManagementListComponent,
            },
            {
                path: 'course/add',
                component: CourseManagementUpdateComponent,
            },
            {
                path: 'course/edit/:id',
                component: CourseManagementUpdateComponent,
            },
            { path: '', redirectTo: 'courseList', pathMatch: 'full' },
            { path: '**', redirectTo: 'courseList', pathMatch: 'full' },
        ],
    },
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class CourseManagementRoutingModule { }
