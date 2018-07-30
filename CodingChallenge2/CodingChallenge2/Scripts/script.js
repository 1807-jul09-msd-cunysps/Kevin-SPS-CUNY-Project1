function populateHeader(jsonObj) {


     var h1 = document.createElement("h1");
     h1.textContent = jsonObj.squadName;
     header.appendChild(h1)

    var h2 = document.createElement("h2");
    var p1 = document.createElement("p");
    p1.textContent = 'Hometown: ' + jsonObj.homeTown + ' Formed: ' + jsonObj.formed;
    h2.appendChild(p1);
    //+ ' formed: ' + jsonObj.formed;
    header.appendChild(p1);

    var body = document.getElementsByTagName("body");
   
}

function showHeroes(jsonObj) {
    var heroArray = jsonObj['members'];
    for (var i = 0; i < heroArray.length; i++) {
        var heroArticle = document.createElement('article');
        var h2 = document.createElement('h2');
        h2.textContent = heroArray[i].name;

            var p1 = document.createElement('p');
            p1.textContent = 'Age: ' + heroArray[i].age
         

            var p2 = document.createElement('p');
            p1.textContent = 'Secret Identity: ' + heroArray[i].secretIdentity

            heroArticle.appendChild(h2)
            heroArticle.appendChild(p1);
            heroArticle.appendChild(p2);
            section.appendChild(heroArticle);


    }

}
window.onload = loadpage;

function loadpage() {
    var requestURL = 'https://mdn.github.io/learning-area/javascript/oojs/json/superheroes.json';
    var request = new XMLHttpRequest();
    request.open('GET', requestURL);
    request.responseType = 'json';
    request.send();
    request.onload = function () {
        var superHeroes = request.response;

        populateHeader(superHeroes);

        showHeroes(superHeroes);

    }

}
