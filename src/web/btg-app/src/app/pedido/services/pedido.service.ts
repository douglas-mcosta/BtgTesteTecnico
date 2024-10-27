import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { BaseService } from 'src/app/services/base.service';
import { environment } from 'src/environments/environment';
import { PedidoViewModel } from '../models/pedido.vm';

@Injectable()
export class PedidoService extends BaseService {

  private url = {
    obterUltimoPedido: `${environment.EcommerceUrl}pedido`,
    adicionarProdutoPedido: (produtoId: string) => `${environment.EcommerceUrl}pedido/${produtoId}`,
    processarPedido: (pedidoId: string) => `${environment.EcommerceUrl}pedido/processar/${pedidoId}`,
    removerProdutoPedido: (itemId: string) => `${environment.EcommerceUrl}pedido/${itemId}`,
  }

  constructor(private http: HttpClient) { super(); }

  obterUltimoPedido(): Observable<PedidoViewModel> {

    let response = this.http
      .get(this.url.obterUltimoPedido)
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  adicionarProdutoPedido(produtoId: string): Observable<any> {
    let response = this.http
      .post(this.url.adicionarProdutoPedido(produtoId), {})
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  removerProdutoPedido(itemId: string): Observable<any> {
    let response = this.http
      .delete(this.url.adicionarProdutoPedido(itemId), {})
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

  processarPedido(pedidoId: string): Observable<any> {
    let response = this.http
      .put(this.url.processarPedido(pedidoId), {})
      .pipe(
        map(this.extractData),
        catchError(this.serviceError));

    return response;
  }

}
