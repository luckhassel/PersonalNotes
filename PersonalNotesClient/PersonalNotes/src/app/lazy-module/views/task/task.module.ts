import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TaskRoutingModule } from './task-routing.module';
import {MatTableModule} from '@angular/material/table';
import {MatButtonModule} from '@angular/material/button';
import { FlexLayoutModule } from '@angular/flex-layout';
import {MatIconModule} from '@angular/material/icon';
import { RouterModule } from '@angular/router';
import { TaskComponent } from './task-list/task-list.component';
import { HeaderModule } from 'src/app/shared/component/header/header/header.module';


@NgModule({
  declarations: [
    TaskComponent
  ],
  imports: [
    CommonModule,
    TaskRoutingModule,
    MatTableModule,
    MatButtonModule,
    FlexLayoutModule,
    MatIconModule,
    RouterModule,
    HeaderModule
  ]
})
export class TaskModule { }
