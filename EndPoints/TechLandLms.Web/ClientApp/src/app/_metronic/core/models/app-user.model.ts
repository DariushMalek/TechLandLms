import { Data } from '@angular/router';

export class AppUserModel {
    id: number;
    userName: string;
    email: string;
    firstName: string;
    lastName: string;
    pass: string;
    //confirmPass: string;
    phoneNumber: string;
    isActive: boolean;
    personalCode: string;
    mobile: string;
    dateOfBirth: Date;
    userAddress: string;
    isAdmin: boolean;
    userImage: string;
    jobTitle: string;
    educationDegreeId: number;
    genderTypeId: number;
    cityId: number;
}