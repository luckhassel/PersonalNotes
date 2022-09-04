import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { LoginModule } from './lazy-module/views/login/login.module';
import { TaskModule } from './lazy-module/views/task/task.module';
import { ApiInterceptor } from './shared/interceptor/api.interceptor';
import { TaskEditModule } from './lazy-module/views/task/task-edit/task-edit.module';
import { DatePipe } from '@angular/common';
import {MatSnackBarModule} from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    HttpClientModule,
    MatSnackBarModule,
    LoginModule,
    TaskModule,
    TaskEditModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: ApiInterceptor, multi: true }, DatePipe],
  bootstrap: [AppComponent]
})
export class AppModule { }
