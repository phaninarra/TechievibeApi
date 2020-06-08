export class BlogTitles {
    postId: number
    postTitle: string

    constructor(private paramPostId:number, private paramPostTitle: string){
        this.postId = paramPostId,
        this.postTitle = paramPostTitle
    }
}