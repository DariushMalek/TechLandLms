import { Inject, Injectable, OnDestroy } from '@angular/core';
import { TableService } from '../../../_metronic/shared/crud-table';
import { CourseModel } from '../../models/CourseModel/course.model';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class CourseService extends TableService<CourseModel> implements OnDestroy {

    ENTITY_CONTROLLER = `Course`;
    constructor(@Inject(HttpClient) http, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    ngOnDestroy() {
        this.subscriptions.forEach(sb => sb.unsubscribe());
    }
}
