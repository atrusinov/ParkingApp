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
        debugger;
        let simulationArray = shuffle(data);

        for (let i = 0; i < simulationArray.length; i++) {

            setTimeout(function (y) {
                if (command === 1) {
                    $(`#output #${simulationArray[i]}.freeSpot`).removeClass('freeSpot').addClass('takenSpot');
                }
                else {
                    $(`#output #${simulationArray[i]}.takenSpot`).removeClass('takenSpot').addClass('freeSpot');
                }
            }, i * 10, i);
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
                const { parkingLevels } = response;
                var el = $('#output');
                parkingLevels.forEach((parkingLot) => {
                    let parkButton = `<button type="button" class="btn btn-primary" onclick="parkCar(${parkingLot.level})">Park Car</button>`;
                    let removeButton = `<button type="button" class="btn btn-danger" onclick="removeCar(${parkingLot.level})">Remove Car</button>`;

                    el.append(`<p><strong>Level ${parkingLot.level}</strong></p>`);
                    el.append(parkButton);
                    el.append(removeButton);
                    el.append(`<hr\>`);

                    parkingLot.parkingSlots = parkingLot.parkingSlots.sort(function (a, b) { return a.spaceNumber - b.spaceNumber; });
                    const { level, parkingSlots } = parkingLot;

                    parkingSlots.forEach(({ id, spaceNumber, isTaken }) => {
                        const currentSlot = `<span id="${id}" class='${isTaken ? "takenSpot" : "freeSpot"}'>${spaceNumber}</span>`;
                        el.append(currentSlot);
                    });
                });
            }
        });
    }
    GetParkingLot();
};

function shuffle(array) {
    var currentIndex = array.length, temporaryValue, randomIndex;
    
    while (0 !== currentIndex) {
        
        randomIndex = Math.floor(Math.random() * currentIndex);
        currentIndex -= 1;        
        temporaryValue = array[currentIndex];
        array[currentIndex] = array[randomIndex];
        array[randomIndex] = temporaryValue;
    }

    return array;
}