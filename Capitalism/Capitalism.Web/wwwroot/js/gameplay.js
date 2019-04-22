var updateStats = function () {
    $.get("/api/playerstats", function (stats) {
        $('#playerId').val(stats.id);
        $('#playerHealthBar').html(stats.health + "%");
        $('#playerHealthBar').attr('aria-valuenow', stats.health).css('width', stats.health + "%");
        $('#playerEnergyBar').html(stats.energy + "%");
        $('#playerEnergyBar').attr('aria-valuenow', stats.energy).css('width', stats.energy + "%");
        $('#playerHappinessBar').html(stats.happiness + "%");
        $('#playerHappinessBar').attr('aria-valuenow', stats.happiness).css('width', stats.happiness + "%");
        $("#playerSwagger").html(numberWithCommas(stats.swagger));
        $("#playerMoney").html(numberWithCommas(stats.moneyOnHand));
    });
};

toastr.options.closeButton = true;
var displayActionResults = function (results) {
    $.each(results, function (index, result) {
        if (result.hasMessage) {
            switch (result.resultType) {
                case 1:     // Info
                    toastr.info(result.message);
                    break;
                case 2:     // Success
                    toastr.success(result.message);
                    break;
                case 3:     // Warning
                    toastr.warning(result.message);
                    break;
                case 4:     // Error
                    toastr.error(result.message);
                    break;
            }
        }
    });
};

var numberWithCommas = function (number) {
    var parts = number.toString().split(".");
    parts[0] = parts[0].replace(/\B(?=(\d{3})+(?!\d))/g, ",");
    return parts.join(".");
};

window.setInterval(function () {
    updateStats();
}, 30000);