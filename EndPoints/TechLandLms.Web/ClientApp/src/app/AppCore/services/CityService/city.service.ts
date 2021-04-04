import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CityService {

    constructor(private http: HttpClient,
        @Inject('BASE_URL') private baseUrl: string) { }


    getCityList() {
        return this.http.get(this.baseUrl + 'City');
    }

}
