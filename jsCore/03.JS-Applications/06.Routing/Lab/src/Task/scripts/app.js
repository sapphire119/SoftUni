$(() => {
    const app = Sammy('#main', function () {
        //Ако получаваме template-a като чист html без грешка,
        //значи трябва да include-нем handlebars ↓ ↓ ↓ ↓ ↓ ↓ ↓
        this.use("Handlebars", "hbs");

        this.get("#/home", function () {
            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs"
            }).then(function () {
                this.partial("./templates/home/home.hbs");
            });
        });

        this.get("#/about", function () {
            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs"
            }).then(function () {
                this.partial("./templates/about/about.hbs");
            });
        });

        this.get("#/login", function () {
            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs",
                loginForm: "./templates/login/loginForm.hbs"
            }).then(function () {
                this.partial("./templates/login/loginPage.hbs");
            });
        });

        this.post("#/login", function (context) {
            console.log(context);
        });

        this.get("#/register", function () {
            this.loadPartials({
                header: "./templates/common/header.hbs",
                footer: "./templates/common/footer.hbs",
                registerForm: "./templates/register/registerForm.hbs"
            }).then(function () {
                this.partial("./templates/register/registerPage.hbs");
            });
        });

        this.post("#/register", function (context) {
            console.log(context);
        });
    });

    app.run('#/home');
});