function parkCar(level) {

    let notification = document.querySelector("#notify");
    notification.style = "none";
    notification.textContent = "";

    $.ajax({
        type: "POST",
        url: `home/ParkCar?level=${level}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        
        $(`#output #${data.id}.freeSpot`).removeClass('freeSpot').addClass('takenSpot');
        notification.style = "block";
        notification.textContent = data.message;
    });

}

function parkCarById(id) {

    $.ajax({
        type: "POST",
        url: `home/parkCarById?id=${id}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {

        $(`#output #${data}.freeSpot`).removeClass('freeSpot').addClass('takenSpot');
    });

}

function removeCarById(id) {
    $.ajax({
        type: "POST",
        url: `home/removeCarById?id=${id}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {
        
        $(`#output #${data}.takenSpot`).removeClass('takenSpot').addClass('freeSpot');
    });

}

function removeCar(level) {

    let notification = document.querySelector("#notify");
    notification.style = "none";
    notification.textContent = "";

    $.ajax({
        type: "POST",
        url: `home/RemoveCar?level=${level}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {

        $(`#output #${data.id}.takenSpot`).removeClass('takenSpot').addClass('freeSpot');
        notification.style = "block";
        notification.textContent = data.message;
    });

}

function fillOrEmptyParking(command) {

    $.ajax({
        type: "POST",
        url: `home/FillOrEmptyParking?fillOrEmpty=${command}`,
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        error: function (xhr, status, errorThrown) {
            var err = "Status: " + status + " " + errorThrown;
            console.log(err);
        }
    }).done(function (data) {

        if (command === 1) {
            for (let i = 0; i < data.length; i++) {
                setTimeout(function (y) {

                    parkCarById(data[y]);

                }, i * 100, i);
            }
        }
        else {
            for (let i = 0; i < data.length; i++) {
                setTimeout(function (y) {

                    removeCarById(data[y]);

                }, i * 100, i);
            }
        }
    });

}

window.onload = function () {
    function GetData() {
        $.ajax({
            url: '/home/getdata',
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (response) {

                var el = $('#output');
                for (var obj of response.parkingLevels) {
                    let parkButton = `<button type="button" class="btn btn-primary" onclick="parkCar(${obj.level})">Park Car</button>`;
                    let removeButton = `<button type="button" class="btn btn-danger" onclick="removeCar(${obj.level})">Remove Car</button>`;

                    el.append(`<p><strong>Level ${obj.level}</strong></p>`);
                    el.append(parkButton);
                    el.append(removeButton);
                    el.append(`<hr\>`);

                    for (var level of obj.parkingSlots.sort(function (a, b) { return a.spaceNumber - b.spaceNumber; })) {
                        let currentSlot;
                        if (level.isTaken) {
                            currentSlot = `<span id="${level.id}" class="takenSpot">${level.spaceNumber}</span>`;
                        }
                        else {
                            currentSlot = `<span id="${level.id}" class="freeSpot">${level.spaceNumber}</span>`;
                        }
                        el.append(currentSlot);
                    }

                }
            }
        });
    }
    GetData();
};