import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { HttpProdutosService } from '../service/http-produtos.service';
import { FormsModule } from '@angular/forms';
import { HttpNotaFiscalService } from '../service/http-nota-fiscal.service';
import { RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon';

type Produtos = {
  nome: string,
  preco: number,
  quantidadeEmEstoque: number
}
type ProdutosNota = {
  nome: string,
  preco: number,
}

@Component({
  selector: 'app-cadastrar-nota',
  imports: [CommonModule, FormsModule, RouterLink, MatIcon],
  templateUrl: './cadastrar-nota.component.html',
  styleUrl: './cadastrar-nota.component.scss'
})
export class CadastrarNotaComponent implements OnInit{
  httpProdutos = inject(HttpProdutosService); 
  httpNota = inject(HttpNotaFiscalService);

  numeracaoNota : string = "";
  produtosNota : ProdutosNota[] = []
  produtos : Produtos[] = []
  
  ngOnInit(): void {
    this.setProdutos();
  }


  setProdutos(){
    this.produtos = [];
    this.httpProdutos.getProdutos().subscribe({
        next: (data: any) => {
          if(data){
            for(let p of data){
              this.produtos.push(p);
            }
          }
        },
        error: (err: any) => {
          console.log('error');
        }
      });
  }

  addNota(nome: string, preco: number){
    this.produtosNota.push({nome: nome, preco: preco});
  }

  salvarNota(){
    this.httpNota.saveNotaFiscal({numeracao: this.numeracaoNota, produtos: this.produtosNota}).subscribe({
        next: (data: any) => {
          alert("Nota Salva com Sucesso");
          this.produtosNota = [];
          this.setProdutos();
          this.numeracaoNota = "";
        },
        error: (err: any) => {
          alert(`Parece que algo deu errado !!`);
        }
      });
  }
}
