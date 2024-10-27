import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { ProdutoViewModel } from 'src/app/produto/models/produto.vw';

@Component({
  selector: 'app-card-produto',
  templateUrl: './card-produto.component.html'
})
export class CardProdutoComponent {

  @Input() produtos: ProdutoViewModel[] = [];
  @Output() adicionarProduto = new EventEmitter<ProdutoViewModel>();

  constructor() { }

  adicionarProdutoAoPedido(produto: ProdutoViewModel) {
    this.adicionarProduto.emit(produto);
  }
}
