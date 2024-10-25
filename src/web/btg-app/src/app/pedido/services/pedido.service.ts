import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { ProdutoViewModel } from 'src/app/produto/models/produto.vw';
import { BaseService } from 'src/app/services/base.service';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PedidoService extends BaseService {

  private url = {
    adicionarProdutoPedido: (produto:ProdutoViewModel) => `${environment.EcommerceUrl}pedido/`,
  }

  constructor(private http: HttpClient) { super(); }

  // adicionarProdutoPedido(produto: ProdutoViewModel): Observable<PagedResult<ProdutoViewModel>> {
  //   let response = this.http
  //     .get(this.url.obterCatalogo(pageSize, page, nome))
  //     .pipe(
  //       map(this.extractData),
  //       catchError(this.serviceError));

  //   return response;
  // }

}
