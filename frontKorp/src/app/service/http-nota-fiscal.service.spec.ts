import { TestBed } from '@angular/core/testing';

import { HttpNotaFiscalService } from './http-nota-fiscal.service';

describe('HttpNotaFiscalService', () => {
  let service: HttpNotaFiscalService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(HttpNotaFiscalService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
