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