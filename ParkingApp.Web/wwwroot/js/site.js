function parkCar(level) {

    let notification = document.querySelector("#notify");
    notification.style = "none";
    notification.textContent = "";

    $.ajax({
        type: "POST",
        url: `home/ParkRandomCar?level=${level}`,
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

function removeCar(level) {
    let notification = document.querySelector("#notify");
    notification.style = "none";
    notification.textContent = "";

    $.ajax({
        type: "POST",
        url: `home/RemoveRandomCar?level=${level}`,
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
    function GetParkingLot() {
        $.ajax({
            url: '/home/GetParkingLot',
            type: 'GET',
            dataType: 'json',
            cache: false,
            success: function (response) {
                //debugger;
                const { parkingLevels } = response;
                var el = $('#output');
                parkingLevels.forEach((obj) => {
                    let parkButton = `<button type="button" class="btn btn-primary" onclick="parkCar(${obj.level})">Park Car</button>`;
                    let removeButton = `<button type="button" class="btn btn-danger" onclick="removeCar(${obj.level})">Remove Car</button>`;

                    el.append(`<p><strong>Level ${obj.level}</strong></p>`);
                    el.append(parkButton);
                    el.append(removeButton);
                    el.append(`<hr\>`);

                    obj.parkingSlots = obj.parkingSlots.sort(function (a, b) { return a.spaceNumber - b.spaceNumber; });
                    const { level, parkingSlots } = obj;
                    console.log(obj);
                    
                    parkingSlots.forEach(({ id,spaceNumber,isTaken}) => {
                        const currentSlot = `<span id="${id}" class='${isTaken ? "takenSpot" : "freeSpot"}'>${spaceNumber}</span>`;
                        el.append(currentSlot);
                    });                    
                });
            }
        });
    }
    GetParkingLot();
};
