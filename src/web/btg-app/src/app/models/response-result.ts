export class BadRequestResult {
    error: ResponseResult;
  
    constructor(){
      this.error = new ResponseResult();
    }
  }
  
  export class ResponseResult {
    title: string;
    status: number;
    errors: ReponseErroMessages;
  
    constructor() {
      this.errors = new ReponseErroMessages();
    }
  }
  
  export class ReponseErroMessages {
    Mensagens: string[] = [];
  
  }
  