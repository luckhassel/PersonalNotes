import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { TaskEditComponent } from './task-edit/task-edit.component';
import { TaskComponent } from './task-list/task-list.component';

const routes: Routes = [
  {
    path: '',
    component: TaskComponent
  },
  {
    path: 'create',
    component: TaskEditComponent
  },
  {
    path: 'update/:id',
    component: TaskEditComponent
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class TaskRoutingModule { }
