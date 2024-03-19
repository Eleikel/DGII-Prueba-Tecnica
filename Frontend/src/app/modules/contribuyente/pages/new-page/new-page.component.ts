import { Component, OnInit } from '@angular/core';
import { ContribuyenteService } from '../../services/contribuyente.service';
import { ActivatedRoute, Router } from '@angular/router';
import { MatDialog } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { filter, switchMap, tap } from 'rxjs';
import { FormControl, FormGroup } from '@angular/forms';
import {
  Contribuyente,
  TiposContribuyente,
} from '../../models/contribuyente.model';
import { ModalDeleteComponent } from '../../components/modal-delete/modal-delete.component';

@Component({
  selector: 'app-new-page',
  templateUrl: './new-page.component.html',
  styleUrls: ['./new-page.component.scss'],
})
export class NewPageComponent implements OnInit {
  public tiposContribuyenteEnum = TiposContribuyente;

  public contribuyenteForm = new FormGroup({
    id: new FormControl(0),
    rncCedula: new FormControl('', { nonNullable: true }),
    nombre: new FormControl('', { nonNullable: true }),
    tipo: new FormControl(''),
    estatus: new FormControl(true),
  });

  constructor(
    private contribuyenteService: ContribuyenteService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private snackbar: MatSnackBar,
    public dialog: MatDialog
  ) {}

  ngOnInit(): void {
    if (!this.router.url.includes('edit')) return;
    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) => this.contribuyenteService.getContribuyenteId(id))
      )
      .subscribe((contribuyente) => {
        if (!contribuyente.data) return this.router.navigateByUrl('/');

        this.contribuyenteForm.reset(contribuyente.data);
        return;
      });
  }

  get currentContribuyente(): Contribuyente {
    const contribuyente = this.contribuyenteForm.value as Contribuyente;
    return contribuyente;
  }

  onSubmit(): void {
    if (this.contribuyenteForm.invalid) return;
    if (this.currentContribuyente.id) {
      this.contribuyenteService
        .updateContribuyente(this.currentContribuyente)
        .subscribe((contribuyente) => {
          this.showSnackbar(`${contribuyente.data.nombre} Actualizado!`);
          this.router.navigate([
            './contribuyentes/list',
            contribuyente.data.id,
          ]);
        });
      return;
    }

    this.contribuyenteService
      .addContribuyente(this.currentContribuyente)
      .subscribe((contribuyente) => {
        this.router.navigate(['./contribuyentes/list', contribuyente.data.id]);
        this.showSnackbar(`${contribuyente.data.nombre} Creado!`);
      });
  }

  onDeleteContribuyente() {
    if (!this.currentContribuyente.id)
      throw Error('El Id del Contribuyente es requerido');
    const dialogRef = this.dialog.open(ModalDeleteComponent, {
      data: this.contribuyenteForm.value,
    });

    dialogRef
      .afterClosed()
      .pipe(
        filter((result: boolean) => result),
        switchMap(() =>
          this.contribuyenteService.deleteContribuyenteById(
            this.currentContribuyente.id!
          )
        ),
        tap((wasDeleted) => wasDeleted)
      )
      .subscribe((result) => {
        this.router.navigate(['/contribuyentes']);
      });
  }

  showSnackbar(message: string): void {
    this.snackbar.open(message, 'done', { duration: 2500 });
  }
}
