import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { BlogPosts } from '../models/blog-posts';
import { catchError } from 'rxjs/operators'; 
import { throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {
  private headers = new HttpHeaders({'Accept' : 'application/json', 'Content-Type' : 'application/json'})
  private options = {
    headers: this.headers
  }

  constructor(private http: HttpClient) { }

  public getBlogPosts() {
    var res = this.http.get<BlogPosts[]>("http://localhost:59302/api/Posts/list", this.options).pipe(catchError((err) => {
      console.log("some error occurred", err);
      return throwError(err);
    }));
    return res;
  }

  public getBlogPostById(postId: number) {
    var res = this.http.get<BlogPosts>(`http://localhost:59302/api/Posts/${postId}`, this.options);
    
    return res;
  }

  public createBlogPost(post: BlogPosts) {
    var res = this.http.post<BlogPosts>(`http://localhost:59302/api/Posts/create`, JSON.stringify(post), this.options); 
    return res;
  }

}