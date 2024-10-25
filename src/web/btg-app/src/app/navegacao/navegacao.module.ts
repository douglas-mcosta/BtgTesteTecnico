import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MenuComponent } from './menu/menu.component';
import { RouterModule } from '@angular/router';
import { MenuLoginComponent } from './menu-login/menu-login.component';
import { FooterComponent } from './footer/footer.component';
import { HomeComponent } from './home/home.component';
import { SharedModule } from '../shared/shared.module';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    SharedModule
  ],
  declarations: [
    MenuComponent,
    MenuLoginComponent,
    FooterComponent,
    HomeComponent
    
  ],
  exports:[
    MenuComponent,
    MenuLoginComponent,
    FooterComponent,
    HomeComponent
  ]
})
export class NavegacaoModule { }
