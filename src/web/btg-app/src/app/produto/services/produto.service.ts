import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/services/base.service';
import { ProdutoViewModel } from '../models/produto.vw';
import { catchError, map, Observable } from 'rxjs';
import { PagedResult } from 'src/app/models/paged-result';

@Injectable()
export class ProdutoService extends BaseService {

    private url = {
        obterCatalogo: (pageSize: number, page: number, nome: string | null) => `${this.EcommerceUrl}produto/?ps=${pageSize}&page=${page}&nome=${nome}`,
    }
    
    constructor(private http: HttpClient) { super(); }

    obterCatalogo(pageSize: number = 8, page: number = 1, nome: string = ""): Observable<PagedResult<ProdutoViewModel>> {
        let response = this.http
            .get(this.url.obterCatalogo(pageSize, page, nome))
            .pipe(
                map(this.extractData),
                catchError(this.serviceError));

        return response;
    }

}
