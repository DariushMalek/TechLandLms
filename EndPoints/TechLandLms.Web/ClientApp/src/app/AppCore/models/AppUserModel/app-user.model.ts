import { BaseModel } from '../../../_metronic/shared/crud-table';

export interface AppUserModel extends BaseModel {
    id: number;
    userName: string;
    email: string;
    firstName: string;
    lastName: string;
    pass: string;
    confirmPass: string;
    phoneNumber: string;
    mobile: string;
    personalCode: string;
    isActive: boolean;
}

export class AppUserModel implements AppUserModel {
}