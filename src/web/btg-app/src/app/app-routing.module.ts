import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ContatoComponent } from './navegacao/contato/contato.component';

const routes: Routes = [
  { path: '', redirectTo: '/produto/catalogo', pathMatch: 'full' },
  { path: 'home', redirectTo: '/produto/catalogo' },
  { path: 'contato', component: ContatoComponent },
  {
    path: 'conta',
    loadChildren: () => import('./conta/conta.module')
      .then(m => m.ContaModule)
  },
  {
    path: 'produto',
    loadChildren: () => import('./produto/produto.module')
      .then(m => m.ProdutoModule)
  },
  {
    path: 'pedido',
    loadChildren: () => import('./pedido/pedido.module')
      .then(m => m.PedidoModule)
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
