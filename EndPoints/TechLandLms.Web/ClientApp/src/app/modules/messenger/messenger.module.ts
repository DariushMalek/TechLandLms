import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { CRUDTableModule } from '../../_metronic/shared/crud-table';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { HttpClientModule } from '@angular/common/http';
import { DpDatePickerModule } from 'ng2-jalali-date-picker';
import { MatRippleModule } from '@angular/material/core';
import { MessengerRoutingModule } from './messenger-routing.module';
import { MessengerComponent } from './messenger.component';
import { UserMessengerComponent } from './user-messenger/user-messenger.component';
import { SharedModule } from '../../shared/shared.module';



@NgModule({
    declarations: [MessengerComponent,
        UserMessengerComponent,],
    imports: [
        CommonModule,
        HttpClientModule,
        CRUDTableModule,
        FormsModule,
        ReactiveFormsModule,
        InlineSVGModule,
        DpDatePickerModule,
        MatRippleModule,
        MessengerRoutingModule,
        SharedModule,
    ],
    exports: [RouterModule],
    schemas: [CUSTOM_ELEMENTS_SCHEMA],
})
export class MessengerModule { }
