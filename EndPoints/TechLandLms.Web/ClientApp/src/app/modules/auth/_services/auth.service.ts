import { Injectable, OnDestroy } from '@angular/core';
import { Observable, BehaviorSubject, of, Subscription } from 'rxjs';
import { map, catchError, switchMap, finalize } from 'rxjs/operators';
import { UserModel } from '../_models/user.model';
import { AuthModel } from '../_models/auth.model';

import { environment } from 'src/environments/environment';
import { Router } from '@angular/router';
import { AuthHTTPService } from './auth-http/auth-http.service';
import { DomSanitizer } from '@angular/platform-browser';
import { AppUserModel } from '../../../AppCore/models/AppUserModel/app-user.model';

@Injectable({
    providedIn: 'root',
})
export class AuthService implements OnDestroy {
    // private fields
    private unsubscribe: Subscription[] = []; // Read more: => https://brianflove.com/2016/12/11/anguar-2-unsubscribe-observables/
    private authLocalStorageToken = `${environment.appVersion}-${environment.USERDATA_KEY}`;

    // public fields
    currentUser$: Observable<UserModel>;
    isLoading$: Observable<boolean>;
    currentUserSubject: BehaviorSubject<UserModel>;
    isLoadingSubject: BehaviorSubject<boolean>;


    get currentUserValue(): UserModel {
        return this.currentUserSubject.value;
    }

    //set currentUserValue(user: UserModel) {
    //  this.currentUserSubject.next(user);
    //}

    constructor(
        private authHttpService: AuthHTTPService,
        private router: Router,
        private sanitizer: DomSanitizer
    ) {
        this.isLoadingSubject = new BehaviorSubject<boolean>(false);
        this.currentUserSubject = new BehaviorSubject<UserModel>(undefined);
        this.currentUser$ = this.currentUserSubject.asObservable();
        this.isLoading$ = this.isLoadingSubject.asObservable();
        const subscr = this.getUserByToken().subscribe();
        this.unsubscribe.push(subscr);
    }

    // public methods
    login(email: string, password: string): Observable<UserModel> {
        this.isLoadingSubject.next(true);
        return this.authHttpService.login(email, password).pipe(
            map((auth: AuthModel) => {
                const result = this.setAuthFromLocalStorage(auth);
                return result;
            }),
            switchMap(() => this.getUserByToken()),
            catchError((err) => {
                console.error('err', err);
                let errorMessage = err.error.message;
                return of(undefined);
            }),
            finalize(() => this.isLoadingSubject.next(false))
        );
    }

    logout() {
        localStorage.removeItem(this.authLocalStorageToken);
        this.router.navigate(['/auth/login'], {
            queryParams: {},
        });
    }

    getUserByToken(): Observable<UserModel> {
        const auth = this.getAuthFromLocalStorage();
        if (!auth || !auth.accessToken) {
            return of(undefined);
        }

        this.isLoadingSubject.next(true);
        return this.authHttpService.getUserByToken(auth.accessToken).pipe(
            map((user: UserModel) => {
                if (user) {
                    const curUser = new UserModel();
                    curUser.setUser(user);
                    curUser.accessToken = auth.accessToken;
                    curUser.expiresIn = auth.expiresIn;
                    curUser.refreshToken = auth.refreshToken;
                    this.currentUserSubject = new BehaviorSubject<UserModel>(curUser);
                } else {
                    this.logout();
                }
                return user;
            }),
            finalize(() => this.isLoadingSubject.next(false))
        );
    }

    // need create new user then login
    registration(user: AppUserModel) {
        this.isLoadingSubject.next(true);
        return this.authHttpService.createUser(user).pipe(
            map(() => {
                this.isLoadingSubject.next(false);
            }),
            switchMap(() => this.login(user.email, user.pass)),
            //catchError((err) => {
            //    console.error('err', err);
            //    let errorMessage = err.error.message;
            //    return of(undefined);
            //}),
            finalize(() => this.isLoadingSubject.next(false))
        );
    }

    forgotPassword(email: string): Observable<boolean> {
        this.isLoadingSubject.next(true);
        return this.authHttpService
            .forgotPassword(email)
            .pipe(finalize(() => this.isLoadingSubject.next(false)));
    }

    // private methods
    private setAuthFromLocalStorage(auth: AuthModel): boolean {
        // store auth accessToken/refreshToken/epiresIn in local storage to keep user logged in between page refreshes
        if (auth && auth.accessToken) {
            localStorage.setItem(this.authLocalStorageToken, JSON.stringify(auth));
            return true;
        }
        return false;
    }

    private getAuthFromLocalStorage(): AuthModel {
        try {
            const authData = JSON.parse(
                localStorage.getItem(this.authLocalStorageToken)
            );
            return authData;
        } catch (error) {
            console.error(error);
            return undefined;
        }
    }

    ngOnDestroy() {
        this.unsubscribe.forEach((sb) => sb.unsubscribe());
    }

    getUserProfileImage(): Observable<any>{
        return this.authHttpService.getUserProfileImage()
            .pipe(map(data => { return data }));
    }

    changePassword() {

    }

}
