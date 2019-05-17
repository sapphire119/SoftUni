const handlers = {};

$(() => {
  const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');
    // home page routes
    this.get('/index.html', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    // user routes
    this.get('#/register', handlers.getRegister);
    this.post('#/register', handlers.registerUser);

    this.get('#/login', handlers.getLogin);
    this.post('#/login', handlers.postLoginUser);

    this.get('#/logout', handlers.logoutUser);

    // ADD YOUR ROUTES HERE
    //<a href="#/dashboard">Dashboard</a>
    //                     <a class="button" href="#/myPets">My Pets</a>
    //                     <a class="button" href="#/addPet">Add Pet</a>
    // this.get("#/dashboard", handlers.getDashboard);
    // this.get("#/myPets", handlers.getMyPets);
    // this.get("#/addPet", handlers.getAddPet);
  });
  app.run("#/");
});