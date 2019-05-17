let assert = require("chai").assert;
let SoftUnify = require("./SoftUniFy");

describe("SoftUniFy", function () {
    let softUnify;
    beforeEach(function () {
        softUnify = new SoftUnify();
    });

    describe("function downloadSong", function () {
        it('should add the given information to the allSongs in format', function () {
            let expected = { "pesho": { "rate": 0, "votes": 0, "songs": [ 'tiriram - asdasdasd' ] } };

            softUnify.downloadSong("pesho", "tiriram", "asdasdasd");

            assert.deepEqual(softUnify.allSongs, expected);
        });
        it('songs property, should contain all songs from the current artist in format', function () {
            let expected = [ 'tiriram - asdasdasd',
                'Spatiq - asdasdasd',
                'AsdDsa - asdasdasd',
                'Ivan4o - Mariika' ];

            softUnify.downloadSong("pesho", "tiriram", "asdasdasd");
            softUnify.downloadSong("pesho", "Spatiq", "asdasdasd");
            softUnify.downloadSong("pesho", "AsdDsa", "asdasdasd");
            softUnify.downloadSong("pesho", "Ivan4o", "Mariika");
            let actual = softUnify.allSongs["pesho"]["songs"];

            assert.deepEqual(actual, expected);
        });
        it('should return the entire Class', function () {
            assert.instanceOf(softUnify.downloadSong("pesho", "tiriram", "asdasdasd"), SoftUnify);
        });
    });

    describe("function playSong(song)", function () {
        it('should search all already downloaded songs and returns them in format', function () {
            let expected = "pesho:\n" +
                "tiriram - asdasdasd\n" +
                "Gosho:\n" +
                "tiriram - asdasdasd\n" +
                "Ivan:\n" +
                "tiriram - asdasdasd";

            softUnify.downloadSong("pesho", "tiriram", "asdasdasd");
            softUnify.downloadSong("Gosho", "tiriram", "asdasdasd");
            softUnify.downloadSong("Ivan", "tiriram", "asdasdasd");

            let actual = softUnify.playSong("tiriram").trim();
            assert.equal(actual, expected);
            // assert.equal(actual.trim(), expected);
        });
        it('should return a message if there are no songs', function () {
            let currentSong = "tiriram";
            let expected =`You have not downloaded a ${currentSong} song yet. Use SoftUniFy's function downloadSong() to change that!`;

            assert.equal(softUnify.playSong(currentSong), expected);
        });
        it('should should return the following string if the one song we have given is not found', function () {
            let currentSong = "tiriram";
            let expected =`You have not downloaded a ${currentSong} song yet. Use SoftUniFy's function downloadSong() to change that!`;

            softUnify.downloadSong("pesho", "melqCherPiper", "asdasdsad");
            softUnify.downloadSong("gosho", "melqCherPiper", "asdasdsad");
            softUnify.downloadSong("ivan", "melqCherPiper", "asdasdsad");

            assert.equal(softUnify.playSong(currentSong), expected);
        });
    });

    describe("function songsList()", function () {
        it('should get all already downloaded songs in format', function () {
            let expected = "tiriram - asdasdasd\n" +
                "is - king\n" +
                "Gulabi - asdsad\n" +
                "Jiraf - I am a jiraf\n" +
                "durvarq - ot selo\n" +
                "Eazy - you are not g-eazy\n" +
                "Phenomenon - YEAAAAAAAAAAAAAAH";

            softUnify.downloadSong("pesho", "tiriram", "asdasdasd");
            softUnify.downloadSong("pesho", "is", "king");
            softUnify.downloadSong("gosho", "Gulabi", "asdsad");
            softUnify.downloadSong("ivan", "Jiraf", "I am a jiraf");
            softUnify.downloadSong("ivan", "durvarq", "ot selo");
            softUnify.downloadSong("petko", "Eazy", "you are not g-eazy");
            softUnify.downloadSong("stamat", "Phenomenon", "YEAAAAAAAAAAAAAAH");

            let actual = softUnify.songsList.trim();
            assert.equal(actual, expected);
        });
        it('If we do not have at least one downloaded song return the following string', function () {
            let expected = `Your song list is empty`;

            let actual = softUnify.songsList.trim();
            assert.equal(actual, expected);
        });
    });

    describe("function rateArtist()", function () {

        //divideByZero equals 0
        it('should sum the values of all votes on the current artist and return the average rate', function () {
            // let softUnify = new SoftUniFy();
            let expected = 110;
            softUnify.downloadSong("Pesho", "tiriram", "asdasd");
            //ArtistName, Rating(Number), Vote(by default)

            softUnify.rateArtist("Pesho", 100);
            softUnify.rateArtist("Pesho", 200);
            softUnify.rateArtist("Pesho", 30);

            assert.equal(softUnify.rateArtist("Pesho"), expected);
        });
        it('should return 0 if second arg is NaN', function () {
            softUnify.downloadSong("Pesho", "tiriram", "asdasd");

            let actual = softUnify.rateArtist("Pesho", "asdasdasd");

            assert.equal(actual, 0);
        });

        it('should return a message if artist does not exist', function () {
            let artistToLookFor = "Pesho";
            let expected = `The ${artistToLookFor} is not on your artist list.`;

            let actual = softUnify.rateArtist(artistToLookFor);

            assert.equal(actual, expected);
        });
    });

    it('should contain allSongs property that is initialized as an empty object', function () {
        assert.property(softUnify, "allSongs");
        assert.isEmpty(softUnify.allSongs);
    });
});

describe("TODO …", function() {
    describe("TODO …", function() {
        it("TODO …", function() {
            // TODO: …
        });
        // TODO: …
    });

    it("TODO …", function() {
        // TODO: …
    });
    // TODO: …
});
