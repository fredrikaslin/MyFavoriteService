function hej() {
    var webSocket = new WebSocket("ws://" + window.location.hostname +

        "/IDGWeb/api/IDGWebSocket");

    webSocket.onopen = function () {

        console.log("hej connected... hahahaha");

    };
}