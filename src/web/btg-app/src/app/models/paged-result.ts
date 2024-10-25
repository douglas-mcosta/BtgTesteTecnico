export class PagedResult<T> {
    list: T[]
    totalResults: number;
    pageIndex: number;
    pageSize: number;
    totalPages: number;
  
    constructor(){
      this.list = [];
      this.totalResults = 0;
      this.pageIndex = 1;
      this.pageSize = 6;
      this.totalPages = 1
    }
  }