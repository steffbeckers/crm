'use strict';

module.exports = {
  mongodb: {
    name: 'mongodb',
    connector: 'mongodb',
    host: 'localhost',
    port: 27017,
    user: process.env.CRM_MONGODB_USER,
    password: process.env.CRM_MONGODB_PASSWORD,
    database: 'CRM',
  },
};
