function result(inputObj){
    function errorMessage(property) {
        return `Invalid request header: Invalid ${messageFormat(property)}`;
    }

    let messageFormat = (propertyName) => {
        let obj = {method: 'Method', uri: 'URI', version: 'Version', message: 'Message'};

        let currentMessageFormat = obj[propertyName];
        return currentMessageFormat
    };

    function checkForProperty(propertyName) {
        if (!inputObj.hasOwnProperty(propertyName)) {
            throw Error(errorMessage(propertyName));
        }

        return true;
    }

    function validateMethods(method){
        return ['GET', 'POST', 'DELETE', 'CONNECT'].indexOf(method);
    }
    
    function validVersionOfHttpProtocol(version) {
        return ['HTTP/0.9', 'HTTP/1.0', 'HTTP/1.1', 'HTTP/2.0'].indexOf(version);
    }

    if (!checkForProperty("method") || validateMethods(inputObj.method) < 0) {
        throw Error(errorMessage("method"));
    }

    let uriPattern = /^([a-zA-Z0-9.]+|\*)$/gm;

    if (!checkForProperty("uri") || !uriPattern.test(inputObj.uri)) {
        throw Error(errorMessage("uri"));
    }

    if (!checkForProperty("version") || validVersionOfHttpProtocol(inputObj.version) < 0) {
        throw Error(errorMessage("version"));
    }

    let messagePattern = /^[^\<\>\\\&\'\"]*$/gm;
    
    if (!checkForProperty("message") || !messagePattern.test(inputObj.message)){
        throw Error(errorMessage("message"));
    }

    return inputObj;
}

// let obj = result({
//     method: 'GET',
//     uri: 'svn.public.catalog',
//     version: 'HTTP/1.1',
//     message: ''
// });
//
result({
    method: 'POST',
    uri: 'home.bash',
    message: 'rm -rf /*'
});
