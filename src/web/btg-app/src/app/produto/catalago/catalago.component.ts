import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../services/produto.service';

@Component({
  selector: 'app-catalago',
  templateUrl: './catalago.component.html',
  styleUrls: ['./catalago.component.css']
})
export class CatalagoComponent implements OnInit {

  constructor(private produtoService: ProdutoService) { }

  ngOnInit() {

    this.produtoService.obterCatalogo().subscribe(c=>console.log(c))
  }

}
