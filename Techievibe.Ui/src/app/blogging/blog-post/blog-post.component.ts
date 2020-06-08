import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { DataService } from 'src/app/services/data.service';
import { Title } from '@angular/platform-browser';
import { BlogPosts } from 'src/app/models/blog-posts';
import { DatePipe } from '@angular/common';

@Component({
  selector: 'app-blog-post',
  templateUrl: './blog-post.component.html',
  styleUrls: ['./blog-post.component.css']
})
export class BlogPostComponent implements OnInit {
  post: BlogPosts
  pipe = new DatePipe('en-US');
  isBlogPostError: boolean = false;
  constructor(private titleService: Title, private dataService: DataService, private route: ActivatedRoute) { 
    
  }

  ngOnInit(): void {
    var currentPostId = this.route.snapshot.paramMap.get('postid');

    this.dataService.getBlogPostById(currentPostId as unknown as number).subscribe(
      response => {
        this.post = response;
        this.post.postDate = this.pipe.transform(response.postDate, 'longDate')
      },
      error => {
          this.isBlogPostError = true;
      }
    );



  }

}
