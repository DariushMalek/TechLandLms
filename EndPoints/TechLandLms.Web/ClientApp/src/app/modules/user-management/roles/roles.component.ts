import { Component, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { RoleModel } from '../../../AppCore/models/RoleModel/role.model';
import { RoleService } from '../../../AppCore/services/RoleService/role.service';
import { TechlandGridComponent } from '../../../_metronic/shared/crud-table/components/techland-grid/techland-grid.component';
import { IMenuItem } from '../../../_metronic/shared/crud-table/models/menu-item.model';

@Component({
    selector: 'app-roles',
    templateUrl: './roles.component.html',
    styleUrls: ['./roles.component.scss']
})
export class RolesComponent implements
    OnInit {
    menuItems: IMenuItem[];

    constructor(public roleService: RoleService,private _router: Router) { }

    ngOnInit(): void {
        this.setMenuItems();
    }

    setMenuItems() {
        this.menuItems = [
            {
                name: "setFeature",
                title: "امکانات نقش",
                icon: "dialpad"
            }
        ];
    }

    menuItemClick(param) {
        if (param.opName == 'setFeature') {
            this._router.navigate(['/user-management/roleFeature/' + param.entity.id]);
        }
    }

}
