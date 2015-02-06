$(function () {
	//var version = "1.2";
	//alert(window.version);

	//document.write("")

	$("#main").append("<img src='plus-8.png' alt='Click me to see the paragraph' id='clickMe' />");

	$("#clickMe").click(function () {
		if ($("#message").is(":visible")) {
			$("#message").hide("fast");
			$("#clickMe").attr("src", "plus-8.png");
		} else {
			$("#message").show("fast");
			$("#clickMe").attr("src", "minus-8.png");
		}
	});

	$("#message").hide();
});

//var version = "1.2";
//var AETRIS = {};
//AETRIS.version = "1.2";

//AETRIS.planet = {
//	id: 23,
//	name: "aaa"
//}

