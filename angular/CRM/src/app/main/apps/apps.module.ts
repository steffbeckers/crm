import { NgModule } from '@angular/core';
import { RouterModule, Route } from '@angular/router';

import { FuseSharedModule } from '@fuse/shared.module';

const routes: Route[] = [
  {
    path: 'dashboards/analytics',
    loadChildren: './dashboards/analytics/analytics.module#AnalyticsDashboardModule',
  },
  {
    path: 'dashboards/project',
    loadChildren: './dashboards/project/project.module#ProjectDashboardModule',
  },
  {
    path: 'contacts',
    loadChildren: './contacts/contacts.module#ContactsModule',
  },
  {
    path: 'todo',
    loadChildren: './todo/todo.module#TodoModule',
  },
];

@NgModule({
  imports: [RouterModule.forChild(routes), FuseSharedModule],
})
export class AppsModule {}
