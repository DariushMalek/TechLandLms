import { BaseModel } from '../../../_metronic/shared/crud-table';

export interface CourseModel extends BaseModel {
    id: number;
    courseTitle: string;
    subjectText: string;
    introduction: string;
    prerequisites: string;
    audiencesDes: string;
    topics: string;
    completeIntroduction: string;
    onlineCost: any;
    attendanceCost: any;
    paymentTypeId: number;
    numberOfSessions: number;
    description: string;
    isActive: boolean;
    startDate: Date;
    endDate: Date;
    startPersianDate: string;
    endPersianDate: string;
    defaultGroupId: number;
    userId: number;
    createDate: Date;
}

export class CourseModel implements CourseModel {
}