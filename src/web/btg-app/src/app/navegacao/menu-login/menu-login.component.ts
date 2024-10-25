import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/Auth.service';

@Component({
  selector: 'app-menu-login',
  templateUrl: './menu-login.component.html',
  styleUrls: ['./menu-login.component.css']
})
export class MenuLoginComponent  {

  email = '';
  constructor(private router: Router, private auth: AuthService) { }

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
