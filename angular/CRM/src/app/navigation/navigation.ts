import { FuseNavigation } from '@fuse/types';

export const navigation: FuseNavigation[] = [
  {
    id: 'applications',
    title: 'Applications',
    translate: 'NAV.APPLICATIONS',
    type: 'group',
    children: [
      {
        id: 'dashboards',
        title: 'Dashboards',
        translate: 'NAV.DASHBOARDS',
        type: 'collapsable',
        icon: 'dashboard',
        children: [
          {
            id: 'analytics',
            title: 'Analytics',
            type: 'item',
            url: '/apps/dashboards/analytics',
          },
          {
            id: 'project',
            title: 'Project',
            type: 'item',
            url: '/apps/dashboards/project',
          },
        ],
      },
    ],
  },
  {
    id: 'contacts',
    title: 'Contacts',
    translate: 'NAV.CONTACTS',
    type: 'item',
    icon: 'account_box',
    url: '/apps/contacts',
  },
  {
    id: 'to-do',
    title: 'To-Do',
    translate: 'NAV.TODO',
    type: 'item',
    icon: 'check_box',
    url: '/apps/todo',
    badge: {
      title: '3',
      bg: '#FF6F00',
      fg: '#FFFFFF',
    },
  },
];
