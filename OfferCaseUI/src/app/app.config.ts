import { ApplicationConfig, importProvidersFrom } from '@angular/core';
import { provideRouter } from '@angular/router';

import { routes } from './app.routes';
import { en_US, provideNzI18n } from 'ng-zorro-antd/i18n';
import { registerLocaleData } from '@angular/common';
import en from '@angular/common/locales/en';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { provideAnimations } from '@angular/platform-browser/animations';
import { NzTableModule } from 'ng-zorro-antd/table';
import { CommonModule } from '@angular/common';
registerLocaleData(en);

export const appConfig: ApplicationConfig = {
  providers: [provideRouter(routes), provideNzI18n(en_US), importProvidersFrom(CommonModule), importProvidersFrom(FormsModule), importProvidersFrom(HttpClientModule), importProvidersFrom(NzTableModule), provideAnimations()]
};
