const OB_FUNCTION = 0;
const OB_EVENT = 1;

function pbInvokeEvent(functionName, params) {
    var js;
    if (typeof params == "object") {
        js = JSON.stringify(params);
    } else {
        js = params;
    }
    const resultValue = chrome.webview.hostObjects.sync.pb.Invoke(functionName, OB_EVENT, js);
    return resultValue;
}

function pbInvokeEventAsync(functionName, params) {
    var js;
    if (typeof params == "object") {
        js = JSON.stringify(params);
    } else {
        js = params;
    }
    const resultValue = chrome.webview.hostObjects.pb.Invoke(functionName, OB_EVENT, js);
    return resultValue;
}

function pbInvokeFunction(functionName, params) {
    var js;
    if (typeof params == "object") {
        js = JSON.stringify(params);
    } else {
        js = params;
    }
    const resultValue = chrome.webview.hostObjects.sync.pb.Invoke(functionName, OB_FUNCTION, js);
    return resultValue;
}

function pbInvokeFunctionAsync(functionName, params) {
    var js;
    if (typeof params == "object") {
        js = JSON.stringify(params);
    } else {
        js = params;
    }
    const resultValue = chrome.webview.hostObjects.pb.Invoke(functionName, OB_FUNCTION, js);
    return resultValue;
}

function pbPostMessage(msg) {
    var text;
    if (typeof msg == "object") {
        text = JSON.stringify(msg);
    } else {
        text = msg;
    }
    chrome.webview.postMessage(text);
}

