import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

type NotaFiscal = {
  numeracao: string,
  produtos: Produto[]
}

type Produto= {
  nome: string,
  preco: number
}

@Injectable({
  providedIn: 'root'
})
export class HttpNotaFiscalService {
  private http = inject(HttpClient);
  constructor() { }

  private urlDomainNotaFiscal :string = "http://localhost:5206"

  saveNotaFiscal(notaFiscal : NotaFiscal): Observable<any>{
      let urlX: string = this.urlDomainNotaFiscal + `/api/NotaFiscal`;
      return this.http.post(urlX, notaFiscal);
  }

  imprimirNotaFiscal(numeracao: string): Observable<any>{
      let urlX: string = this.urlDomainNotaFiscal + `/${numeracao}`;
      return this.http.put(urlX, {});
  }

  getNotasFiscais(): Observable<any>{
      let urlX: string = this.urlDomainNotaFiscal + `/api/NotaFiscal`;
      return this.http.get(urlX);
  }
}
