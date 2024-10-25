import { Component, OnInit, AfterViewInit, ViewChildren, ElementRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl, FormControlName } from '@angular/forms';
import { Router } from '@angular/router';

import { ToastrService } from 'ngx-toastr';

import { ContaService } from '../services/conta.service';

import { FormBaseComponent } from 'src/app/base-components/form-base.component';
import { UsuarioViewModel } from '../models/usuario.vm';
import { CustomValidators } from 'ng2-validation';
import { concat } from 'rxjs';
import { cpf } from 'ng-brazil';

@Component({
  selector: 'app-cadastro',
  templateUrl: './cadastro.component.html'
})
export class CadastroComponent extends FormBaseComponent implements AfterViewInit {

  @ViewChildren(FormControlName, { read: ElementRef }) formInputElements: ElementRef[] = [];

  errors: any[] = [];
  cadastroForm: FormGroup;
  usuario: UsuarioViewModel = new UsuarioViewModel();

  constructor(private fb: FormBuilder,
    private contaService: ContaService,
    private router: Router,
    private toastr: ToastrService) {

    super();
    let senha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15])]);
    let confirmacaoSenha = new FormControl('', [Validators.required, CustomValidators.rangeLength([6, 15]), CustomValidators.equalTo(senha)]);

    this.cadastroForm = this.fb.group({
      nome: ['', [Validators.required]],
      cpf: ['', [Validators.required]],
      email: ['', [Validators.required, Validators.email]],
      senha: senha,
      confirmacaoSenha: confirmacaoSenha
    });


    this.validationMessages = {
      nome: {
        required: 'Informe o nome',
      },
      cpf: {
        required: 'Informe o cpf',
      },
      email: {
        required: 'Informe o e-mail',
        email: 'Email inválido'
      },
      senha: {
        required: 'Informe a senha',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres'
      },
      confirmacaoSenha: {
        required: 'Informe a senha novamente',
        rangeLength: 'A senha deve possuir entre 6 e 15 caracteres',
        equalTo: 'As senhas não conferem'
      }
    };

    super.configurarMensagensValidacaoBase(this.validationMessages);



  }

  ngAfterViewInit(): void {
    super.configurarValidacaoFormularioBase(this.formInputElements, this.cadastroForm);
  }

  adicionarConta() {
    if (this.cadastroForm.dirty && this.cadastroForm.valid) {
      this.usuario = Object.assign({}, this.usuario, this.cadastroForm.value);

      this.contaService.registrarUsuario(this.usuario)
        .subscribe({
          next: (sucesso) => this.processarSucesso(sucesso),
          error: (erro) => this.processarFalha(erro)
        });

      this.mudancasNaoSalvas = false;
    }
  }

  processarSucesso(response: any) {
    this.cadastroForm.reset();
    this.errors = [];

    this.contaService.tokenStorage.salvarDadosLocaisUsuario(response);

    let toast = this.toastr.success('Registro realizado com Sucesso!', 'Bem vindo!!!');
    if (toast) {
      toast.onHidden.subscribe(() => {
        this.router.navigate(['/home']);
      });
    }
  }

  processarFalha(fail: any) {
    this.errors = [];
    this.errors = fail.error.errors.Mensagens;

    this.toastr.error('Ocorreu um erro!', 'Opa :(');
  }

}
