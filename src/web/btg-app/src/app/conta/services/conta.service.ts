import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { Observable } from 'rxjs';
import { catchError, map } from "rxjs/operators";
import { BaseService } from 'src/app/services/base.service';
import { UsuarioViewModel } from '../models/usuario.vm';

@Injectable()
export class ContaService extends BaseService {

    constructor(private http: HttpClient) { super(); }

    registrarUsuario(usuario: UsuarioViewModel): Observable<void> {
        let response = this.http
            .post(this.IdentityUrl + 'nova-conta', usuario, this.ObterHeaderJson())
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }

    login(usuario: UsuarioViewModel): Observable<UsuarioViewModel> {
        let response = this.http
            .post(this.IdentityUrl + 'entrar', usuario, this.ObterHeaderJson())
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }


    usuarioLogado(): boolean {
        let token = this.tokenStorage.obterTokenUsuario();
        return token !== null;
    }
}