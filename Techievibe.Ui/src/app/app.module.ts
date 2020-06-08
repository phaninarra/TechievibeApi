//predefined modules
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http'
import { CommonModule } from '@angular/common'

//application modules
import { AppRoutingModule } from './app-routing.module';
import { QuillModule } from 'ngx-quill'
//components
import { AppComponent } from './app.component';
import { DashboardComponent } from './dashboard/dashboard.component';
import { HeaderComponent } from './shared/components/header/header.component'
import { FooterComponent } from './shared/components/footer/footer.component';
import { NotFoundComponent } from './shared/components/not-found/not-found.component'
import { LocationStrategy, PathLocationStrategy } from '@angular/common';
import { AdminHomeComponent } from './admin/admin-home/admin-home.component';
import {BlogComponent} from './blogging/blog/blog.component';
import { BlogPostComponent } from './blogging/blog-post/blog-post.component'
import {UrlSerializer} from '@angular/router';
import {CustomUrlSerializer} from './shared/utilities/custom-url-serializer';

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    HeaderComponent,
    FooterComponent,
    NotFoundComponent,
    AdminHomeComponent,
    BlogComponent,
    BlogPostComponent
  ],
  imports: [
    BrowserModule,
    CommonModule,
    AppRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    QuillModule,
    QuillModule.forRoot()
  ],
  providers: [{provide: LocationStrategy, useClass: PathLocationStrategy},
              {provide: UrlSerializer, useClass: CustomUrlSerializer}
              ],
  bootstrap: [AppComponent]
})
export class AppModule { }
