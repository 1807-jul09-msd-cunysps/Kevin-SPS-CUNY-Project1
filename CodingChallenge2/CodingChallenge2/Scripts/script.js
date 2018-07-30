function populateHeader(jsonObj) {


     var h1 = document.createElement("h1");
     h1.textContent = jsonObj.squadName;
     header.appendChild(h1)

    var h2 = document.createElement("h2");
    var p1 = document.createElement("p1");
    p1.textContent = 'Hometown: ' + jsonObj.homeTown;
    h2.appendChild(p1);
    //+ ' formed: ' + jsonObj.formed;
    header.appendChild(h2);

    //    var h2 = document.createElement("h2");
    //        var p = document.createElement("p");
    //        p.textContent = jsonObj.homeTown;
    //     header.appendChild(p);
    //document.appendChild(header);





    var body = document.getElementsByTagName("body");
   
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
//function showHeroes()