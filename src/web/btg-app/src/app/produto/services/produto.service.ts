import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/services/base.service';
import { ProdutoViewModel } from '../models/produto.vw';
import { catchError, map, Observable } from 'rxjs';

@Injectable()
export class ProdutoService extends BaseService {

  constructor(private http: HttpClient) { super(); }

    obterCatalogo(): Observable<ProdutoViewModel> {
        let response = this.http
            .get(this.EcommerceUrl + 'produto',this.ObterAuthHeaderJson())
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }

}
