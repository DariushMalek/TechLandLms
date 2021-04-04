import { Inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { UserModel } from '../../_models/user.model';
import { AuthModel } from '../../_models/auth.model';
import { AppUserModel } from '../../../../AppCore/models/AppUserModel/app-user.model';



@Injectable({
    providedIn: 'root',
})
export class AuthHTTPService {
    API_USERS_URL = ``;
    API_AUTH_URL = ``;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
        this.API_AUTH_URL = baseUrl + 'Authentication';
        this.API_USERS_URL = baseUrl + 'AppUser';
    }

    // public methods
    login(email: string, password: string): Observable<any> {
        return this.http.post<AuthModel>(this.API_AUTH_URL + '/SignInByEmail', { email, password });
    }

    // CREATE =>  POST: add a new user to the server
    createUser(user: AppUserModel) {
        return this.http.post<AppUserModel>(this.API_USERS_URL + '/SignUpUser', user);
    }

    // Your server should check email => If email exists send link to the user and return true | If email doesn't exist return false
    forgotPassword(email: string): Observable<boolean> {
        return this.http.post<boolean>(this.API_AUTH_URL + '/forgot-password', {
            email,
        });
    }

    getUserByToken(token): Observable<UserModel> {
        const httpHeaders = new HttpHeaders({
            Authorization: `Bearer ${token}`,
        });
        return this.http.get<UserModel>(`${this.API_USERS_URL}` + '/GetCurrentUser', {
            headers: httpHeaders,
        });
    }

    getUserProfileImage(): Observable<any> {
        return this.http.get(`${this.API_USERS_URL}` + '/GetUserProfileImage/', { responseType: "blob" });
    }
}
