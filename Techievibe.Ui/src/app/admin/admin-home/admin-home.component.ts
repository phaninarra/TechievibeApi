import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { BlogPosts } from 'src/app/models/blog-posts';
import { PostCategories } from 'src/app/models/post-categories';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-admin-home',
  templateUrl: './admin-home.component.html',
  styleUrls: ['./admin-home.component.css']
})
export class AdminHomeComponent implements OnInit {

  editorForm: FormGroup;
  editorPreviewText: string;
  constructor(private dataService: DataService) { }

  ngOnInit(): void {
    this.editorForm = new FormGroup({
      'editor': new FormControl(null),
      'inputBlogPostTitle': new FormControl(null),
      'inputBlogPostCategory': new FormControl(null)
    })  
  }

  onSubmit(): void {
    this.editorPreviewText = this.editorForm.get('editor').value;
    //console.log(this.editorForm.get('editor').value);
  }

  maxLength(e): void {
    if(e.editor.getLength() > 200000)
      e.editor.deleteText(10, e.editor.getLength());
  }

  saveBlogPost(): void {
    console.log("at first step");
    var postBody = this.editorForm.get('editor').value;
    console.log("at second step");
    var postTitle = this.editorForm.get('inputBlogPostTitle').value;
    console.log("at third step");
    var postCategoryName = this.editorForm.get('inputBlogPostCategory').value;
    console.log("at fourth step");
    var postCategory = new PostCategories(0, postCategoryName, null);
    var postDate = new Date().toJSON();
    console.log(postDate);
    var blogPost = new BlogPosts(3, postTitle, postBody, "Phani Narra", postDate, 5, 0, 0, 0, postCategory)
    console.log("at last step");
    this.dataService.createBlogPost(blogPost).subscribe(response => {
      console.log(response);
    })
  }
}
