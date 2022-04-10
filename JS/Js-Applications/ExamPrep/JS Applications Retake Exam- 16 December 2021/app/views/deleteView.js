import * as theaterService from "../services/theatersService.js";

export const deletePage = (ctx) => {
    if(!ctx.user){
        ctx.page.redirect("/home");
    }

    const theaterId = ctx.params.theaterId;

    // bookService.getOne(bookId).then(book => {
    //     if(book._ownerId != ctx.user._id){
    //         ctx.page.redirect("/dashboard");

    //         throw "Not your book";
    //     } else {
            if(confirm('Are you sure?')){
                theaterService.del(theaterId);
                return ctx.page.redirect("/profile");
            } else {
                return ctx.page.redirect(`/details/${theaterId}`);
            }
      //  }


    //})
    //.then(() => ctx.page.redirect("/dashboard"))
    //.catch((err) => console.log(err));
}