$(function () {
	$.datepicker.setDefaults($.datepicker.regional['ru']);

	$("#tabs").tabs();	
	//$("#tabs").tabs("add", "C9JS_16.html", "Click-a-bob");	

	//$('#tt').tabs('add', {
	//	title: title,
	//	content: content,
	//	closable: true
	//});

	//$("#datepicker").datepicker();
	$("#datepicker").datepicker({
		onSelect: function(dateText, inst) {
			
			var dateTypeVar = $('#datepicker').datepicker('getDate');
			var x = dateTypeVar.toISOString(); // Web API format
			$("#title").text("You picked: " + x + " " + new Date(x));
		}//,
		//gotoCurrent: true,
		//currentText: "Now"
	});

	$("#datepicker").datepicker("setDate", new Date("2015-02-06T12:06:17.3693369Z"));

	//$("#title").text("You picked: " + $("#datepicker").datepicker("getDate"));

	

	//$("#datepicker").datepicker({
	//  onSelect: function(dateText, inst) {
	//    $('#title').text("You picked: " + dateText);
	//  }
	//});
});