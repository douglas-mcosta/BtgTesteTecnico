import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { PedidoAppComponent } from './pedido.component';
import { ListaPedidoComponent } from './lista-pedido/lista-pedido.component';


const pedidoRouterConfig: Routes = [
    {
        path: '', component: PedidoAppComponent,
        children: [
            { path: 'lista', component: ListaPedidoComponent },
        ]
    }
];

@NgModule({
    imports: [
        RouterModule.forChild(pedidoRouterConfig)
    ],
    exports: [RouterModule]
})
export class PedidoRoutingModule { }