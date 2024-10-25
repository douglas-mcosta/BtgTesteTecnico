import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../services/produto.service';
import { error } from 'console';
import { ProdutoViewModel } from '../models/produto.vw';
import { NgxSpinnerService } from 'ngx-spinner';
import { PagedResult } from 'src/app/models/paged-result';
import { FormControl } from '@angular/forms';
import { PedidoService } from 'src/app/pedido/services/pedido.service';

@Component({
  selector: 'app-catalago',
  templateUrl: './catalago.component.html',
  styleUrls: ['./catalago.component.css']
})
export class CatalagoComponent implements OnInit {

  produtos: PagedResult<ProdutoViewModel> = new PagedResult<ProdutoViewModel>();
  nome = new FormControl("");
  constructor(private produtoService: ProdutoService, private sp: NgxSpinnerService,pedidoService: PedidoService) { }

  ngOnInit() {
    this.obterPedidos();
  }

  obterPedidos(): void {
    this.sp.show();
    this.produtoService.obterCatalogo(this.produtos.pageSize, this.produtos.pageIndex, this.nome.value).subscribe(
      {
        next: sucesso => this.processarSucesso(sucesso),
        error: t => this.processarFalha(t)
      })
  }

  processarSucesso(produtos: PagedResult<ProdutoViewModel>): void {
    console.log(produtos)
    this.produtos = produtos;
    this.sp.hide();

  }

  processarFalha(erro: any) {
    this.sp.hide();
    // this.toastr.error('Ocorreu um erro!', 'Opa :(');
    // this.errors = erro.error.errors.Mensagens;
  }


  adicionarProdutoAoPedido(produto: ProdutoViewModel){

  }

  pesquisar() {
    this.obterPedidos();
  }

}
