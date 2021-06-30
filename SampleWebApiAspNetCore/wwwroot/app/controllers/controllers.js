
//This controller retrieves data from the productsService and associates it with the $scope
//The $scope is ultimately bound to the products view
app.controller('ProductsController', function ($scope, productsService, $http) {

	init();

	function init() {
		productsService.getProducts().success(function (data) {
			debugger;
			$scope.products = data;
		});
	}

	$scope.insertProduct = function () {

		debugger;
		if ($scope.id != null) {
			productsService.updateProduct($scope).success(function (success) {
				debugger;
				for (var i = $scope.products.length - 1; i >= 0; i--) {
					if ($scope.products[i].id === success.id) {
						$scope.products[i].id = success.id,
						$scope.products[i].date = success.date,
						$scope.products[i].title = success.title,
						$scope.products[i].description = success.description,
						$scope.products[i].legislation = success.legislation,
						$scope.products[i].type = success.type,
						$scope.products[i].startTime = success.startTime,
						$scope.products[i].endTime = success.endTime,
						$scope.products[i].variableDates = success.variableDates
						break;
					}
				}
				$('.page-modal').toggle(500);

			});
		}
		else {
			productsService.insertProduct($scope).success(function (data, status, headers, config) {
				$scope.products.push(
					{
						id: data.id,
						date: data.date,
						title: data.title,
						description: data.description,
						legislation: data.legislation,
						type: data.type,
						startTime: data.startTime,
						endTime: data.endTime,
						variableDates: data.variableDates
					});
			});
			$('.page-modal').toggle(500);
		}

		$scope.id = null;
		$scope.title = '';
		$scope.description = '';
		$scope.legislation = '';
		$scope.type = '';
		$scope.startTime = '';
		$scope.endTime = '';
		$scope.variableDates = '';
	};

	$scope.deleteProduct = function (id) {
		debugger;
		productsService.deleteProduct(id).success(function (success) {

			for (var i = $scope.products.length - 1; i >= 0; i--) {
				if ($scope.products[i].id === id) {
					$scope.products.splice(i, 1);
					break;
				}
			}

		});
	};
	$scope.updateProduct = function (product) {

		$scope.title = '';
		$scope.description = '';
		$scope.legislation = '';
		$scope.type = '';
		$scope.startTime = '';
		$scope.endTime = '';
		$scope.variableDates = '';

		$scope.id = product.id;
		$scope.title = product.title;
		$scope.description = product.description;
		$scope.legislation = product.legislation;
		$scope.type = product.type;
		$scope.startTime = product.startTime;
		$scope.endTime = product.endTime;
		$scope.variableDates = product.variableDates;
		$('.page-modal').toggle(500)


	};
});