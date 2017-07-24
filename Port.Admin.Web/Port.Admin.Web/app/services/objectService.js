angular.module('app')
    .factory('objectService', [

        function () {
            var objectServiceFactory = {};

            var _removeElementFromArray = function (item, array) {
                var index = array.indexOf(item);
                if (index > -1) {
                    array.splice(index, 1);
                }
                return array;
            }


            objectServiceFactory.removeElementFromArray = _removeElementFromArray;
            return objectServiceFactory;
        }
    ]);