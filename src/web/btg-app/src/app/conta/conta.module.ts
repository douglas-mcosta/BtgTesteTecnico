import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule } from '@angular/router';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ContaAppComponent } from './conta.app.component';
import { CadastroComponent } from './cadastro/cadastro.component';
import { ContaService } from './services/conta.service';
import { CustomFormsModule } from 'ng2-validation';
import { ContaRoutingModule } from './conta.routing';
import { LoginComponent } from './login/login.component';
import { SharedModule } from '../shared/shared.module';
import { NgxSpinnerModule } from 'ngx-spinner';
import { NgBrazil } from 'ng-brazil';
import { TextMaskModule } from 'angular2-text-mask';

@NgModule({
  imports: [
    CommonModule,
    RouterModule,
    ContaRoutingModule,
    FormsModule,
    ReactiveFormsModule,
    CustomFormsModule,
    SharedModule,
    NgxSpinnerModule,
    TextMaskModule,
    NgBrazil,
  ],
  declarations: [ContaAppComponent,CadastroComponent,LoginComponent],
  providers:[ContaService]
})
export class ContaModule { }
