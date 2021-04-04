import { Inject, Injectable, OnDestroy } from '@angular/core';
import { TableService } from '../../../_metronic/shared/crud-table';
import { HttpClient } from '@angular/common/http';
import { RoleModel } from '../../models/RoleModel/role.model';
import { RoleFeature } from '../../models/RoleModel/role-feature.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleService extends TableService <RoleModel> implements OnDestroy {

    ENTITY_CONTROLLER = `Role`;
    constructor(@Inject(HttpClient) http, @Inject('BASE_URL') baseUrl: string) {
        super(http, baseUrl);
    }

    ngOnDestroy() {
        this.subscriptions.forEach(sb => sb.unsubscribe());
    }

    getFeatureListWithRoleStatus(roleId: number): Observable<RoleFeature[]>  {
        return this.http.get<RoleFeature[]>(this.getApiUrl() + '/GetFeatureListWithRoleStatus/' + roleId);
    }

}
