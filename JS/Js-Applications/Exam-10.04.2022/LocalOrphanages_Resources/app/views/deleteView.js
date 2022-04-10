import * as orphService from "../services/orphService.js";

export const deletePage = (ctx) => {
    if(!ctx.user){
        ctx.page.redirect("/home");
    }

    const postId = ctx.params.postId;

    // orphService.getOne(postId).then(p => {
    //     if(p._ownerId != ctx.user._id){
    //         ctx.page.redirect("/dashboard");

    //         throw "Not your post";
    //     } else {
            if(confirm('Are you sure?')){
                orphService.del(postId);
                return ctx.page.redirect("/dashboard");
            } else {
                return ctx.page.redirect(`/details/${postId}`);
            }
      //  }


    //})
    //.then(() => ctx.page.redirect("/dashboard"))
    //.catch((err) => console.log(err));
}