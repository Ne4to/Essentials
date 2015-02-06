$(function () {
	$("#clickMe").click(function () {
		$.getJSON('data19.json', function(data) {
			var items = [];
			$.each(data, function(key, value) {
				items.push("<li id='" + key + "'>" + value + "</li>");
			});

			$("")
		});
	});
});