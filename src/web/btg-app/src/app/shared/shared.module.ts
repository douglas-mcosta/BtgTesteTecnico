import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BannerTopComponent } from './banner-top/banner-top.component';
import { CardProdutoComponent } from './card-produto/card-produto.component';


@NgModule({
  imports: [
    CommonModule
  ],
  declarations: [BannerTopComponent,CardProdutoComponent],
  exports:[BannerTopComponent,CardProdutoComponent]
})
export class SharedModule { }
