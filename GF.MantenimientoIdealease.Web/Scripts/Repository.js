const DEBUG = true;

async function Request(method = '', url = '', data = null, codeOnly = false) {

    const options = {
        method: method,
        mode: 'cors',
        cache: 'no-cache',
        credentials: 'same-origin',
        headers: {
            'Content-Type': 'application/json'
        },
        redirect: 'follow',
        referrer: 'no-referrer'
    };

    if (data) {
        options.body = JSON.stringify(data);
    }

    if (DEBUG && data) {
        console.log(data);
    }

    let request = fetch(url, options);

    if (codeOnly) {
        return await request;
    }

    return await request.then(function (response) {
        return response.json();
    });

    /*
    return await fetch(url, options)
        .then(function (response) {
            return response.json();
        });
        */
}

class Repository {

    constructor() {

        this.URL = window.location.origin;
        this.URL_API = this.URL + "/api";
        this._usuarios = null;
        this._historicoKilometraje = null;

    }

    get UsuariosController() {

        if (!this._usuarios) {
            this._usuarios = new UsuariosController(this.URL);
        }

        return this._usuarios;
    }

    get HistoricoKilometrajeController() {

        if (!this._historicoKilometraje) {
            this._historicoKilometraje = new HistoricoKilometrajeController(this.URL);
        }

        return this._historicoKilometraje;
    }

}

class UsuariosController {

    constructor(url = '') {
        this.Url = url;
    }

    Login(usuario) {
        let route = "/LoginWebAPI"
        if (DEBUG) console.log("POST: " + this.Url + route);
        return Request("POST", this.Url + route, usuario);
    }

    Logout() {
        let route = "/TryLogoutWebAPI";
        if (DEBUG) console.log("POST: " + this.Url + route);
        return Request("POST", this.Url + route), null, true;
    }

}

class HistoricoKilometrajeController {

    constructor(url = '') {
        this.Url = url;
    }

    SubirArchivoInterface(archivo) {
        let route = "/api/SubirArchivoInterface"
        if (DEBUG) console.log("POST: " + this.Url + route);
        return Request("POST", this.Url + route, archivo);
    }

}