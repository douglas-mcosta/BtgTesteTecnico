import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CadastroComponent } from './conta/cadastro/cadastro.component';
import { HomeComponent } from './navegacao/home/home.component';

const routes: Routes = [{ path: '', redirectTo: '/home', pathMatch: 'full' },
{ path: 'home', component: HomeComponent },
{
  path: 'conta',
  loadChildren: () => import('./conta/conta.module')
    .then(m => m.ContaModule)
},
{
  path: 'produto',
  loadChildren: () => import('./produto/produto.module')
    .then(m => m.ProdutoModule)
}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
