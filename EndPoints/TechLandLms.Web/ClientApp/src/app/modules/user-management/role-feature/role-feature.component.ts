import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { RoleFeature } from '../../../AppCore/models/RoleModel/role-feature.model';
import { RoleService } from '../../../AppCore/services/RoleService/role.service';
@Component({
  selector: 'app-role-feature',
  templateUrl: './role-feature.component.html',
  styleUrls: ['./role-feature.component.scss']
})
export class RoleFeatureComponent implements OnInit {
    roleFeatureList: RoleFeature[];
    roleId: any;
    sub;
    constructor(private _activatedroute: ActivatedRoute, private _roleService: RoleService) {

        
    }

    ngOnInit(): void {
        this.sub = this._activatedroute.paramMap.subscribe(params => {
            console.log(params);
            this.roleId = params.get('roleId');
            this.getFeatureList(this.roleId);
        });
 
  }

    getFeatureList(roleId: number) {
        this._roleService.getFeatureListWithRoleStatus(roleId).subscribe(data => {
            this.roleFeatureList = data;

        }, error => {
                console.log(error);
        })

    }

    ngOnDestroy() {
        this.sub.unsubscribe();
    }
}
