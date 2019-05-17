const handlers = {};

$(() => {
  const app = Sammy('#root', function () {
    this.use('Handlebars', 'hbs');
    // home page routes
    this.get('/index.html', handlers.getHome);
    this.get('/', handlers.getHome);
    this.get('#/home', handlers.getHome);

    // user routes
    this.get('#/user/register', handlers.getRegister);
    this.post('#/user/register', handlers.registerUser);

    this.get('#/user/login', handlers.getLogin);
    this.post('#/user/login', handlers.postLoginUser);

    this.get('#/user/details', handlers.getUserDetails);

    this.get('#/logout', handlers.logoutUser);

    // ADD YOUR ROUTES HERE

    this.get('#/events/create', handlers.getCreateEvent);
    this.post('#/events/create', handlers.postCreateEvent);

    this.get('#/events/details/:id', handlers.getDetailsEvent);

    this.get('#/events/edit/:id', handlers.getEditEvent);
    this.post('#/events/edit/:id', handlers.postEditEvent);

    this.get('#/events/join/:id', handlers.getJoinEvent);
    this.get('#/events/delete/:id', handlers.getDeleteEvent);
    //<a href="#/dashboard">Dashboard</a>
    //                     <a class="button" href="#/myPets">My Pets</a>
    //                     <a class="button" href="#/addPet">Add Pet</a>
    // this.get("#/dashboard", handlers.getDashboard);
    // this.get("#/myPets", handlers.getMyPets);
    // this.get("#/addPet", handlers.getAddPet);
  });
  app.run("#/");
});