import { HttpClient } from '@angular/common/http';
import { Inject, OnDestroy } from '@angular/core';
import { Injectable } from '@angular/core';
import { environment } from '../../../environments/environment';
import { TableService } from '../../_metronic/shared/crud-table';
import { UserAccount } from '../modeles/user-account';

@Injectable({
  providedIn: 'root'
})
export class UserAccountService extends TableService<UserAccount> implements OnDestroy{
    ENTITY_CONTROLLER = `userAccount`;
    constructor(@Inject(HttpClient) http, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    ngOnDestroy() {
        this.subscriptions.forEach(sb => sb.unsubscribe());
    }
}
