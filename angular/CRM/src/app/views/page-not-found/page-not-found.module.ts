import {NgModule} from '@angular/core';
import {Routes, RouterModule} from '@angular/router';



import {PageNotFoundComponent} from './page-not-found.component';

/**
 * Add module routing here.
 * @type {[{path: string; component: PageNotFoundComponent}]}
 */
const routes: Routes = [
    {
        path: '**',
        component: PageNotFoundComponent
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(routes)
    ],
    declarations: [PageNotFoundComponent],
    exports: [RouterModule],
})
export class PageNotFoundModule {
}
