let assert = require("chai").assert;
let FilmStudio = require('./FilmStudio');

describe("FilmStudio", function () {
    let filmStudio;
    beforeEach(function () {
        filmStudio = new FilmStudio("My Studio");
    });

    describe("Instantiation with one parameter", function () {
        it('should instantiate', function () {
            assert.property(filmStudio, "name");
            assert.equal(filmStudio.name, "My Studio");

            assert.property(filmStudio, "films");
            assert.isArray(filmStudio.films);
        });
    });

    describe("Function makeMovie()", function () {
        it('should creates a film in object format (film name and all roles)', function () {
            let expected = { filmName: 'pesho',
                filmRoles:
                    [ { role: 'main', actor: false },
                        { role: 'semi', actor: false } ] };

            let actual = filmStudio.makeMovie("pesho", ["main", "semi"]);
            // console.log(filmStudio.makeMovie("pesho", ["main", "semi"]));
            // let actual = ;

            assert.deepEqual(actual, expected);
        });
        it('should add a number if film already exists', function () {
            let expected = { filmName: 'pesho 2',
                filmRoles:
                    [ { role: 'main', actor: false },
                        { role: 'semi', actor: false } ] };

            filmStudio.makeMovie("pesho", ["main", "semi"]);

            let actual = filmStudio.makeMovie("pesho", ["main", "semi"]);
            assert.deepEqual(actual, expected);
        });
        it('should throw (\'Invalid arguments count\') if arguments are not 2', function () {
            let expected = "Invalid arguments count";
            
            assert.throws(() => filmStudio.makeMovie("Pesho", ["main", "semi"], "bai ivan"), expected);
        });

        it('should throw Invalid arguments', function () {
            let expected = "Invalid arguments";

            assert.throws(() => filmStudio.makeMovie(123, ["main", "role"]), expected);
            assert.throws(() => filmStudio.makeMovie("Pesho", "bai ivan"), expected);
        });
    });

    describe("Function casting()", function () {
        beforeEach(function () {
            filmStudio.makeMovie("Rockstar", ["main", "semi"]);
        });

        it('if our film studio contains a film which has that role, the given actor gets it.', function () {
            let expected = "You got the job! Mr. Pesho you are next main in the Rockstar. Congratz!";

            let actual = filmStudio.casting("Pesho", "main");

            assert.equal(actual, expected);
        });

        it('should return a message if there is no role of that type', function () {
            let actor = "Pesho";
            let role = "some";
            let expected = `${actor}, we cannot find a ${role} role...`;

            let actual = filmStudio.casting(actor, role);

            assert.equal(actual, expected);
        });

        it('should return a message if there are no films', function () {
            let studio = new FilmStudio("Test");
            let expected = `There are no films yet in ${studio.name}.`;

            let actual = studio.casting("Pesho", "main");

            assert.equal(actual, expected);
        });
    });
    
    describe("Function lookForProducer()", function () {
        it('if the given filmName exists, the function prints its info (film name and cast…). ', function () {
            let expected = "Film name: Pesho\n" +
                "Cast:\n" +
                "false as main\n" +
                "false as semi";

            filmStudio.makeMovie("Pesho", ["main", "semi"]);
            let actual = filmStudio.lookForProducer("Pesho").trim();

            assert.equal(actual, expected);
        });

        it('should throw an error if film doesnt exist', function () {
            let filmName= "Pesho";

            let expected = `${filmName} do not exist yet, but we need the money...`;

            assert.throws(() => filmStudio.lookForProducer(filmName), expected);
        });
    });
});