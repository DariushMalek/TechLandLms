import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MessengerComponent } from './messenger.component';
import { UserMessengerComponent } from './user-messenger/user-messenger.component';

const routes: Routes = [
    {
        path: '',
        component: MessengerComponent,
        children: [
            {
                path: 'messenger',
                component: UserMessengerComponent,
            },
            { path: '', redirectTo: 'messenger', pathMatch: 'full' },
            { path: '**', redirectTo: 'messenger', pathMatch: 'full' },
        ],
    },
];

@NgModule({
  declarations: [],
    imports: [
        RouterModule.forChild(routes)],
    exports: [RouterModule]
})
export class MessengerRoutingModule { }
