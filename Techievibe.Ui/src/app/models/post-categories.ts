import { BlogPosts } from './blog-posts';

export class PostCategories {
    constructor(
        public categoryId: number,
        public categoryName: string,
        public blogPosts: BlogPosts[]
        ){}
}