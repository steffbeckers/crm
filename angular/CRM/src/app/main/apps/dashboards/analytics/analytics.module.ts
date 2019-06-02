import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MatButtonModule, MatFormFieldModule, MatIconModule, MatMenuModule, MatSelectModule, MatTabsModule } from '@angular/material';
import { AgmCoreModule } from '@agm/core';
import { ChartsModule } from 'ng2-charts';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { FuseSharedModule } from '@fuse/shared.module';
import { FuseWidgetModule } from '@fuse/components/widget/widget.module';

import { AnalyticsDashboardComponent } from 'app/main/apps/dashboards/analytics/analytics.component';
import { AnalyticsDashboardService } from 'app/main/apps/dashboards/analytics/analytics.service';
import { environment } from 'environments/environment';

const routes: Routes = [
  {
    path: '**',
    component: AnalyticsDashboardComponent,
    resolve: {
      data: AnalyticsDashboardService,
    },
  },
];

@NgModule({
  declarations: [AnalyticsDashboardComponent],
  imports: [
    RouterModule.forChild(routes),

    MatButtonModule,
    MatFormFieldModule,
    MatIconModule,
    MatMenuModule,
    MatSelectModule,
    MatTabsModule,

    AgmCoreModule.forRoot({
      apiKey: environment['maps-api-key'],
    }),
    ChartsModule,
    NgxChartsModule,

    FuseSharedModule,
    FuseWidgetModule,
  ],
  providers: [AnalyticsDashboardService],
})
export class AnalyticsDashboardModule {}
