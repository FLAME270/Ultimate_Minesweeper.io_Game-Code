/*Tyler Wiggins and Vrijesh Patel
    This is our own work
    Minesweeper.IO project for CST-247*/

var sw = {
    //Handles the stopwatch views
    elapsedTime: null,
    timer: null,
    now: 0,
    init: function () {
        // Get HTML element for displaying the time
        sw.elapsedTime = document.getElementById("sw-time");
    },

    // Advance time
    tick: function () {
        // Calculate time
        sw.now++;
        var remain = sw.now;
        var hours = Math.floor(remain / 3600);
        remain -= hours * 3600;
        var mins = Math.floor(remain / 60);
        remain -= mins * 60;
        var secs = remain;

        // Update HTML element in hr, min, sec format
        if (hours < 10) { hours = "0" + hours; }
        if (mins < 10) { mins = "0" + mins; }
        if (secs < 10) { secs = "0" + secs; }
        sw.elapsedTime.innerHTML = hours + ":" + mins + ":" + secs;
    },

    // Starts the timer
    start: function () {
        sw.timer = setInterval(sw.tick, 1000);
    },

    // Stops the timer timer
    stop: function () {
        clearInterval(sw.timer);
        sw.timer = null;
    },

    // Resets the timer
    reset: function () {
        if (sw.timer != null) { sw.stop(); }
        sw.now = -1;
        sw.tick();
    }
};

// Initializes the timer
if (sw.timer == null) {
    sw.init();
};