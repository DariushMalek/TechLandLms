import { Component,  OnInit, ViewChild } from '@angular/core';
import { FormBuilder } from '@angular/forms';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { UserAccount } from '../../../shared/modeles/user-account';
import { UserAccountService } from '../../../shared/services/user-account.service';
import { TableService } from '../../../_metronic/shared/crud-table';
import { TechlandGridComponent } from '../../../_metronic/shared/crud-table/components/techland-grid/techland-grid.component';

@Component({
  selector: 'app-user-account',
  templateUrl: './user-account.component.html',
  styleUrls: ['./user-account.component.scss']
})
export class UserAccountComponent 
    implements
    OnInit{
    @ViewChild('techLandGrid') techLandGrid: TechlandGridComponent<UserAccount>;
 
    constructor( public userAccountService: UserAccountService      
    )
    {
    }

    ngOnInit(): void {
        
    }


}
