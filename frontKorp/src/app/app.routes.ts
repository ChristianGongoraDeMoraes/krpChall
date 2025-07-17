import { Routes } from '@angular/router';
import { CadastrarNotaComponent } from './cadastrar-nota/cadastrar-nota.component';
import { ImprimirNotaComponent } from './imprimir-nota/imprimir-nota.component';
import { CadastrarProdutoComponent } from './cadastrar-produto/cadastrar-produto.component';

export const routes: Routes = [
    //{ path: '', component: Component },
    { path: '', component: CadastrarNotaComponent },
    { path: 'cadastrarProduto', component: CadastrarProdutoComponent },
    { path: 'imprimirNota', component: ImprimirNotaComponent }
];
