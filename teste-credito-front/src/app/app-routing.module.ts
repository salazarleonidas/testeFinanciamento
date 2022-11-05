import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { HomeComponent } from './home/home.component';
import { FinanciamentoComponent } from './financiamento/financiamento.component'

const routes: Routes = [
  { path: '', pathMatch:'full', redirectTo: '/home' },
  { path: 'home', component: HomeComponent },
  { path: 'financiamento', component: FinanciamentoComponent },
];

@NgModule({
    imports: [ RouterModule.forRoot(routes) ],
    exports: [ RouterModule ]
  })
  export class AppRoutingModule {
    static components = [ 
        HomeComponent,
        FinanciamentoComponent
    ];
}