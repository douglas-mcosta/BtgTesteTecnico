import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ProdutoAppComponent } from './produto.app.component';
import { RouterModule } from '@angular/router';
import { ProdutoRoutingModule } from './produto.routing';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { SharedModule } from '../shared/shared.module';
import { CatalagoComponent } from './catalago/catalago.component';
import { ProdutoService } from './services/produto.service';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgbModule, NgbPaginationModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ProdutoRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CustomFormsModule,
    SharedModule,
    NgxSpinnerModule,
    NgbModule
  ],
  declarations: [
    ProdutoAppComponent,
    CatalagoComponent],
  providers: [
    ProdutoService
  ]
})
export class ProdutoModule { }
