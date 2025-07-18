import { ApplicationConfig, provideZoneChangeDetection } from '@angular/core';
import { provideRouter } from '@angular/router';
import {MatIconModule} from '@angular/material/icon';

import { routes } from './app.routes';
import { provideHttpClient, withFetch } from '@angular/common/http';

export const appConfig: ApplicationConfig = {
  providers: [provideHttpClient( withFetch()),provideZoneChangeDetection({ eventCoalescing: true }), provideRouter(routes), MatIconModule]
};
