import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { BlogComponent } from './blog/blog.component';

const routes: Routes = [
  {path: "", component: DashboardComponent},
  {path: "blog", component: BlogComponent},
  {path: "notfound", component: NotFoundComponent},
  {path: "**", redirectTo: "notfound"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
