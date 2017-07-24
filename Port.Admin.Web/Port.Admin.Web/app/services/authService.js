angular.module('app').factory('authService', function ($http, $q, $state, localStorageService, serviceUrl, stateManager, accountService) {

    var authServiceFactory = {};

    var _authentication = {
        isAuth: false,
        username: "",
        nootbaseUserInfo: {},
        roleId: null

    };



    var _saveRegistration = function (registration) {
        _logOut();

        return $http.post(serviceUrl + 'api/account/register', registration).then(function (response) {
            return response;
        });
    };

    var _login = function (userLoginData) {
        var loginData = userLoginData;
        var data = "grant_type=password&username=" + loginData.username + "&password=" + loginData.password;

        var deferred = $q.defer();

        $http.post(serviceUrl + '/Token', data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
            localStorageService.set('authorizationData', { token: response.access_token, username: loginData.username });
            console.log("RESPONSE: " + JSON.stringify(response));
            console.log('Login Successful. Setting Access token in local storage...');
            _authentication.isAuth = true;
            _authentication.username = loginData.username;

            accountService.getUserInfoByUsername(loginData.username).then(function (result) {
                var userInformation = result;
                console.log("userInformation: " + JSON.stringify(userInformation));
                _authentication.roleId = userInformation.Role.RoleId;
                _authentication.nootbaseUserInfo = userInformation;
                _authentication.NootHubUserId = userInformation.NootHubUserId;
                localStorageService.set('nootbaseUserInfo', { nootBaseUserInfo: userInformation, Role: userInformation.Role });
                localStorageService.set('nootbaseUserId', { nootUserId: userInformation.NootHubUserId });
            });




            deferred.resolve(response);

        }, function (err, status) {
            _logOut();
            deferred.reject(err);
        });
        return deferred.promise;
    };

    var _mockLogin = function (loginData) {
        _authentication.isAuth = true;
        _authentication.username = loginData.username;
        localStorageService.set('authorizationData', { token: "123-321-123-321-123", username: loginData.username, userId: 1, roleId: 2 });
        return true;
    };

    var _mockCheckAuthentication = function (loginData) {
        return true;
    }

    var _alert = function (message) {
        alert(message);
    }

    var _logOut = function () {
        localStorageService.remove('authorizationData');
        localStorageService.remove('UserProfileId');
        localStorageService.remove('UserProfile');
        localStorageService.remove('nootbaseUserInfo');
        localStorageService.remove('nootbaseUserId');
        _authentication.isAuth = false;
        _authentication.username = "";


        $state.go('app.login');
    };

    var _fillAuthData = function () {

        var authData = localStorageService.get('authorizationData');
        if (authData) {
            _authentication.isAuth = true;
            _authentication.username = authData.username;
        }
    }

    var _getUsername = function () {
        var authData = localStorageService.get('authorizationData');
        if (authData) {
            return _authentication.username;
        } else {
            return null;
        }
    }

    var _getNootUserId = function () {
        var authNootUserId = localStorageService.get('nootbaseUserId').nootUserId;
        if (authNootUserId) {
            return authNootUserId;
        } else {
            return null;
        }
    }


    var _checkAuthentication = function () {
        var authData = localStorageService.get('authorizationData');
        //If Empty
        if (authData == null || authData.token == null) {
            _logout();
            $state.go("login");
            return { roleId: "", rememberMe: true }
        }

        //If not empty, validate
        if (authData && authData.token) {
            var url = serviceBase + 'api/AuthenticateCTRL/authenticate/ValidateSafeId';
            var userToken = authData.token;
            var request = {
                token: userToken,
                password: authData.password ? authData.password : ''
            };
            return $http.post(url, request)
                .then(function (response) {
                    if (response.data.success) {
                        _safeauthentication.authenticated = true;
                        _safeauthentication.userName = response.data.contactContext.contact.fullName;
                        _safeauthentication.email = "";
                        _safeauthentication.contactId = response.data.contactContext.contact.contactId;
                        _safeauthentication.safeId = response.data.contactContext.contact.safeId;
                        _safeauthentication.roleId = response.data.contactContext.contact.roleId;
                        _safeauthentication.contactActions = response.data.contactContext.role.actions;
                        _safeauthentication.userApps = response.data.userApps;
                        _safeauthentication.password = response.data.contactContext.contact.password;
                        localStorageService.set('authToken', response.data.generatedToken);
                        if ($state.current.name == "") {
                            $state.go("SearchMyView.Tabs.MyViewTab");
                        } else {
                            $state.go($state.current.name);
                        }

                    }
                    else {
                        _safeauthentication.authenticated = false;
                        _safeauthentication.userName = "";
                        _safeauthentication.email = "";
                        _safeauthentication.contactId = -1;
                        _safeauthentication.safeId = "";
                        _safeauthentication.roleId = "";
                        _safeauthentication.contactActions = [];
                        _safeauthentication.userApps = [];
                        _safeauthentication.password = "";
                        //localStorageService.remove('authenticationData');
                        $state.go("LoginModal.Login");

                    }
                    localStorageService.set('authenticationData', _safeauthentication);

                    return response;
                });
        }
        else {
            $state.go("LoginModal.Login");

            return { safeId: "", roleId: "", rememberMe: true }
        }

    };

    var _mockCheckToken = function (token) {
        if (token) {
            return true;
        }
    }

    var _mockCheckAuthentication = function () {
        var authdata = localStorageService.get('authorizationData');
        if (authdata) {
            //mock check token
            var result = _mockCheckToken(authdata.token);
            if (result) {
                _fillAuthData();
            }
            return result;
        } else {
            return false;
        }
    }

    var _getAuthentication = function () {

        var authData = localStorageService.get('authorizationData');
        return authData;
    }

    var _isAuth = function () {
        var authData = localStorageService.get('authorizationData');
        //TODO: Validate Refresh token better
        if (authData.token) {
            return true;
        } else {
            return false;
        }
    }

    var _checkAuthentication = function () {
        var authData = localStorageService.get('authorizationData');
        //If Empty
        if (authData == null || authData.token == null) {
            _logout();
            $state.go("login");
            return { roleId: "", rememberMe: true }
        }
    }



    authServiceFactory.getNootUserId = _getNootUserId;
    authServiceFactory.checkAuthentication = _checkAuthentication;
    authServiceFactory.isAuth = _isAuth;
    authServiceFactory.saveRegistration = _saveRegistration;
    authServiceFactory.login = _login;
    authServiceFactory.logOut = _logOut;
    authServiceFactory.fillAuthData = _fillAuthData;
    authServiceFactory.authentication = _authentication;
    authServiceFactory.getUserName = _getUsername;
    authServiceFactory.mockLogin = _mockLogin;
    authServiceFactory.alert = _alert;
    authServiceFactory.mockCheckAuthentication = _mockCheckAuthentication;
    authServiceFactory.getAuthentication = _getAuthentication;


    return authServiceFactory;


});