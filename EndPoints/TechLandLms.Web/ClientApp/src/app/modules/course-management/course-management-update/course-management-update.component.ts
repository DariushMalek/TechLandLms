import { AfterViewInit, ChangeDetectorRef, Component, ElementRef, Input, OnDestroy, OnInit, ViewChild } from '@angular/core';
import KTWizard from '../../../../assets/js/components/wizard';
import { KTUtil } from '../../../../assets/js/components/util';
import { CourseModel } from '../../../AppCore/models/CourseModel/course.model';
import { ConstantModel } from '../../../AppCore/models/ConstantModel/constant';
import { ConstantService } from '../../../AppCore/services/ConstantService/constant.service';
import { CourseService } from '../../../AppCore/services/CourseService/course.service';
import * as moment from 'jalali-moment';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
declare var $: any;

@Component({
    selector: 'app-course-management-update',
    templateUrl: './course-management-update.component.html',
    styleUrls: ['./course-management-update.component.scss']
})
export class CourseManagementUpdateComponent implements OnInit, AfterViewInit, OnDestroy {

    courseForm: FormGroup;
    @ViewChild('wizard', { static: true }) el: ElementRef;
    courseModel: CourseModel;
    paymentTypeList: ConstantModel[];
    startPersianDateObject: any;
    endPersianDateObject: any;
    submitted = false;
    id: number;
    wizard: any;
    loading: boolean;
    errorMessage: string;
    startPersianDate: string;
    endPersianDate: string;

    constructor(private constantService: ConstantService,
        private courseService: CourseService,
        private route: ActivatedRoute,
        private router: Router,
        private fb: FormBuilder,
        private cdr: ChangeDetectorRef,) {
        //this.startPersianDateObject = moment('1395-11-22', 'jYYYY,jMM,jDD');
        this.getPaymentTypeList();
    }

    ngOnInit(): void {
        this.initForm();

        this.route.params.subscribe((params: Params) => {
            this.id = +params['id'];
        });

        if (this.id > 0) {
            this.getCourseById(this.id);
        }
        else {
            this.courseModel = new CourseModel;
        }
    }

    ngAfterViewInit() {
        // Initialize form wizard
        const wizard = new KTWizard(this.el.nativeElement, {
            startStep: 1
        });

        // Validation before going to next page
        wizard.on('beforeNext', (wizardObj) => {


        });

        // Change event
        wizard.on('change', (wizardObj) => {
            setTimeout(() => {
                KTUtil.scrollTop();
            }, 500);

            if (wizardObj.currentStep == 1) {
                if (!this.endPersianDateObject || !this.startPersianDateObject) {
                    alert('لطفا تاریخ شروع و پایان دوره را وارد نمائید');
                    wizardObj.stop();
                }
                if (!this.courseModel.subjectText) {
                    this.validateField("subjectText");
                    wizardObj.stop();
                }
                if (!this.courseModel.courseTitle) {
                    this.validateField("courseTitle");
                    wizardObj.stop();
                }
            }
            else if (wizardObj.currentStep == 2) {
                if (!this.courseModel.introduction) {
                    this.validateField("introduction");
                    wizardObj.stop();
                }
            }

        });
    }

    ngOnDestroy() {
        this.wizard = undefined;
    }

    initForm() {
        this.courseForm = this.fb.group(
            {
                startPersianDate: [this.startPersianDateObject],
                courseTitle: [
                    '',
                    Validators.compose([
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(100),
                    ]),
                ],
                subjectText: [
                    '',
                    Validators.compose([
                        Validators.required,
                        Validators.minLength(3),
                        Validators.maxLength(70),
                    ]),
                ],
                topics: [''],
                numberOfSessions: [''],
                onlineCost: [''],
                paymentTypeId: [''],
                introduction: ['', Validators.required],
                completeIntroduction: [''],
                prerequisites: [''],
                audiencesDes: ['']
            }
        );
    }

    getPaymentTypeList() {
        this.constantService.paymentTypeList()
            .subscribe((data: ConstantModel[]) => this.paymentTypeList = data);
    }

    getCourseById(id) {
        this.courseService.getItemById(id)
            .subscribe(
                (data: CourseModel) => {
                    this.courseModel = data;
                    this.startPersianDateObject = moment(this.courseModel.startDate, 'YYYY, MM, DD HH:mm:ss');
                    this.endPersianDateObject = moment(this.courseModel.endDate, 'YYYY, MM, DD HH:mm:ss');
                    this.cdr.detectChanges();
                },
                error => {
                    console.log(error);
                });
    }

    onSubmit() {
        this.courseModel.startDate = new Date(this.startPersianDateObject.utc(true).locale("en"));
        this.courseModel.endDate = new Date(this.endPersianDateObject.utc(true).locale("en"));

        if (this.id && this.id > 0) {
            this.updateCourse();
        } else {
            this.createCourse(this.courseModel);
        }
    }

    updateCourse() {
        this.loading = true;
        this.errorMessage = "";
        this.courseService.update(this.courseModel)
            .subscribe((data: CourseModel) => {
                this.router.navigate(['./course-management/courseList']);
                return data;
            },
                (error) => {
                    console.error('error caught in component')
                    this.errorMessage = error;
                    this.loading = false;
                    throw error;
                })
    }

    createCourse(course: CourseModel) {
        this.loading = true;
        this.errorMessage = "";
        this.courseService.create(course)
            .subscribe((data: CourseModel) => {
                this.router.navigate(['./course-management/courseList']);
                return data;
            },
                (error) => {
                    console.error('error caught in component')
                    this.errorMessage = error;
                    this.loading = false;
                    throw error;
                })
    }

    validateField(field) {
        const control = this.courseForm.get(field); 
        control.markAsTouched({ onlySelf: true });
        this.cdr.detectChanges();
    }


}
