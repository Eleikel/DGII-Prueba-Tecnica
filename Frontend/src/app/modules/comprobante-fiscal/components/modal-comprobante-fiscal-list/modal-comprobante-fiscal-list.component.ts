import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ComprobanteFiscal } from 'src/app/modules/comprobante-fiscal/models/comprobantefiscal.model';
import { Contribuyente } from '../../../contribuyente/models/contribuyente.model';
import { MatTableDataSource } from '@angular/material/table';

@Component({
  selector: 'app-modal-comprobante-fiscal-list',
  templateUrl: './modal-comprobante-fiscal-list.component.html',
  styleUrls: ['./modal-comprobante-fiscal-list.component.scss'],
})
export class ModalComprobanteFiscalListComponent implements OnInit {
  constructor(
    @Inject(MAT_DIALOG_DATA)
    public contribuyente: Contribuyente
  ) {}

  ngOnInit(): void {
    this.calcularMontoTotal();
  }

  public montoTotal: number = 0;
  displayedColumns: string[] = ['ncf', 'monto', 'itbis18'];
  dataSource = new MatTableDataSource<ComprobanteFiscal>(
    this.contribuyente.comprobantesFiscales!
  );

  calcularMontoTotal() {
    if (this.contribuyente && this.contribuyente.comprobantesFiscales) {
      this.montoTotal = this.contribuyente.comprobantesFiscales.reduce(
        (total, comprobanteFiscal) => total + comprobanteFiscal.itbis18!,
        0
      );
    }
  }
}
