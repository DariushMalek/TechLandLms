import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { UserManagementComponent } from './user-management.component';
import { RolesComponent } from './roles/roles.component';
import { AppUserComponent } from './users/app-user.component';
import { AppUserUpdateComponent } from './users/app-user-update/app-user-update.component';
import { RoleUpdateComponent } from './roles/role-update/role-update.component';
import { ChangePasswordComponent } from './change-password/change-password.component';
import { RoleFeatureComponent } from './role-feature/role-feature.component';

const routes: Routes = [
    {
        path: '',
        component: UserManagementComponent,
        children: [
            {
                path: 'appUserList',
                component: AppUserComponent,
            },
            {
                path: 'app-user/add',
                component: AppUserUpdateComponent,
            },
            {
                path: 'app-user/edit/:id',
                component: AppUserUpdateComponent,
            },
            {
                path: 'roles',
                component: RolesComponent,
            },
            {
                path: 'roles/add',
                component: RoleUpdateComponent,
            },
            {
                path: 'roles/edit/:id',
                component: RoleUpdateComponent,
            },
            {
                path: 'change-password/:id',
                component: ChangePasswordComponent
            },
            {
                path: 'roleFeature/:roleId',
                component: RoleFeatureComponent,
            },
            { path: '', redirectTo: 'appUserList', pathMatch: 'full' },
            { path: '**', redirectTo: 'appUserList', pathMatch: 'full' },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class UserManagementRoutingModule { }
