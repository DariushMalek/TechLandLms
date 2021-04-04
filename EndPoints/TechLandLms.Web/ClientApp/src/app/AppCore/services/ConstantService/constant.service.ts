import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ConstantService {

    constructor(private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) {
    }

    getConstantListByType(typeName: string) {
        return this.http.get(this.baseUrl + 'Constant/ConstantListByType/' + typeName);
    }

    paymentTypeList() {
        return this.getConstantListByType("PaymentType");
    }

    educationDegreeList() {
        return this.getConstantListByType("EducationDegree");
    }

    genderTypeList() {
        return this.getConstantListByType("GenderType");
    }
}
