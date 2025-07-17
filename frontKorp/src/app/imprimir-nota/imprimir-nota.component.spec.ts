import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ImprimirNotaComponent } from './imprimir-nota.component';

describe('ImprimirNotaComponent', () => {
  let component: ImprimirNotaComponent;
  let fixture: ComponentFixture<ImprimirNotaComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [ImprimirNotaComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ImprimirNotaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
