import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { tap, timeout } from 'rxjs/operators';
import { environment } from '../../../../environments/environment';
import { AuthModel } from '../_models/auth.model';

@Injectable()
export class InterceptService implements HttpInterceptor {
    private authLocalStorageToken = `${environment.appVersion}-${environment.USERDATA_KEY}`;
    constructor() { }
    // intercept request and add token
    intercept(
        request: HttpRequest<any>,
        next: HttpHandler
    ): Observable<HttpEvent<any>> {

        let auth = this.getAuthFromLocalStorage();
        if (auth && auth.accessToken) {
            request = request.clone({
                setHeaders: {
                    Authorization: `Bearer ${auth.accessToken}`
                }
            });
        }
        return next.handle(request).pipe(
            tap(
                event => {
                    if (event instanceof HttpResponse) {
                         console.log('all looks good');
                        // http response status code
                         console.log(event.status);
                    }
                },
                error => {
                    // http response status code
                     console.log('----response----');
                     console.error('status code:');
                    // tslint:disable-next-line:no-debugger
                    console.error(error.status);
                    console.error(error.message);
                     console.log('--- end of response---');
                }
            ), timeout(120000)
        );
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
}
