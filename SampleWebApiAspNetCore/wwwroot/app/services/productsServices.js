
//This handles retrieving data and is used by controllers. 3 options (server, factory, provider) with
//each doing the same thing just structuring the functions/data differently.
app.service('productsService', function ($http) {

	this.getProducts = function () {
		return $http.get("/api/v1/product");
	};

	this.insertProduct = function (product) {
		debugger;
		return $http.post("/api/v1/product",
			{
				date: product.date,
				title: product.title,
				description: product.description,
				legislation: product.legislation,
				type: product.type,
				startTime: product.startTime,
				endTime: product.endTime,
				variableDates: product.variableDates
			});
	};

	this.deleteProduct = function (id) {
		return $http.delete("/api/v1/product/" + id, {id:id});
	};
	this.updateProduct = function (product) {
		debugger;

		var json = {
			id: product.id,
			date: product.date,
			title: product.title,
			description: product.description,
			legislation: product.legislation,
			type: product.type,
			startTime: product.startTime,
			endTime: product.endTime,
			variableDates: product.variableDates
		};

		return $http.put("/api/v1/product/" + product.id, json);
		//return json;
		//return $http.put("/api/v1/product/" + product.id, product);
	};

});
