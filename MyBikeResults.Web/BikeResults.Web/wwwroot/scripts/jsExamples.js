export function showAlert(message) {
    alert(message);
}

export function readJson(message) {
    fetch("./bikes_response.json")
        .then(response => {
            return response.json();
        })
        .then(jsondata => console.log(jsondata)).then(jsondata=>document.textContent = jsondata);
}

export function readJsonB() {
    window.returnArrayAsync = () => {
        DotNet.invokeMethodAsync('BikeResults.Web', 'ReturnArrayAsync')
            .then(data => {
                console.log(data);
            });
    };
}
export function BlockID() {
    const values = [10];
    fetch("./bikes_response.json")
        .then(function(response) {
            if (!response.ok) {
                throw new Error("HTTP error, status = " + response.status);
            }
            return response.json();
        })
        .then(function(json) {
            
            for (var i = 0; i < json.length; i++)
            {
                values[i] = json[i].BikeId +
                        "," +
                        json[i].Make +
                        "," +
                        json[i].Model +
                        "," +
                        json[i].Year +
                        "," +
                        json[i].Displacement +
                        "," +
                        json[i].Price +
                        "," +
                        json[i].Terrain +
                        "," +
                    json[i].Description;
                values.push(values[i]);

            }
        });
    return values;
}
const container = document.getElementById("container");
export function JSMethod() 
{
    var myList = document.querySelector('ul');
    fetch("./bikes_response.json")
    .then(function (response) {
            if (!response.ok) {
                throw new Error("HTTP error, status = " + response.status);
            }
            return response.json();
    })       
    .then(function (json) {
        for (var i = 0; i < json.length; i++) {
            var listItem = document.createElement('td');
            listItem.innerHTML = ' <td> ' + json[i].BikeID + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Make + '</td> ';
            listItem.innerHTML += ' <td> ' + json[i].Model + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Year + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Displacement + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Price + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Terrain + '</td>';
            listItem.innerHTML += ' <td> ' + json[i].Description + '</td>';
            myList.appendChild(listItem);
        }
    })
    //.then(jasonData => console.log(jasonData))
    .catch(function (error) {
        var p = document.createElement('p');
        p.appendChild(
            document.createTextNode('Error: ' + error.message)
        );
        document.body.insertBefore(p, myList);
    });
}