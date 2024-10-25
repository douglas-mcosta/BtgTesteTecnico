import { environment } from 'src/environments/environment';
import { HttpHeaders, HttpErrorResponse } from "@angular/common/http";
import { throwError } from 'rxjs';
// import { BadRequestResult } from '../models/response-result';
import { TokenStorage } from '../utils/token-storage';
import { BadRequestResult } from '../models/response-result';

export abstract class BaseService {

  protected IdentityUrl: string = environment.IdentityUrl;
  protected EcommerceUrl: string = environment.EcommerceUrl;
  public tokenStorage = new TokenStorage();

  protected ObterHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      })
    };
  }

  protected ObterAuthHeaderJson() {
    return {
      headers: new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${this.tokenStorage.obterTokenUsuario()}`
      })
    };
  }

  protected extractData(response: any) {
    return response || {};
  }

  protected serviceError(response: Response | any) {
    let customError: string[] = [];
    let customResponse = new BadRequestResult();

    console.log(response)
    if (response instanceof HttpErrorResponse) {

      if (response.statusText === "Unknown Error") {
        customError.push("Ocorreu um erro desconhecido");
        // response.error.errors = customError;
        customResponse.error.errors.Mensagens = customError;
      }

      if (response.status === 400) {
        customResponse.error.errors.Mensagens = response.error.errors;
      }
    }

    if (response.status === 500) {
      customError.push("Ocorreu um erro no processamento, tente novamente mais tarde ou contate o nosso suporte.");
      // Erros do tipo 500 não possuem uma lista de erros
      // A lista de erros do HttpErrorResponse é readonly
      customResponse.error.errors.Mensagens = customError;
    }

    return throwError(customResponse);
  }
}


