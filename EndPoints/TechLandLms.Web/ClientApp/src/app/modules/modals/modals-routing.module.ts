import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ModalsComponent } from './modals.component';

const routes: Routes = [
    {
        path: '',
        component: ModalsComponent,
        children: [
            //{
            //    path: 'alert',
            //    component: AppUserComponent,
            //},
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ModalsRoutingModule { }
