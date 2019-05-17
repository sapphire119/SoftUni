function solution(command) {
    switch (command) {
        case "upvote":
            this.upvotes++;
            break;
        case "downvote":
            this.downvotes++;
            break;
        case "score":
            let output = [];
            let totalVotes = this.upvotes + this.downvotes;
            if (totalVotes > 50) {
                let greaterNumber = Math.max(this.upvotes, this.downvotes);
                let inlationNumber = Math.ceil(greaterNumber * 0.25);

                output.push(inlationNumber + this.upvotes);
                output.push(inlationNumber + this.downvotes);
            } else{
                output.push(this.upvotes);
                output.push(this.downvotes);
            }

            let rating = "";
            let hotRatingReq = totalVotes * 0.66;

            let balanceOfVotes = this.upvotes - this.downvotes;

            //if positive votes > 66% of all votes ---> rating = "hot"
            //if balance >= 0 (non-negative) && this.votes (either votes are more than 100) > 100 ----> rating = "controversial"
            // balance < 0 ---> rating = "unpopular"
            //totalVotes < 10 or no other rating is met , rating = "new" regardless of balance

            if (this.upvotes > hotRatingReq && totalVotes >= 10) rating = "hot";
            else if (balanceOfVotes >= 0 && (this.upvotes >= 100 || this.downvotes >= 100)) rating = "controversial";
            else if (balanceOfVotes < 0 && totalVotes >= 10) rating = "unpopular";
            else if (totalVotes < 10) rating = "new";
            else rating = "new";

            output.push(balanceOfVotes);
            output.push(rating);

            return output;
    }
}

let forumPost = {
    id: '1',
    author: 'pesho',
    content: 'hi guys',
    upvotes: 0,
    downvotes: 2
};

debugger;
solution.call(forumPost, 'upvote');

let answer = solution.call(forumPost, 'score');
let expected = [1, 0, 1, 'new'];

console.log(answer);

// compareScore(expected, answer);
//
// function compareScore(expected, answer) {
//     expect(expected[0]).to.equal(answer[0], 'Incorrect number of upvotes');
//     expect(expected[1]).to.equal(answer[1], 'Incorrect number of downvotes');
//     expect(expected[2]).to.equal(answer[2], 'Incorrect score');
//     expect(expected[3]).to.equal(answer[3], 'Incorrect rating');
// }

//
// let post = {
//     id: '3',
//     author: 'emil',
//     content: 'wazaaaaa',
//     upvotes: 100,
//     downvotes: 100
// };
// solution.call(post, 'upvote');
// solution.call(post, 'downvote');
// let score = solution.call(post, 'score');   // [127, 127, 0, 'controversial']
// console.log(score);
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// solution.call(post, 'downvote');
// debugger;
// score = solution.call(post, 'score');
// console.log(score);
