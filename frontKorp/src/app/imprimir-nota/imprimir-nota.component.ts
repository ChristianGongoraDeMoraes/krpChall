import { CommonModule } from '@angular/common';
import { Component, inject, OnInit } from '@angular/core';
import { HttpNotaFiscalService } from '../service/http-nota-fiscal.service';
import { RouterLink } from '@angular/router';
import { MatIcon } from '@angular/material/icon';

type NotaFiscal = {
  numeracao:string,
  status: boolean,
  produtos: Produto[]
}
type Produto = {
  nome: string,
  preco: number
}

@Component({
  selector: 'app-imprimir-nota',
  imports: [CommonModule, RouterLink, MatIcon],
  templateUrl: './imprimir-nota.component.html',
  styleUrl: './imprimir-nota.component.scss'
})
export class ImprimirNotaComponent implements OnInit{
  httpNotas = inject(HttpNotaFiscalService);
  
  notas : NotaFiscal[] = [];
  
  ngOnInit(): void {
    this.setNotasFiscais();
  }


  setNotasFiscais(){
    this.notas = [];
    this.httpNotas.getNotasFiscais().subscribe({
        next: (data: any) => {
          if(data){
            for(let nota of data){
              this.notas.push(nota);
            }
            this.notas.reverse();
          }
        },
        error: (err: any) => {
          console.log('error');
        }
      });
  }

  imprimir(numeracao: string){
    this.httpNotas.imprimirNotaFiscal(numeracao).subscribe({
      next: (data: any) => {
        alert("nota impressa com sucesso !!")
        this.setNotasFiscais();
      },
      error: (err: any) => {
        alert(`Parece que algo deu errado !!`);
      }
    });
  }


  totalNota(produtos: Produto[]){
    let total = 0; 
    for(let produto of produtos){
      total += Number(produto.preco)
    }
    return total.toFixed(2)
  }
}
