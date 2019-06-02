import { InMemoryDbService } from 'angular-in-memory-web-api';

import { ProjectDashboardDb } from 'app/fake-db/dashboard-project';
import { AnalyticsDashboardDb } from 'app/fake-db/dashboard-analytics';
import { ContactsFakeDb } from 'app/fake-db/contacts';
import { TodoFakeDb } from 'app/fake-db/todo';

export class FakeDbService implements InMemoryDbService {
  createDb(): any {
    return {
      // Dashboards
      'project-dashboard-projects': ProjectDashboardDb.projects,
      'project-dashboard-widgets': ProjectDashboardDb.widgets,
      'analytics-dashboard-widgets': AnalyticsDashboardDb.widgets,

      // Contacts
      'contacts-contacts': ContactsFakeDb.contacts,
      'contacts-user': ContactsFakeDb.user,

      // Todo
      'todo-todos': TodoFakeDb.todos,
      'todo-filters': TodoFakeDb.filters,
      'todo-tags': TodoFakeDb.tags,
    };
  }
}
