import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
//import { UserAccountComponent } from './user-account/user-account.component';
import { SharedComponent } from './shared.component';
import { SharedRoutingModule } from './shared-routing.module';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { InlineSVGModule } from 'ng-inline-svg';
import { CRUDTableModule } from '../_metronic/shared/crud-table';
import { NgbDatepickerModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';



@NgModule({
    declarations: [
        //UserAccountComponent,
        SharedComponent],
  imports: [
      CommonModule,
      SharedRoutingModule,
      HttpClientModule,
      FormsModule,
      ReactiveFormsModule,
      InlineSVGModule,
      CRUDTableModule,
      NgbModalModule,
      NgbDatepickerModule
  ]
})
export class SharedModule { }
