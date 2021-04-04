import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, OnDestroy, OnInit, ViewChild } from '@angular/core';
import KTWizard from '../../../../../assets/js/components/wizard';
import { KTUtil } from '../../../../../assets/js/components/util';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { of } from 'rxjs';
import { catchError, first, switchMap, tap } from 'rxjs/operators';
import { AppUserService } from '../../../../AppCore/services/AppUserService/app-user.service';
import { AppUserModel } from '../../../../_metronic/core/models/app-user.model';
import { ExceptionModel } from '../../../../_metronic/shared/crud-table/models/base.model';
import * as moment from 'jalali-moment';
import { ConstantModel } from '../../../../AppCore/models/ConstantModel/constant';
import { ConstantService } from '../../../../AppCore/services/ConstantService/constant.service';
import { ProvinceModel } from '../../../../AppCore/models/ProvinceModel/province.model';
import { CityModel } from '../../../../AppCore/models/CityModel/city.model';
import { CityService } from '../../../../AppCore/services/CityService/city.service';
import { DomSanitizer } from '@angular/platform-browser';
import { AlertDialogComponent } from '../../../modals/alert-dialog/alert-dialog.component';
import { MatDialog } from '@angular/material/dialog';

const EMPTY_APPUSER: AppUserModel = {
    id: 0,
    educationDegreeId: null,
    cityId: null,
    genderTypeId: null,
    firstName: '',
    lastName: '',
    userName: '',
    email: '',
    pass: '',
    personalCode: '',
    phoneNumber: '',
    mobile: '',
    isActive: false,
    isAdmin: false,
    userAddress: '',
    userImage: '',
    jobTitle: '',
    dateOfBirth: null
};

@Component({
    selector: 'app-app-user-update',
    templateUrl: './app-user-update.component.html',
    styleUrls: ['./app-user-update.component.scss']
})
export class AppUserUpdateComponent implements OnInit, AfterViewInit {

    appUser: AppUserModel;
    birthDateObject: any;
    id: number;
    formGroup: FormGroup;
    errorMessage = '';
    errorMessageUserName: any;
    errorMessagePhoneNumber: any;
    errorMessageEmail: any;
    errorMessagePersonalCode: any;
    showInitWaitingMessage: boolean;
    unsubscribe: any;
    educationDegreeList: ConstantModel[];
    genderTypeList: ConstantModel[];
    cityList: CityModel;
    @ViewChild('wizard', { static: true }) el: ElementRef;
    submitted = false;
    wizard: any;
    subscriptions: any;
    file: File;
    message: string;
    imagePath: any;
    url: string | ArrayBuffer;
    imagePro: boolean;
    userProfileImage: any;

    constructor(
        private fb: FormBuilder,
        private appUserService: AppUserService,
        private router: Router,
        private route: ActivatedRoute,
        private constantService: ConstantService,
        private cityService: CityService,
        private cdr: ChangeDetectorRef,
        private sanitizer: DomSanitizer,
        public dialog: MatDialog,
    ) { }

    ngOnInit(): void {
        this.loadAppUser();
        this.getEducationDegreeList();
        this.getGenderTypeList();
        this.getCityList();
    }

    getCityList() {
        this.cityService.getCityList()
            .subscribe((data: CityModel) => this.cityList = data);
    }

    getEducationDegreeList() {
        this.constantService.educationDegreeList()
            .subscribe((data: ConstantModel[]) => this.educationDegreeList = data);
    }

    getGenderTypeList() {
        this.constantService.genderTypeList()
            .subscribe((data: ConstantModel[]) => this.genderTypeList = data);
    }

    loadAppUser() {
        const sb = this.route.paramMap.pipe(
            switchMap(params => {
                // get id from URL
                this.id = Number(params.get('id'));
                if (this.id || this.id > 0) {
                    return this.appUserService.getItemById(this.id);
                } else {
                    return of(EMPTY_APPUSER);
                }
            }),
            catchError((errorMessage) => {
                this.errorMessage = errorMessage;
                return of(undefined);
            }),
        ).subscribe((res: AppUserModel) => {
            if (!res) {
                this.router.navigate(['/user-management/appUserList'], { relativeTo: this.route });
            }

            this.appUser = res;
            this.birthDateObject = moment(this.appUser.dateOfBirth, 'YYYY, MM, DD HH:mm:ss');
            this.getUserImgById();
            this.loadForm();
        });
    }

    loadForm() {
        if (!this.appUser) {
            return;
        }

        this.formGroup = this.fb.group({
            firstName: [
                this.appUser.firstName,
                Validators.compose([
                    Validators.required,
                    Validators.minLength(2),
                    Validators.maxLength(40),
                ]),
            ], lastName: [
                this.appUser.lastName,
                Validators.compose([
                    Validators.required,
                    Validators.minLength(2),
                    Validators.maxLength(40),
                ]),
            ],
            mobile: [
                this.appUser.phoneNumber,
                Validators.compose([
                    Validators.required,
                    Validators.pattern("^((\\+91-?)|0)?[0-9]{10}$"),
                    Validators.minLength(11),
                    Validators.maxLength(11),
                ]),
            ],
            userName: [
                this.appUser.userName,
                Validators.compose([
                    Validators.required,
                    Validators.minLength(4),
                    Validators.maxLength(20),
                ]),
            ],
            email: [
                this.appUser.email,
                Validators.compose([
                    Validators.email,
                    Validators.required,
                ]),
            ],
            pass: [
                this.appUser.pass,
                Validators.compose([
                    Validators.required,
                    Validators.minLength(8),
                    Validators.maxLength(20),
                    Validators.pattern(/^([0-9]+[a-zA-Z]+|[a-zA-Z]+[0-9]+)[0-9a-zA-Z]*$/)
                ]),
            ],
            personalCode: [this.appUser.personalCode, Validators.required],
            isActive: [this.appUser.isActive],
            isAdmin: [this.appUser.isAdmin],
            genderTypeId: [this.appUser.genderTypeId],
            educationDegreeId: [this.appUser.educationDegreeId],
            cityId: [this.appUser.cityId],
            userImage: [this.appUser.userImage],
            jobTitle: [this.appUser.jobTitle],
            phoneNumber: [this.appUser.phoneNumber],

        });
    }

    cleanErrors() {
        this.errorMessage = '';
        this.errorMessageEmail = '';
        this.errorMessagePhoneNumber = '';
        this.errorMessageUserName = '';
        this.errorMessagePersonalCode = '';
    }

    onSubmit() {
        this.appUser.dateOfBirth = new Date(this.birthDateObject.utc(true).locale("en"));
        this.submitted = true;
        this.formGroup.markAllAsTouched();
        if (!this.formGroup.valid) {
            return;
        }

        const formValues = this.formGroup.value;
        this.appUser = Object.assign(this.appUser, formValues);
        if (this.id) {
            this.edit();
        } else {
            this.create();
        }
    }

    uploadUserImageForCreate(id: number) {
        if (this.file) {
            const formData = new FormData();
            formData.append('file', this.file, this.file.name);
            this.appUserService.uploadUserImage(formData, id).subscribe();
        }
    }
    uploadUserImageForUpdate() {
        if (this.file) {
            const formData = new FormData();
            formData.append('file', this.file, this.file.name);
            this.appUserService.uploadUserImage(formData, this.id).subscribe();
        }
    }

    edit() {
        this.cleanErrors();
        this.showInitWaitingMessage = true;
        this.appUserService
            .updateAppUser(this.appUser)
            .pipe(first())
            .subscribe(user => {
                this.showInitWaitingMessage = false;
                this.uploadUserImageForUpdate();
                let message = 'کاربر با موفقیت ویرایش شد';
                this.dialog.open(AlertDialogComponent, { data: { message }, height: '200px', width: '400px', disableClose: true });
                this.router.navigate(['/user-management/appUserList']);
            },
                (err: ExceptionModel) => {
                    this.showInitWaitingMessage = false;
                    this.errorSubmit(err);
                });

    }

    create() {
        this.cleanErrors();
        this.showInitWaitingMessage = true;
        this.appUserService
            .CreateAppUser(this.appUser)
            .pipe(first())
            .subscribe((user: any) => {
                this.showInitWaitingMessage = false;
                this.uploadUserImageForCreate(user.entity.id);
                let message = 'کاربر با موفقیت ایجاد شد';
                this.dialog.open(AlertDialogComponent, { data: { message }, height: '200px', width: '400px', disableClose: true });
                this.router.navigate(['/user-management/appUserList']);
            },
                (err: ExceptionModel) => {
                    this.showInitWaitingMessage = false;
                    this.errorSubmit(err);
                });
    }

    errorSubmit(error) {
        if (error.error.exception.exceptionHint == 'MobileIsDuplicate') {
            this.errorMessagePhoneNumber = error.error.exception.message;
        }
        else if (error.error.exception.exceptionHint == 'EmailIsDuplicate') {
            this.errorMessageEmail = error.error.exception.message;
        }
        else if (error.error.exception.exceptionHint == 'UserIsDuplicate') {
            this.errorMessageUserName = error.error.exception.message;
        }
        else if (error.error.exception.exceptionHint == 'DuplicatePersonalCode') {
            this.errorMessagePersonalCode = error.error.exception.message;
        }
        else if (error.error == null) {
            console.log('عملیات با موفقیت انجام شد');
        }
        else {
            this.errorMessage = 'خطایی به وجود آمده';
        }
        this.cdr.detectChanges();
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


    ngAfterViewInit(): void {
        // Initialize form wizard
        this.wizard = new KTWizard(this.el.nativeElement, {
            startStep: 1
        });

        // Validation before going to next page
        this.wizard.on('beforeNext', (wizardObj) => {
            // https://angular.io/guide/forms
            // https://angular.io/guide/form-validation

            // validate the form and use below function to stop the wizard's step
            // wizardObj.stop();
        });

        // Change event
        this.wizard.on('change', (wizardObj) => {
            setTimeout(() => {
                KTUtil.scrollTop();
            }, 500);

            if (wizardObj.currentStep == 1) {
                if (this.birthDateObject._i == '' || this.birthDateObject == null || this.birthDateObject == undefined) {
                    alert('لطفا تاریخ تولد را وارد نمائید');
                    wizardObj.stop();
                }
                if (!this.appUser.firstName) {
                    this.validateField("firstName");
                    wizardObj.stop();
                }
                if (!this.appUser.lastName) {
                    this.validateField("lastName");
                    wizardObj.stop();
                }
                if (!this.appUser.email) {
                    this.validateField("email");
                    wizardObj.stop();
                }
                if (!this.appUser.mobile) {
                    this.validateField("mobile");
                    wizardObj.stop();
                }
            } else if (wizardObj.currentStep == 3) {
                if (!this.appUser.userName) {
                    this.validateField("userName");
                    wizardObj.stop();
                }
                if (!this.appUser.pass) {
                    this.validateField("pass");
                    wizardObj.stop();
                }
            } else if (wizardObj.currentStep == 4) {
                if (!this.appUser.personalCode) {
                    this.validateField("personalCode");
                    wizardObj.stop();
                }
            }
        });
    }

    validateField(field) {
        const control = this.formGroup.get(field);
        control.markAsTouched({ onlySelf: true });
        this.cdr.detectChanges();
    }

    onFileChanged(event) {
        const files = event.target.files;
        if (files.length === 0)
            return;
        this.loadImage(files[0]);

    }

    getUserImgById() {
        this.appUserService.getUserImageById(this.id)
            .subscribe((data: any) => {
                this.loadImage(data);
            }, (error: any) => {
                console.log(error)
            });
    }

    loadImage(img: File) {
        const mimeType = img.type;
        if (mimeType.match(/image\/*/) == null) {
            this.message = "Only images are supported.";
            return;
        }

        const reader = new FileReader();
        reader.readAsDataURL(img);
        reader.onload = (_event) => {
            this.url = reader.result;
            this.file = img;
            this.cdr.detectChanges();
        }
    }

}
