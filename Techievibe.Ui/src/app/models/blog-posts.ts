import { PostCategories } from './post-categories';

export class BlogPosts {
    constructor(
        public postId: number,
        public postTitle: string,
        public postBody: string,
        public postAuthor: string,
        public postDate: string,
        public postReadingTime: number,
        public postLikeCount: number, 
        public postCommentCount: number,
        public postCategoryId: number,
        public postCategory: PostCategories
        ){}
}