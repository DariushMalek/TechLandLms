import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialog } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Observable, of, Subscription } from 'rxjs';
import { catchError, switchMap, tap } from 'rxjs/operators';
import { RoleModel } from '../../../../AppCore/models/RoleModel/role.model';
import { RoleService } from '../../../../AppCore/services/RoleService/role.service';
import { Product } from '../../../e-commerce/_models/product.model';
import { ProductsService } from '../../../e-commerce/_services';
import { AlertDialogComponent } from '../../../modals/alert-dialog/alert-dialog.component';

const EMPTY_PRODUCT: RoleModel = {
    id: undefined,
    roleName: '',
    roleTitle: '',
    
};

@Component({
  selector: 'app-role-update',
  templateUrl: './role-update.component.html',
  styleUrls: ['./role-update.component.scss']
})
export class RoleUpdateComponent implements OnInit {

    id: number;
    role: RoleModel;
    previous: RoleModel;
    formGroup: FormGroup;
    isLoading$: Observable<boolean>;
    errorMessage = '';
    tabs = {
        BASIC_TAB: 0,
    };
    activeTabId = this.tabs.BASIC_TAB; // 0 => Basic info | 1 => Remarks | 2 => Specifications
    private subscriptions: Subscription[] = [];

    constructor(
        private fb: FormBuilder,
        private roleService: RoleService,
        private router: Router,
        private route: ActivatedRoute,
        public dialog: MatDialog,
    ) { }

    ngOnInit(): void {
        this.loadRole();
    }

    loadRole() {
        const sb = this.route.paramMap.pipe(
            switchMap(params => {
                // get id from URL
                this.id = Number(params.get('id'));
                if (this.id || this.id > 0) {
                    return this.roleService.getItemById(this.id);
                }
                return of(EMPTY_PRODUCT);
            }),
            catchError((errorMessage) => {
                this.errorMessage = errorMessage;
                return of(undefined);
            }),
        ).subscribe((res: RoleModel) => {
            if (!res) {
                this.router.navigate(['/user-management/roles'], { relativeTo: this.route });
            }

            this.role = res;
            this.previous = Object.assign({}, res);
            this.loadForm();
        });
        this.subscriptions.push(sb);
    }

    loadForm() {
        if (!this.role) {
            return;
        }

        this.formGroup = this.fb.group({
            roleName: [this.role.roleName, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(40)])],
            roleTitle: [this.role.roleTitle, Validators.compose([Validators.required, Validators.minLength(3), Validators.maxLength(40)])],
        });
    }

    reset() {
        if (!this.previous) {
            return;
        }

        this.role = Object.assign({}, this.previous);
        this.loadForm();
    }

    save() {
        this.formGroup.markAllAsTouched();
        if (!this.formGroup.valid) {
            return;
        }

        const formValues = this.formGroup.value;
        this.role = Object.assign(this.role, formValues);
        if (this.id) {
            this.edit();
        } else {
            this.create();
        }
    }

    edit() {
        const sbUpdate = this.roleService.update(this.role).pipe(
            tap(() => {
                let message = 'نقش با موفقیت ویرایش شد';
                this.dialog.open(AlertDialogComponent, { data: { message }, height: '200px', width: '400px', disableClose: true });
                this.router.navigate(['/user-management/roles']);
            }),
            catchError((errorMessage) => {
                console.error('UPDATE ERROR', errorMessage);
                return of(this.role);
            })
        ).subscribe(res => this.role = res);
        this.subscriptions.push(sbUpdate);
    }

    create() {
        const sbCreate = this.roleService.create(this.role).pipe(
            tap(() => {
                let message = 'نقش با موفقیت ایجاد شد';
                this.dialog.open(AlertDialogComponent, { data: { message }, height: '200px', width: '400px', disableClose: true });
                this.router.navigate(['/user-management/roles']);
            }),
            catchError((errorMessage) => {
                console.error('UPDATE ERROR', errorMessage);
                return of(this.role);
            })
        ).subscribe(res => this.role = res as RoleModel);
        this.subscriptions.push(sbCreate);
    }

    changeTab(tabId: number) {
        this.activeTabId = tabId;
    }

    ngOnDestroy() {
        this.subscriptions.forEach(sb => sb.unsubscribe());
    }

    // helpers for View
    isControlValid(controlName: string): boolean {
        const control = this.formGroup.controls[controlName];
        return control.valid && (control.dirty || control.touched);
    }

    isControlInvalid(controlName: string): boolean {
        const control = this.formGroup.controls[controlName];
        return control.invalid && (control.dirty || control.touched);
    }

    controlHasError(validation: string, controlName: string) {
        const control = this.formGroup.controls[controlName];
        return control.hasError(validation) && (control.dirty || control.touched);
    }

    isControlTouched(controlName: string): boolean {
        const control = this.formGroup.controls[controlName];
        return control.dirty || control.touched;
    }

}
