import { Inject, Injectable, OnDestroy } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { TableService } from '../../../_metronic/shared/crud-table';
import { AppUserModel } from '../../../_metronic/core/models/app-user.model';
import { Observable } from 'rxjs';
import { PasswordModel } from '../../models/PasswordModel/password.model';

@Injectable({
  providedIn: 'root'
})
export class AppUserService extends TableService<AppUserModel> implements OnDestroy {

    ENTITY_CONTROLLER = `AppUser`;
    EntityTitle = 'کاربر';
    constructor(@Inject(HttpClient) http, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    ngOnDestroy(): void {
        throw new Error('Method not implemented.');
    }

    CreateAppUser(appUser: AppUserModel): Observable<number> {
        return this.http.post<number>(this.getApiUrl() + '/AddAppUser', appUser);
    }

    updateAppUser(appUser: AppUserModel) {
        return this.http.put(this.getApiUrl() + '/UpdateAppUser', appUser);
    }

    public uploadUserImage(data, id) {
        let uploadURL = `${this.getApiUrl()}/UploadUserImage/${id}`;
        return this.http.put(uploadURL, data);
    }

    getUserImageById(userId: number) {
        return this.http.get(this.getApiUrl() + '/GetUserImage/' + userId, {
            responseType: 'blob' as 'json'
        });
    }

    changePassword(passwordModel: PasswordModel) {
        return this.http.put(this.getApiUrl() + '/ChangePassword', passwordModel);
    }
}
