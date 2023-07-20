
function initMap() {
    var mapElement = document.getElementById("map");
    var direccionBodega = mapElement.dataset.direccion;

    var geocoder = new google.maps.Geocoder();

    geocoder.geocode({ address: direccionBodega }, function (results, status) {
        if (status === google.maps.GeocoderStatus.OK) {
            var latlng = results[0].geometry.location;

            var mapOptions = {
                center: latlng,
                zoom: 15
            };

            var map = new google.maps.Map(document.getElementById("map"), mapOptions);

            var marker = new google.maps.Marker({
                position: latlng,
                map: map,
                title: "Ubicación de la bodega"
            });
        } else {
            alert("La geocodificación de la dirección no tuvo éxito debido a: " + status);
        }
    });
}
        