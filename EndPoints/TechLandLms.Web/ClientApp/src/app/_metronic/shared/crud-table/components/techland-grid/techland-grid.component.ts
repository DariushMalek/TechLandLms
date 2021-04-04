import { Component, EventEmitter, Input, OnDestroy, OnInit, Output } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { emit } from 'process';
import { Subscription } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';
import { BaseModel, GroupingState, ICreateAction, IDeleteAction, IDeleteSelectedAction, IEditAction, IFetchSelectedAction, IFilterView, IGroupingView, ISearchView, ISortView, IUpdateStatusForSelectedAction, PaginatorState, SortState, TableService } from '../..';
import { IMenuItem } from '../../models/menu-item.model';
import { DeleteEntitiesModalComponent } from '../delete-entities-modal/delete-entities-modal.component';
import { DeleteEntityModalComponent } from '../delete-entity-modal/delete-entity-modal.component';

@Component({
  selector: 'app-techland-grid',
  templateUrl: './techland-grid.component.html',
  styleUrls: ['./techland-grid.component.scss']
})
export class TechlandGridComponent<T extends BaseModel > implements
    OnInit,
    OnDestroy,
    ICreateAction,
    IEditAction,
    IDeleteAction,
    IDeleteSelectedAction,
    IFetchSelectedAction,
    IUpdateStatusForSelectedAction,
    ISortView,
    IFilterView,
    IGroupingView,
    ISearchView,
    IFilterView {
    paginator: PaginatorState;
    sorting: SortState;
    grouping: GroupingState;
    isLoading: boolean;
    filterGroup: FormGroup;
    searchGroup: FormGroup;
    private subscriptions: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
    @Input() public entityService: TableService<T>;
    @Input() public menuItems: IMenuItem[];
    @Output() onMenuItemClick: EventEmitter<any> = new EventEmitter();
    @Output() onEditEntity: EventEmitter<any> = new EventEmitter();
    constructor(private fb: FormBuilder,
        private modalService: NgbModal) {
    }

    ngOnInit(): void {
        this.filterForm();
        this.searchForm();
        this.entityService.fetch();
        this.grouping = this.entityService.grouping;
        this.paginator = this.entityService.paginator;
        this.sorting = this.entityService.sorting;
        const sb = this.entityService.isLoading$.subscribe(res => this.isLoading = res);
        this.subscriptions.push(sb);
    }

    ngOnDestroy() {
        this.subscriptions.forEach((sb) => sb.unsubscribe());
    }

    // filtration
    filterForm() {
        this.filterGroup = this.fb.group({
            isUserStudent: [''],
            isTestUser: [''],
            searchTerm: [''],
        });
        this.subscriptions.push(
            this.filterGroup.controls.isUserStudent.valueChanges.subscribe(() =>
                this.filter()
            )
        );
        this.subscriptions.push(
            this.filterGroup.controls.isTestUser.valueChanges.subscribe(() => this.filter())
        );
    }

    filter() {
        const filter = {};
        const isUserStudent = this.filterGroup.get('isUserStudent').value;
        if (isUserStudent) {
            filter['isUserStudent'] = isUserStudent;
        }

        const isTestUser = this.filterGroup.get('isTestUser').value;
        if (isTestUser) {
            filter['isTestUser'] = isTestUser;
        }
        this.entityService.patchState({ filter });
    }

    // search
    searchForm() {
        this.searchGroup = this.fb.group({
            searchTerm: [''],
        });
        const searchEvent = this.searchGroup.controls.searchTerm.valueChanges
            .pipe(
                /*
              The user can type quite quickly in the input box, and that could trigger a lot of server requests. With this operator,
              we are limiting the amount of server requests emitted to a maximum of one every 150ms
              */
                debounceTime(150),
                distinctUntilChanged()
            )
            .subscribe((val) => this.search(val));
        this.subscriptions.push(searchEvent);
    }

    search(searchTerm: string) {
        this.entityService.patchState({ searchTerm });
    }

    // sorting
    sort(column: string) {
        const sorting = this.sorting;
        const isActiveColumn = sorting.column === column;
        if (!isActiveColumn) {
            sorting.column = column;
            sorting.direction = 'asc';
        } else {
            sorting.direction = sorting.direction === 'asc' ? 'desc' : 'asc';
        }
        this.entityService.patchState({ sorting });
    }

    // pagination
    paginate(paginator: PaginatorState) {
        this.entityService.patchState({ paginator });
    }

    // form actions
    create() {
        this.edit(undefined);
    }

    edit(entity) {
        if (this.onEditEntity) {
            this.onEditEntity.emit(entity);
        }
       
    }

    delete(id: number) {
        const modalRef = this.modalService.open(DeleteEntityModalComponent);
        modalRef.componentInstance.id = id;
        modalRef.componentInstance.entityService = this.entityService;
        modalRef.result.then(() => this.entityService.fetch(), () => { });
    }

    deleteSelected() {
        const modalRef = this.modalService.open(DeleteEntitiesModalComponent);
        modalRef.componentInstance.ids = this.grouping.getSelectedRows();
        modalRef.componentInstance.entityService = this.entityService;
        modalRef.result.then(() => this.entityService.fetch(), () => { });
    }

    updateStatusForSelected() {
        //const modalRef = this.modalService.open(UpdateCustomersStatusModalComponent);
        //modalRef.componentInstance.ids = this.grouping.getSelectedRows();
        //modalRef.result.then(() => this.userAccountService.fetch(), () => { });
    }

    fetchSelected() {
        //const modalRef = this.modalService.open(FetchCustomersModalComponent);
        //modalRef.componentInstance.ids = this.grouping.getSelectedRows();
        //modalRef.result.then(() => this.userAccountService.fetch(), () => { });
    }

    //generateTable() {
    //    var table = new TableElement();
    //}

    public menuItemClick(opName, entity) {
        let param = { opName, entity }
        this.onMenuItemClick.emit(param);

    }

}
