import { ModuleWithProviders, NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AppGuard } from './shared/guard/app.guard';
import { UserGuard } from './shared/guard/user.guard';

const routes: Routes = [
  {path: '', loadChildren: () => import('./lazy-module/views/login/login-routing.module').then(m => m.LoginRoutingModule), canActivate: [UserGuard]},
  {path: 'register', loadChildren: () => import('./lazy-module/views/login/login-routing.module').then(m => m.LoginRoutingModule), canActivate: [UserGuard]},
  {path: 'task', loadChildren: () => import('./lazy-module/views/task/task-routing.module').then(m => m.TaskRoutingModule), canActivate: [AppGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})

export class AppRoutingModule { 
  static forRoot(): ModuleWithProviders<AppRoutingModule> {
    return {
      ngModule: AppRoutingModule,
    };
  }
}
