import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, Subscription } from 'rxjs';
import { BaseService } from 'src/app/services/base.service';
import { catchError, map } from "rxjs/operators";
// import { Usuario } from '../conta/models/usuario';
import { Router } from '@angular/router';
import { UsuarioViewModel } from '../conta/models/usuario.vm';


@Injectable()
export class AuthService extends BaseService {

  constructor(private http: HttpClient, private router: Router) { super(); }

//   registrarUsuario(usuario: Usuario): Observable<any> {

//     let response = this.http.post(this.IdentityUrl + 'nova-conta', usuario, this.ObterHeaderJson())
//       .pipe(
//         catchError(this.serviceError)
//       );

//     return response;
//   }

  login(usuario: UsuarioViewModel): Observable<any> {

    let response = this.http.post(this.IdentityUrl + "login", usuario, this.ObterHeaderJson())
      .pipe(
        catchError(this.serviceError)
      );

    return response;
  }
}
