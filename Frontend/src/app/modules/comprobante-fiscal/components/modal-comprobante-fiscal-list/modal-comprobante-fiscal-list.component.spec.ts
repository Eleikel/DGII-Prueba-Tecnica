import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalComprobanteFiscalListComponent } from './modal-comprobante-fiscal-list.component';

describe('ModalComprobanteFiscalListComponent', () => {
  let component: ModalComprobanteFiscalListComponent;
  let fixture: ComponentFixture<ModalComprobanteFiscalListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalComprobanteFiscalListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalComprobanteFiscalListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
