angular.module('demoApp').controller('MovieDialogController', function ($uibModalInstance, DemoAppService, movie, title) {
    var vm = this;

    vm.title = title;
    vm.movie = movie;

    vm.save = function () {
        if (vm.movie.id == undefined) {
            DemoAppService.addNewMovie(vm.movie).then(function (response) {
                $uibModalInstance.close({ response: response });
            });
        }
        else {
            DemoAppService.updateMovie(vm.movie).then(function (response) {
                $uibModalInstance.close({response: response});
            });
        }
    
    };

    vm.cancel = function () {
        $uibModalInstance.dismiss('cancel');
    };
});