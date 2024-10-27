import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { ContaService } from 'src/app/conta/services/conta.service';

@Component({
  selector: 'app-menu-login',
  templateUrl: './menu-login.component.html',
  styleUrls: ['./menu-login.component.css']
})
export class MenuLoginComponent  {

  email = '';
  constructor(private router: Router, private auth: ContaService) { }

  usuarioLogado(): boolean {

    let token = this.auth.tokenStorage.obterTokenUsuario();
    let user = this.auth.tokenStorage.obterUsuario();

    if (user)
      this.email = user.email;

    return token !== null;
  }

  logout(): void {
    this.auth.tokenStorage.limparDadosLocaisUsuario();
    this.router.navigate(['/home']);
  }

}
