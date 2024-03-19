import { AfterViewInit, Component, OnInit, ViewChild } from '@angular/core';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator } from '@angular/material/paginator';
import { HttpClient } from '@angular/common/http';
import { ContribuyenteService } from '../../services/contribuyente.service';
import { Contribuyente } from '../../models/contribuyente.model';
import { MatDialog } from '@angular/material/dialog';
import { ModalComprobanteFiscalListComponent } from '../../../comprobante-fiscal/components/modal-comprobante-fiscal-list/modal-comprobante-fiscal-list.component';
import { ModalNewComprobanteFiscalListComponent } from '../../../comprobante-fiscal/components/modal-new-comprobante-fiscal-list/modal-new-comprobante-fiscal-list.component';

@Component({
  selector: 'app-list-page',
  templateUrl: './list-page.component.html',
  styleUrls: ['./list-page.component.scss'],
})
export class ListPageComponent implements OnInit, AfterViewInit {
  public isLoading: boolean = false;
  public contribuyentes: Contribuyente[] = [];
  public search: string = '';

  constructor(
    public contribuyenteService: ContribuyenteService,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    this.loadContribuyente();
  }

  displayedColumns: string[] = [
    'rncCedula',
    'nombre',
    'tipo',
    'estatus',
    'acciones',
  ];
  dataSource = new MatTableDataSource<Contribuyente>();

  @ViewChild(MatPaginator) paginator!: MatPaginator;

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  loadContribuyente() {
    this.isLoading = true;
    this.contribuyenteService.getContribuyentes().subscribe((resp) => {
      this.contribuyentes = resp.data;
      this.dataSource.data = this.contribuyentes;
      console.log(this.contribuyentes);
      this.isLoading = false;
    });
  }

  applyFilter() {
    let filteredData = this.contribuyentes.filter((contribuyente) => {
      const searchString = this.search.trim().toLowerCase();
      return Object.values(contribuyente).some((value) =>
        value.toString().toLowerCase().includes(searchString)
      );
    });

    if (this.search) {
      filteredData = filteredData.filter(
        (contribuyente) =>
          contribuyente
            .rncCedula!.toLowerCase()
            .includes(this.search.toLowerCase()) ||
          contribuyente
            .nombre!.toLowerCase()
            .includes(this.search.toLowerCase()) ||
          contribuyente.tipo!.toLowerCase().includes(this.search.toLowerCase())
      );
    }

    this.dataSource.data = filteredData;
  }

  abrirModalListComprobanteFiscal(comprobantesFiscales: Contribuyente): void {
    const dialogRef = this.dialog.open(ModalComprobanteFiscalListComponent, {
      data: comprobantesFiscales,
      height: '650px',
      width: '60%',
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }

  abrirModalNewComprobanteFiscal(comprobantesFiscales: Contribuyente): void {
    const dialogRef = this.dialog.open(ModalNewComprobanteFiscalListComponent, {
      data: comprobantesFiscales,
      height: '430px',
      width: '500px',
    });

    dialogRef.afterClosed().subscribe((result) => {
      console.log(`Dialog result: ${result}`);
    });
  }
}
