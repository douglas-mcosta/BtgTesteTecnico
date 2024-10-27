import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidoAppComponent } from './pedido.component';
import { PedidoService } from './services/pedido.service';
import { PedidoResumoComponent } from './pedido-resumo/pedido-resumo.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { PedidoRoutingModule } from './pedido.routing';
import { ListaPedidoComponent } from './lista-pedido/lista-pedido.component';
import { ListaItensPedidoComponent } from './lista-itens-pedido/lista-itens-pedido.component';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    PedidoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule

    
  ],
  declarations: [PedidoAppComponent,PedidoResumoComponent,ListaPedidoComponent,ListaItensPedidoComponent],
  exports:[PedidoResumoComponent],
  providers:[PedidoService]
})
export class PedidoModule { }
