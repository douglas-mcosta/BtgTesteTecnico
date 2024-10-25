import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BannerTopComponent } from './banner-top/banner-top.component';
import { CardProdutoComponent } from './card-produto/card-produto.component';
import { AlertDangerComponent } from './alert-danger/alert-danger.component';
import { NgxSpinnerModule } from 'ngx-spinner';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BannerTopComponent,CardProdutoComponent,AlertDangerComponent],
  exports:[BannerTopComponent,CardProdutoComponent,AlertDangerComponent]
})
export class SharedModule { }
