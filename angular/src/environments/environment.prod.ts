import { Environment } from '@abp/ng.core';

const baseUrl = 'http://localhost:4200';

export const environment = {
  production: true,
  application: {
    baseUrl,
    name: 'AbpIoTest',
    logoUrl: '',
  },
  oAuthConfig: {
    issuer: 'https://localhost:44310',
    redirectUri: baseUrl,
    clientId: 'AbpIoTest_App',
    responseType: 'code',
    scope: 'offline_access AbpIoTest',
  },
  apis: {
    default: {
      url: 'https://localhost:44310',
      rootNamespace: 'AbpIoTest',
    },
  },
} as Environment;
