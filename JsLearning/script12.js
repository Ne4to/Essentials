var batwing = {
	status: "Ready",
	rescueBatman: function () {
		document.write("Locating his transponder... initiating launch...");
	}
}

//if (batwing.status === "Ready") {
//	batwing.rescueBatman();
//}

var utilities = {
	printAllmembers: function (targetObject) {
		for (i in targetObject) {
			document.write("<br />" + targetObject[i]);
		}
	}
}

//utilities.printAllmembers(batwing);
//utilities.printAllmembers(new Boolean(false));

//var i_am_empty = {};
//utilities.printAllmembers(i_am_empty);

var planet = {
	id: 34,
	name: "Imtemesta Nox",
	faction: {
		factionId: 2,
		name: "Nex",
		notification: function () {
			document.write("<br />Nex aliance... unite!");
		}
	},
	cities: [
		{ locationId: 15, name: "Gladius" },
		{ locationId: 16, name: "Chalybs" },
		{ locationId: 17, name: "Ensis" }
	]
}

//planet.faction.notification();
//document.write("<br />" + planet.cities[1].name);
//document.write("<br />" + planet.name);
//planet.name = "Vultus";
//document.write("<br />" + planet.name);

//var z = planet;
//document.write(z.name);
//z.name = "aaa";
//document.write(planet.name);

//if (typeof planet.defence === "undefined") {
//	planet.defence = "Ion Canon";
//}
//document.write(planet.defence);

//for (var member in planet) {
//	document.write("<br />" + member + " ==> " + planet[member]);
//}

function car(make, model, year) {
	this.make = make;
	this.model = model;
	this.year = year;
}

var myCar = new car("Honda", "Orthia", 1987);
var myOtherCar = new car("Ford", "Focus", 2007);

//alert(myCar.model);
//alert(myOtherCar.model);
alert(typeof myCar);