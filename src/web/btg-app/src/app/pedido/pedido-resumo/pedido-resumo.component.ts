import { Component, EventEmitter, Input, OnInit, Output } from '@angular/core';
import { PedidoService } from '../services/pedido.service';
import { PedidoViewModel } from '../models/pedido.vm';
import { NgxSpinner, NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';
import { PedidoItemViewModel } from '../models/pedido-item.vm';

@Component({
  selector: 'app-pedido-resumo',
  templateUrl: './pedido-resumo.component.html',
  styleUrls: ['./pedido-resumo.component.css']
})
export class PedidoResumoComponent implements OnInit {

  @Input() pedido: PedidoViewModel = new PedidoViewModel();
  @Output() pedidoChange = new EventEmitter<PedidoViewModel>();

  constructor(
    private pedidoService: PedidoService,
    private sp: NgxSpinnerService,
    private toast: ToastrService) { }

  ngOnInit() {
    this.obterUltimoPedido();
  }

  obterUltimoPedido() {
    this.pedidoService.obterUltimoPedido().subscribe(pedido => {
      this.pedido = pedido
      this.pedidoChange.emit(pedido);
    });
  }

  removerProdutoPedido(item: PedidoItemViewModel) {
    Swal.fire({
      title: "Você tem certeza?",
      html: `O produto <strong>${item.nome}</strong> será removido do pedido!`,
      icon: "error",
      showCancelButton: true,
      confirmButtonColor: "#d33",
      cancelButtonColor: "#3085d6",
      confirmButtonText: "Sim, remover!"
    }).then((result) => {
      if (result.isConfirmed) {
        this.pedidoService.removerProdutoPedido(item.id)
          .subscribe({
            next: () => {
              Swal.fire({
                title: "Removido!",
                html: `O <strong>${item.nome}</strong> foi removido com sucesso.`,
                icon: "success"
              });
              this.obterUltimoPedido();
              this.sp.hide();
            },
            error: () => {
              this.sp.hide();
              this.toast.error("erro", "erro")
            }
          });
      }
    });
  }

  processarPedido() {
    this.sp.show();
    this.pedidoService.processarPedido(this.pedido.id)
      .subscribe({
        next: () => {
          this.obterUltimoPedido();
          this.toast.success("Pedido processado com sucesso.", "Processar pedido")
          this.sp.hide();
        },
        error: () => {
          this.sp.hide();
          this.toast.error("Erro no processamento, tente novamente mais tarde.", "Processar pedido")
        }
      });
  }
}
