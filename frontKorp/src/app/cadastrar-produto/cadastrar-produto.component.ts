import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { HttpNotaFiscalService } from '../service/http-nota-fiscal.service';
import { FormsModule } from '@angular/forms';
import { HttpProdutosService } from '../service/http-produtos.service';
import { RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon';


@Component({
  selector: 'app-cadastrar-produto',
  imports: [CommonModule, FormsModule, MatIcon, RouterLink],
  templateUrl: './cadastrar-produto.component.html',
  styleUrl: './cadastrar-produto.component.scss'
})
export class CadastrarProdutoComponent{
  nome: string = ""
  preco: string = ""
  quantidadeEmEstoque: string = ""

  httpProduto = inject(HttpProdutosService);

  salvarProduto(){
    if(Number(this.quantidadeEmEstoque) < 0) return alert('Quantidde não pode ser um numero negativo !!')
    if(Number(this.preco) < 0) return alert('Preço não pode ser um numero negativo !!')
    if(this.nome == "") return alert('Nome está vazio !!')

    this.httpProduto.saveProduto({
      nome: this.nome, 
      preco: Number(this.preco) ,
      quantidadeEmEstoque : Number(this.quantidadeEmEstoque)
    }).subscribe({
        next: (data: any) => {
          alert('Produto Cadastrado com sucesso !!')
        },
        error: (err: any) => {
          alert('Parece que algo deu errado !!');
        }
      });


  }
}

