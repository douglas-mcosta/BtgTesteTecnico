import { Component, OnInit } from '@angular/core';
import { PedidoService } from '../services/pedido.service';
import { PedidoViewModel } from '../models/pedido.vm';
import { NgxSpinnerService } from 'ngx-spinner';
import { PedidoStatusEnum } from '../models/pedido-status.enum';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';

@Component({
  selector: 'app-lista-pedido',
  templateUrl: './lista-pedido.component.html',
  styleUrls: ['./lista-pedido.component.css']
})
export class ListaPedidoComponent implements OnInit {

  pedidos: PedidoViewModel[] = [];
  pedidoId = '';
  pedidoStatusEnum = PedidoStatusEnum;
  constructor(
    private pedidoService: PedidoService,
    private sp: NgxSpinnerService,
    private modalService: NgbModal
  ) { }

  ngOnInit() {
    this.sp.show();

    this.pedidoService.obterMeusPedidos()
      .subscribe({
        next: (p: PedidoViewModel[]) => {
          this.pedidos = p;
          this.sp.hide();
        }
      })
  }

  abrirModal(pedidoId: string, content: any) {
    this.pedidoId = pedidoId;
    this.modalService.open(content,{ size: 'lg' });
  }

}
