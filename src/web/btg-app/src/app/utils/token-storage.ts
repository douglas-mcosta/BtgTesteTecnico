export class TokenStorage {

  public obterUsuario(): any {
    let user = localStorage.getItem("btg.userToken");

    if (user)
      return JSON.parse(user);

    return null;
  }

  public salvarDadosLocaisUsuario(response: any) {
    this.salvarTokenUsuario(response.accessToken);
    this.salvarUsuario(response.userToken);
  }

  public limparDadosLocaisUsuario() {
    localStorage.removeItem('btg.userToken');
    localStorage.removeItem('btg.accessToken');
  }

  public obterTokenUsuario(): string | any {
    let user = localStorage.getItem("btg.accessToken");

    if (user)
      return user;

    return null;
  }

  public salvarTokenUsuario(token: string) {
    localStorage.setItem('btg.accessToken', token);
  }
  public salvarUsuario(usuario: string) {
    localStorage.setItem('btg.userToken', JSON.stringify(usuario));
  }
}
