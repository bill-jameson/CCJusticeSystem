var api = require('./creds.json')


export const apiService = {
    getSummonsRecipientLogin,
    getQuestionairre,
    PostQuestionairre
}


var headers = {
    
}

function setHeader(){
    
}

async function get(url) {
    return fetch(url, {
        method: 'GET',
        headers: headers
    });
}

async function post (url, body) {
    return fetch(url, {
        method: 'POST',
        headers: headers, 
        body: JSON.stringify(body)
    });
}

async function put (url, body) {
    return fetch(url, {
        method: 'PUT',
        headers: headers,
        body: JSON.stringify(body)
    });
}

async function doDelete(url, body) {
    return fetch(url, {
        method: 'DELETE',
        headers: headers,
        body: JSON.stringify(body)
    });
}

async function getSummonsRecipientLogin(social, juror){
    return get(api.baseurl + 'mobile?socialLastFour='+ social + '&jurorId=' + juror)
}

async function getQuestionairre(jurorID){
    return get(api.baseurl + 'get-questionairre?id=' + jurorID )
}

async function PostQuestionairre(){

}


