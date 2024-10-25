import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { Observable, throwError } from 'rxjs';
import { catchError, switchMap } from 'rxjs/operators';
import { AuthService } from './Auth.service';
import { ToastrService } from "ngx-toastr";

@Injectable()
export class TokenInterceptorService implements HttpInterceptor {


    constructor(private authService: AuthService, private router: Router, private toast: ToastrService) { }

    intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        return this.injetarToken(request, next).pipe(catchError(error => {

            if (error instanceof HttpErrorResponse) {

                if (error.status === 401) {
                    this.authService.tokenStorage.limparDadosLocaisUsuario();
                    let toast = this.toast.warning("Sessão expirada", "Atenção!", { timeOut: 1000 });
                    if (toast) {
                        toast.onHidden
                            .subscribe(() => { this.router.navigate(['/account/login']) })
                    }
                }

                if (error.status === 403) {
                    this.router.navigate(['/acesso-negado']);
                }
            }
            return throwError(error);
        }));
    }


    injetarToken(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {

        request = request.clone({
            setHeaders: {
                "Content-Type": 'application/json',
                "Authorization": `Bearer ${this.authService.tokenStorage.obterTokenUsuario()}`
            }
        });

        return next.handle(request);
    }
}

