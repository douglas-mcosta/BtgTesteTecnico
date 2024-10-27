import { Component, Input, OnInit } from '@angular/core';
import { PedidoViewModel } from '../models/pedido.vm';
import { PedidoService } from '../services/pedido.service';
import { NgxSpinnerService } from 'ngx-spinner';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-lista-itens-pedido',
  templateUrl: './lista-itens-pedido.component.html',
  styleUrls: ['./lista-itens-pedido.component.css']
})
export class ListaItensPedidoComponent implements OnInit {

  @Input() set pedidoId(value: string) {
    if (value)
      this.obterPedido(value);
  };
  pedido: PedidoViewModel = new PedidoViewModel();

  constructor(
    private pedidoService: PedidoService,
    private sp: NgxSpinnerService,
    private toast: ToastrService) { }

  ngOnInit() {
  }

  obterPedido(pedidoId: string) {
    this.sp.show();
    this.pedidoService.obterPedidoPorId(pedidoId)
      .subscribe({
        next: (pedido: PedidoViewModel) => {
          this.pedido = pedido;
          this.sp.hide();
        },
        error: () => {
          this.toast.error("Erro ao ao obter pedido, tente novamente mais tarde.");
          this.sp.hide();
        }
      });
  }


}
