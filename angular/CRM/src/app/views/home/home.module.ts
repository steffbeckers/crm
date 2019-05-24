import {NgModule} from '@angular/core';
import {RouterModule, Routes} from '@angular/router';
import {HomeComponent} from './home.component';
import {HomeGuard} from './home.guard';



/**
 * Add module routing here.
 * @type {[{path: string; component: HomeComponent; canActivate: [HomeGuard]}]}
 */
const routes: Routes = [
    {
        path: 'home',
        component: HomeComponent,
        canActivate: [HomeGuard]
    }
];

@NgModule({
    declarations: [
        HomeComponent,
    ],
    imports: [
        RouterModule.forChild(routes)
    ],
    exports: [RouterModule],
    providers: [HomeGuard]
})

export class HomeModule {
}
