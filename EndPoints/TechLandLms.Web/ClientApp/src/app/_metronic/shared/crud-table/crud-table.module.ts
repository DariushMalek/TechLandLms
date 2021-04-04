import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PaginatorComponent } from './components/paginator/paginator.component';
import { NgPagination } from './components/paginator/ng-pagination/ng-pagination.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SortIconComponent } from './components/sort-icon/sort-icon.component';
import { InlineSVGModule } from 'ng-inline-svg';
import { TechlandGridComponent } from './components/techland-grid/techland-grid.component';
import { HttpClientModule } from '@angular/common/http';
import { NgbDatepickerModule, NgbModalModule } from '@ng-bootstrap/ng-bootstrap';
import { DeleteEntityModalComponent} from './components/delete-entity-modal/delete-entity-modal.component';
import { DeleteEntitiesModalComponent } from './components/delete-entities-modal/delete-entities-modal.component';
import { MatMenuModule } from '@angular/material/menu';
import { MatIconModule } from '@angular/material/icon';
import { MatButtonModule } from '@angular/material/button';

@NgModule({
    declarations: [PaginatorComponent, NgPagination, SortIconComponent, TechlandGridComponent, DeleteEntityModalComponent, DeleteEntitiesModalComponent],
    imports: [
        CommonModule,
        FormsModule,
        InlineSVGModule,
        ReactiveFormsModule,
        HttpClientModule,
        NgbModalModule,
        NgbDatepickerModule,
        MatMenuModule,
        MatIconModule,
        MatButtonModule
    ],
    entryComponents: [
        DeleteEntityModalComponent,
        DeleteEntitiesModalComponent
    ],
    exports: [PaginatorComponent, NgPagination, SortIconComponent, TechlandGridComponent],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class CRUDTableModule { }
