import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { SharedComponent } from './shared.component';

//import { UserAccountComponent } from './user-account/user-account.component';

const routes: Routes = [
  {
    path: '',
    component: SharedComponent,
    children: [
      
        { path: '', redirectTo: 'userAccount', pathMatch: 'full' },
        { path: '**', redirectTo: 'userAccount', pathMatch: 'full' },
    ],
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SharedRoutingModule {}
