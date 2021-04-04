import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CRUDTableModule } from '../../_metronic/shared/crud-table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { HttpClientModule } from '@angular/common/http';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';
import { MatMomentDateModule, MAT_MOMENT_DATE_ADAPTER_OPTIONS } from '@angular/material-moment-adapter';
import { MatNativeDateModule, MatRippleModule, MAT_DATE_LOCALE } from '@angular/material/core';
import { MatDatepickerModule } from '@angular/material/datepicker';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { ECommerceModule } from '../e-commerce/e-commerce.module';
import { SharedModule } from '../../shared/shared.module';
import { ModalsRoutingModule } from './modals-routing.module';
import { ModalsComponent } from './modals.component';
import { AlertDialogComponent } from './alert-dialog/alert-dialog.component';
import { ConfirmDialogComponent } from './confirm-dialog/confirm-dialog.component';



@NgModule({
  declarations: [ModalsComponent, AlertDialogComponent, ConfirmDialogComponent],
    imports: [
        CommonModule,
        HttpClientModule,
        CRUDTableModule,
        FormsModule,
        ReactiveFormsModule,
        InlineSVGModule,
        CRUDTableModule,
        DpDatePickerModule,
        ModalsRoutingModule,
        MatMomentDateModule,
        MatNativeDateModule,
        MatDatepickerModule,
        NgbDatepickerModule,
        ECommerceModule,
        SharedModule,
        MatRippleModule,
    ],
    entryComponents: [
        AlertDialogComponent,
        ConfirmDialogComponent,
    ],
    exports: [RouterModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
    providers: [
        { provide: MAT_MOMENT_DATE_ADAPTER_OPTIONS, useValue: { useUtc: true } },
        { provide: MAT_DATE_LOCALE, useValue: 'fa-IR' }
    ],
})
export class ModalsModule { }
