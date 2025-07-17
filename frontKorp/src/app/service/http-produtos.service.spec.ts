import { TestBed } from '@angular/core/testing';

import { HttpProdutosService } from './http-produtos.service';

describe('HttpProdutosService', () => {
  let service: HttpProdutosService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpProdutosService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
