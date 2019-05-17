$(document).ready(() => {
    const app = Sammy("#root", function () {
        this.use("Handlebars", "hbs"); //Това се използва за load-ване на handlebars във Sammy.

        this.route("get", "#/", function () {
        });

        this.route("get", "#/about", function (context) {
           this.swap("<h2>About page</h2>");
        });

        this.get("#/products/(:productId)?", function (context) {
            this.name = `${context.params.productId}`;
            this.price = 99;

            this.loadPartials({
                //Зареждаме partial-ите, на които depend-ваме
                product: "./product.hbs" //Url paths to partials
            }).then(function () {
                this.partial("./productsPage.hbs");
            });
        });

        this.post("#/form", function (context) {
            console.log(context.params["username"]);
            console.log(context.params["password"]);
        });

        this.redirect("#/other/route");
        this.redirect("#", "other", "route");

        this.notFound = function () {
            console.log("handled");
        }
    });

    app.run("#/");
});