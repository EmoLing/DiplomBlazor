ymaps.ready(init);
function init() {
    var myPlacemark;
    var myMap;
    var location = ymaps.geolocation.get();
    ymaps.geolocation.get().then(function (res) {
        var mapContainer = $('#map'),
            bounds = res.geoObjects.get(0).properties.get('boundedBy'),
            // Рассчитываем видимую область для текущей положения пользователя.
            mapState = ymaps.util.bounds.getCenterAndZoom(
                bounds,
                [mapContainer.width(), mapContainer.height()]
            );
        createMap(mapState);
    }, function (e) {
        // Если местоположение невозможно получить, то просто создаем карту.
        createMap({
            center: [55.751574, 37.573856],
            zoom: 2
        });
    });

    function createMap(state) {
        myMap = new ymaps.Map('map', state);

        $(function () {
            let list = $('#ad-photo-list').children();
            for (var i = 0; i < list.length; i++) {
                let latitude = list[i].getAttribute("data-latitude");
                let longitude = list[i].getAttribute("data-longitude");
                let dataKindOfAnimal = '/icons/' + list[i].getAttribute("data-kind-of-animal");
                let coordinates = {
                    latitude: latitude,
                    longitude: longitude,
                };

                setPlaceHolders(coordinates, dataKindOfAnimal);
            }
        })

        function setPlaceHolders(coordinates, dataKindOfAnimal) {

            var placemark = new ymaps.Placemark([coordinates.latitude, coordinates.longitude], {
                hintContent: 'Собственный значок метки',
                balloonContent: 'Это красивая метка'
            }
                , {
                    iconLayout: 'default#image',
                    iconImageHref: dataKindOfAnimal,
                    iconImageSize: [30, 42],
                });

            myMap.geoObjects.add(placemark);
        }
    }
}


