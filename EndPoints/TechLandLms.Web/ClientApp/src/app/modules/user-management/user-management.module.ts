import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RolesComponent } from './roles/roles.component';
import { UserManagementComponent } from './user-management.component';
import { UserManagementRoutingModule } from './user-management-routing.module';
import { CRUDTableModule } from '../../_metronic/shared/crud-table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { HttpClientModule } from '@angular/common/http';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { DateAdapter, MatNativeDateModule, MatRippleModule, MAT_DATE_FORMATS, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { SharedModule } from '../../shared/shared.module';
import { RouterModule } from '@angular/router';
import { AppUserUpdateComponent } from './users/app-user-update/app-user-update.component';
import { AppUserComponent } from './users/app-user.component';
import { RoleUpdateComponent } from './roles/role-update/role-update.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { RoleFeatureComponent } from './role-feature/role-feature.component';

@NgModule({
    declarations: [AppUserComponent,
        RolesComponent,
        UserManagementComponent,
        AppUserUpdateComponent,
        RoleUpdateComponent,
        ChangePasswordComponent,
        RoleFeatureComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        CRUDTableModule,
        FormsModule,
        ReactiveFormsModule,
        InlineSVGModule,
        DpDatePickerModule,
        UserManagementRoutingModule,
        MatMomentDateModule,
        MatNativeDateModule,
        MatDatepickerModule,
        NgbDatepickerModule,
        SharedModule,
        MatRippleModule,

    ],

    exports: [RouterModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    providers: [
    ],
})
export class UserManagementModule {}
