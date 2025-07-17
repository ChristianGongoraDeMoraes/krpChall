import { HttpClient } from '@angular/common/http';
import { inject, Injectable } from '@angular/core';
import { Observable } from 'rxjs';

type Produto = {
  nome:string,
  preco: number,
  quantidadeEmEstoque: number
}

@Injectable({
  providedIn: 'root'
})
export class HttpProdutosService {
  private http = inject(HttpClient);
  constructor() { }

  private urlDomainProduto :string = "http://localhost:5127"

  saveProduto(produto: Produto): Observable<any>{
      let urlX: string = this.urlDomainProduto + `/api/Produto`;
      return this.http.post(urlX, produto);
  }

  getProdutos(): Observable<any>{
    let urlX: string = this.urlDomainProduto + `/api/Produto`;
    return this.http.get(urlX);
  }
}
