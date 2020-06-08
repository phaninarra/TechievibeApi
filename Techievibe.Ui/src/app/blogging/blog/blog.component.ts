import { Component, OnInit } from '@angular/core';
import { Title } from '@angular/platform-browser';
import {DataService} from '../../services/data.service'
import {HttpClient, HttpHandler} from '@angular/common/http'
import { BlogPosts } from '../../models/blog-posts';
import { DatePipe } from '@angular/common';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogTitles } from 'src/app/models/blog-titles';

@Component({
  selector: 'app-blog',
  templateUrl: './blog.component.html',
  styleUrls: ['./blog.component.css']
})
export class BlogComponent implements OnInit {
  postsList: BlogPosts[]
  postsTitles: BlogTitles[] 
  isBlogPostsError: boolean
  pipe = new DatePipe('en-US');

  constructor(private titleService: Title, private dataService: DataService, private router: Router) {
    titleService.setTitle("Blog Posts | All Categories | TechieVibe");
}

  ngOnInit() {
    this.postsList = new Array<BlogPosts>();
    this.postsTitles = new Array<BlogTitles>();
    this.getBlogPosts();
  }

  public getBlogPosts() {
    var result = this.dataService.getBlogPosts().subscribe(
      response => {
        this.postsList = response.map(item => {
          this.postsTitles.push(new BlogTitles(item.postId, item.postTitle));

          const threeDots = "...";
          if(item.postTitle.length > 80) {
            item.postTitle = item.postTitle.substring(0, 80) + threeDots; 
          }

          return new BlogPosts(
            item.postId,
            item.postTitle,
            item.postBody,
            item.postAuthor,
            this.pipe.transform(item.postDate, 'longDate'),
            item.postReadingTime,
            item.postLikeCount,
            item.postCommentCount,
            item.postCategoryId,
            item.postCategory
          )
        })
      },
      error => {
          this.isBlogPostsError = true;
      },
      () => {
        console.log("service call completed");
      }
    )

    console.log("result is : " + result);
  }

  navigateToBlogPost(postId : number){
    //Add dashes in place of spaces
    let titleInRoute: String = this.postsTitles.filter(x=>x.postId==postId)[0].postTitle.split(' ').join('-');
    this.router.navigate(['/blog/'+ postId + '/' + titleInRoute]);
 }

 navigateToBlogPostComments(postId : number){
  //Add dashes in place of spaces
  let titleInRoute: String = this.postsTitles.filter(x=>x.postId==postId)[0].postTitle.split(' ').join('-');
  this.router.navigate(['/blog/'+ postId + '/' + titleInRoute + '#comments']);
}
 
}
