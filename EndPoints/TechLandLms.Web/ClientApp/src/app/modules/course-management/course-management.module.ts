import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { CourseManagementListComponent } from './course-management-list/course-management-list.component';
import { RouterModule} from '@angular/router';
import { CRUDTableModule } from '../../_metronic/shared/crud-table';
import { CourseManagementUpdateComponent } from './course-management-update/course-management-update.component';
import { CourseManagementRoutingModule } from './course-management-routing.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { HttpClientModule } from '@angular/common/http';
import { CourseManagementComponent } from './course-management.component';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { DateAdapter, MatNativeDateModule, MatRippleModule, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ECommerceModule } from '../e-commerce/e-commerce.module';
import { SharedModule } from '../../shared/shared.module';


@NgModule({
    declarations: [
        CourseManagementListComponent,
        CourseManagementUpdateComponent,
        CourseManagementComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        CRUDTableModule,
        FormsModule,
        ReactiveFormsModule,
        InlineSVGModule,
        CRUDTableModule,
        DpDatePickerModule,
        CourseManagementRoutingModule,
        MatMomentDateModule,
        MatNativeDateModule,
        MatDatepickerModule,
        NgbDatepickerModule,
        ECommerceModule,
        SharedModule,
        MatRippleModule,
    ],
    exports: [RouterModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    providers: [
        { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
        { provide: MAT_DATE_LOCALE, useValue: 'fa-IR' }
    ],
})
export class CourseManagementModule { }
