import { BaseModel } from '../../_metronic/shared/crud-table';

export interface UserAccount extends BaseModel{
    id: number;
    userName: string;
    email: string;
    userPass: string;
    firstName: string;
    lastName: string;
    phoneNumber: string;
    dateOfBirth: Date;
    personalCode: string;
    userAddress: string;
    cityId: number;
    genderTypeId: number;
    educationDegree: string;
    isActive: boolean;
    isAdmin: boolean;
    educationalSystemId: number;
    educationalSystemTitle: string;
    schoolId: number;
    schoolName: string;
    isUserStudent: boolean;
    isTestUser: boolean;
    userImage: string;
}
