function register(){
  let username = document.getElementById('username').value;
  let email = document.getElementById('email').value;
  let password = document.getElementById('password').value;
  
  let result = document.getElementById('result');

  let emailPattern = /(.+)@(.+).(com|bg)/gm;

  if(username.length > 0 && password.length > 0 && emailPattern.test(email)){

    let h1Tag = document.createElement('h1');
    h1Tag.textContent = 'Successful Registration!';
    
    result.appendChild(h1Tag);

    let passwordLength = password.length;
    let passwordHash = '*'.repeat(passwordLength);
    
    result.innerHTML += `Username: ${username}`;
    result.appendChild(document.createElement('br'));

    result.innerHTML += `Email: ${email}`;
    result.appendChild(document.createElement('br'));

    result.innerHTML += `Password: ${passwordHash}`;
  }
}

function register() {
  let username = document.getElementById("username").value;
  let password = document.getElementById("password").value;
  
  let hiddenPassword = "";
  for(i=0; i<password.length; i++){
    hiddenPassword+="*";
  }

  let resultDiv = document.getElementById("result");

  let pattern = new RegExp(/(.+)@(.+).(com|bg)/);
  let email = document.getElementById("email").value;
  
  let matchResult = pattern.test(email);
  
  if(matchResult !== null && username.length > 0 && password.length > 0){
    
   setTimeout(() => {
     let heading = document.createElement("h1");
     heading.textContent = "Successful Registration!";

     resultDiv.appendChild(heading);

     resultDiv.innerHTML += ("Username: " + username);
     resultDiv.appendChild(document.createElement("br"));
     resultDiv.innerHTML += ("Email: " + email);
     resultDiv.appendChild(document.createElement("br"));
     resultDiv.innerHTML += ("Password: " + hiddenPassword);

   }, (5000));
  }

// function register() {
//     let username = document.getElementById('username').value;
//     let email = document.getElementById('email').value;
//     let password = document.getElementById('password').value;

//     if(username === ''){
//       return;
//     }

//     let emailPattern = /(.+)@(.+).(com|bg)/gm;

//     if(!emailPattern.test(email)){
//       return;
//     }

//     let passwordPattern = /\w+/;

//     if(password === '' || !passwordPattern.test(password)){
//       return;
//     }



//     let result = document.getElementById('result');

    

//     // let brTag1 = document.createElement('br');
//     // let brTag2 = document.createElement('br');
//     // let output = setTimeout(() => {
//     //   result.style.display = 'none';
//     // }, (5000));

//     let h1Tag = document.createElement('h1');
//     h1Tag.textContent = 'Successful Registration!';

//     let passwordLength = password.length;
//     let passwordHash = '*'.repeat(passwordLength);

//     let userTag = document.createElement('p');
//     userTag.textContent = `Username: ${username}`;

//     let emailTag = document.createElement('p');
//     emailTag.textContent = `Email: ${email}`;

//     let passwordTag = document.createElement('p');
//     passwordTag.textContent = `Password: ${passwordHash}`;

//     result.appendChild(h1Tag);
//     result.appendChild(userTag);
//     result.appendChild(emailTag);
//     result.appendChild(passwordTag);
//     // result.addEventListener('click', () => output);

//     // result.appendChild()
//     // result.append();
//     // result.appendChild(brTag1);
//     // result.append(`Email: ${email}`);
//     // result.appendChild(brTag2);
//     // result.append(`Password: ${passwordHash}`);

//     // let userTag = document.createElement('p');
//     // userTag.textContent = ;

//     // let passwordTag = document.createElement('p');
//     // passwordTag.textContent = ;

//     // let emailTag = document.createElement('p');
//     // emailTag.textContent = ;
  
//     // setTimeout(() => {
//     //   result.appendChild(h1Tag);

//     //   result.appendChild(userTag);
//     //   result.appendChild(emailTag);
//     //   result.appendChild(passwordTag); 
//     // }, 5000);

//     // setTimeout(() => {
//     //   result.style.display = 'none'
//     // }, 5000);
