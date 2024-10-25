import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoAppComponent } from './produto.app.component';
import { RouterModule } from '@angular/router';
import { ProdutoRoutingModule } from './produto.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { CustomFormsModule } from 'ng2-validation';
import { SharedModule } from '../shared/shared.module';
import { CatalagoComponent } from './catalago/catalago.component';
import { ProdutoService } from './services/produto.service';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ProdutoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    HttpClientModule,
    CustomFormsModule,
    SharedModule
  ],
  declarations: [ProdutoAppComponent,CatalagoComponent],
  providers:[
    ProdutoService
  ]
})
export class ProdutoModule { }
