import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PedidoAppComponent } from './pedido.component';
import { PedidoService } from './services/pedido.service';
import { PedidoResumoComponent } from './pedido-resumo/pedido-resumo.component';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { PedidoRoutingModule } from './pedido.routing';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    PedidoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    SharedModule,
  ],
  declarations: [PedidoAppComponent,PedidoResumoComponent],
  exports:[PedidoResumoComponent],
  providers:[PedidoService]
})
export class PedidoModule { }
