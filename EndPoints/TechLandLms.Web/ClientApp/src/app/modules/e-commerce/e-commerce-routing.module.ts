import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { ECommerceComponent } from './e-commerce.component';
import { CustomersComponent } from './customers/customers.component';
import { ProductsComponent } from './products/products.component';
import { ProductEditComponent } from './products/product-edit/product-edit.component';
import { UserAccountComponent } from './user-account/user-account.component';

const routes: Routes = [
    {
        path: '',
        component: ECommerceComponent,
        children: [
            {
                path: 'userAccount',
                component: UserAccountComponent,
            },
            {
                path: 'customers',
                component: CustomersComponent,
            },
            {
                path: 'products',
                component: ProductsComponent,
            },
            {
                path: 'product/add',
                component: ProductEditComponent
            },
            {
                path: 'product/edit',
                component: ProductEditComponent
            },
            {
                path: 'product/edit/:id',
                component: ProductEditComponent
            },
            { path: '', redirectTo: 'customers', pathMatch: 'full' },
            { path: '**', redirectTo: 'customers', pathMatch: 'full' },
        ],
    },
];

@NgModule({
    imports: [RouterModule.forChild(routes)],
    exports: [RouterModule],
})
export class ECommerceRoutingModule { }
