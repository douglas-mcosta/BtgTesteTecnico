import { Component, OnInit } from '@angular/core';
import { ProdutoService } from '../services/produto.service';
import { error } from 'console';
import { ProdutoViewModel } from '../models/produto.vw';
import { NgxSpinnerService } from 'ngx-spinner';
import { PagedResult } from 'src/app/models/paged-result';
import { FormControl } from '@angular/forms';
import { PedidoService } from 'src/app/pedido/services/pedido.service';
import { PedidoViewModel } from 'src/app/pedido/models/pedido.vm';
import { ToastrService } from 'ngx-toastr';
import { PedidoStatusEnum } from 'src/app/pedido/models/pedido-status.enum';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { ContaService } from 'src/app/conta/services/conta.service';
import Swal from 'sweetalert2';
import { Router } from '@angular/router';

@Component({
  selector: 'app-catalago',
  templateUrl: './catalago.component.html',
  styleUrls: ['./catalago.component.css']
})
export class CatalagoComponent implements OnInit {

  produtos: PagedResult<ProdutoViewModel> = new PagedResult<ProdutoViewModel>();
  pedido = new PedidoViewModel();
  nome = new FormControl("");
  pedidoStatus = PedidoStatusEnum;
  constructor(
    private produtoService: ProdutoService,
    private sp: NgxSpinnerService,
    private pedidoService: PedidoService,
    private toast: ToastrService,
    private authService: ContaService,
    private router: Router

  ) { }

  ngOnInit() {
    this.obterCatalogo();
    this.obterUltimoPedido()
  }

  obterCatalogo(): void {
    this.sp.show();
    this.produtoService.obterCatalogo(this.produtos.pageSize, this.produtos.pageIndex, this.nome.value).subscribe(
      {
        next: sucesso => this.processarSucesso(sucesso),
        error: t => this.processarFalha(t)
      })
  }

  pesquisar() {
    this.obterCatalogo();
  }

  processarSucesso(produtos: PagedResult<ProdutoViewModel>): void {
    this.produtos = produtos;
    this.sp.hide();

  }

  processarFalha(erro: any) {
    this.sp.hide();
    this.toast.error('Erro ao obter produtos, tente novamente mais tarde.', 'Catalogo');
  }

  obterUltimoPedido() {
    this.pedidoService.obterUltimoPedido().subscribe(pedido => this.pedido = pedido);
  }

  adicionarProdutoAoPedido(produto: any) {

    if (!this.authService.usuarioLogado()) {
      Swal.fire({
        icon: "warning",
        title: "Você precisa estar autenticado para realizar um pedido.",
        showConfirmButton: false,
        timer: 2000,
        willClose: () => {
          this.router.navigate(['/conta/login']);
        }
      });

      return;
    }

    this.sp.show();
    this.pedidoService.adicionarProdutoPedido(produto.id)
      .subscribe(
        {
          next: () => this.adicionarProdutoPedidoSucesso(),
          error: (error) => this.adicionarProdutoPedidoErro(error)
        }
      );
  }
  adicionarProdutoPedidoSucesso() {
    this.toast.success("Adicionado com sucesso!", "Produto", { timeOut: 600 });
    this.obterUltimoPedido();
    this.sp.hide();
  }
  adicionarProdutoPedidoErro(fail: any) {
    this.sp.hide();
    this.toast.error(...fail.error.errors.Mensagens);
  }

}
