import { Component, EventEmitter, OnInit, ViewChild } from '@angular/core';
import { Router } from '@angular/router';
import { AppUserModel } from '../../../AppCore/models/AppUserModel/app-user.model';
import { AppUserService } from '../../../AppCore/services/AppUserService/app-user.service';
import { TechlandGridComponent } from '../../../_metronic/shared/crud-table/components/techland-grid/techland-grid.component';
import { IMenuItem } from '../../../_metronic/shared/crud-table/models/menu-item.model';

@Component({
    selector: 'app-users',
    templateUrl: './app-user.component.html',
    styleUrls: ['./app-user.component.scss']
})
export class AppUserComponent implements
    OnInit {
    menuItems: IMenuItem[];

    constructor(public appUserService: AppUserService, private router: Router) {
        this.setMenu();
    }

    ngOnInit(): void {
    }

    onEditEntity(entity) {
        this.router.navigate(['/user-management/app-user/edit/' + entity.id]);
    }

    setMenu() {
        this.menuItems = [
            {
                name: "op1",
                title: "عملیات 1",
                icon: "dialpad"
            },
            {
                name: "op2",
                title: "عملیات 2",
                icon: "dialpad"
            },
        ];
    }

    menuItemClick(param) {
        console.log("onOp1 test");
    }

}
