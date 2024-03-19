import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalNewComprobanteFiscalListComponent } from './modal-new-comprobante-fiscal-list.component';

describe('ModalNewComprobanteFiscalListComponent', () => {
  let component: ModalNewComprobanteFiscalListComponent;
  let fixture: ComponentFixture<ModalNewComprobanteFiscalListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ ModalNewComprobanteFiscalListComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ModalNewComprobanteFiscalListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
