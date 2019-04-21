var updateStats = function () {
    $.get("/api/playerstats", function (stats) {
        $('#playerHealthBar').html(stats.health + "%");
        $('#playerHealthBar').attr('aria-valuenow', stats.health).css('width', stats.health + "%");
        $('#playerEnergyBar').html(stats.energy + "%");
        $('#playerEnergyBar').attr('aria-valuenow', stats.energy).css('width', stats.energy + "%");
        $('#playerHappinessBar').html(stats.happiness + "%");
        $('#playerHappinessBar').attr('aria-valuenow', stats.happiness).css('width', stats.happiness + "%");
        $("#playerSwagger").html(stats.swagger);
        $("#playerMoney").html(stats.moneyOnHand);
    });
};

window.setInterval(function () {
    updateStats();
}, 30000);