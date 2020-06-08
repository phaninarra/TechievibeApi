import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { DashboardComponent } from './dashboard/dashboard.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component';
import { BlogComponent } from './blogging/blog/blog.component';
import { AdminHomeComponent } from './admin/admin-home/admin-home.component';
import { BlogPostComponent } from './blogging/blog-post/blog-post.component';

const routes: Routes = [
  {path: "", component: DashboardComponent},
  {path: "blog", component: BlogComponent},
  {path: "blog/:postid/:title", component: BlogPostComponent},
  {path: "notfound", component: NotFoundComponent},
  {path: "admin", component: AdminHomeComponent},
  {path: "**", redirectTo: "notfound"}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
