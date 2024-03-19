import { Component, Inject, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Contribuyente } from '../../../contribuyente/models/contribuyente.model';
import { FormControl, FormGroup } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ComprobanteFiscalService } from 'src/app/modules/comprobante-fiscal/services/comprobante-fiscal.service';
import { switchMap } from 'rxjs';
import { ComprobanteFiscal } from 'src/app/modules/comprobante-fiscal/models/comprobantefiscal.model';

@Component({
  selector: 'app-modal-new-comprobante-fiscal-list',
  templateUrl: './modal-new-comprobante-fiscal-list.component.html',
  styleUrls: ['./modal-new-comprobante-fiscal-list.component.scss'],
})
export class ModalNewComprobanteFiscalListComponent implements OnInit {
  public comprobanteFiscalForm = new FormGroup({
    id: new FormControl(0),
    ncf: new FormControl('', { nonNullable: true }),
    monto: new FormControl(0, { nonNullable: true }),
    itbis18: new FormControl(0),
    contribuyenteId: new FormControl(this.contribuyente.id),
    rncCedula: new FormControl(''),
  });

  constructor(
    public dialogRef: MatDialogRef<ModalNewComprobanteFiscalListComponent>,
    @Inject(MAT_DIALOG_DATA)
    public contribuyente: Contribuyente,
    public comprobanteFiscalService: ComprobanteFiscalService,
    private activatedRoute: ActivatedRoute,
    private router: Router,
    private snackbar: MatSnackBar
  ) {}

  ngOnInit(): void {
    if (!this.router.url.includes('edit')) return;
    this.activatedRoute.params
      .pipe(
        switchMap(({ id }) =>
          this.comprobanteFiscalService.getComprobanteFiscalById(id)
        )
      )
      .subscribe((comprobanteFiscal) => {
        if (!comprobanteFiscal.data) return this.router.navigateByUrl('/');

        this.comprobanteFiscalForm.reset(comprobanteFiscal.data);
        return;
      });
  }

  get currentComprobanteFiscal(): ComprobanteFiscal {
    const comprobanteFiscal = this.comprobanteFiscalForm
      .value as ComprobanteFiscal;
    return comprobanteFiscal;
  }

  onSubmit(): void {
    if (this.comprobanteFiscalForm.invalid) return;
    if (this.currentComprobanteFiscal.id) {
      this.comprobanteFiscalService
        .updateComprobanteFiscal(this.currentComprobanteFiscal)
        .subscribe((comprobanteFiscal) => {
          this.showSnackbar(` Actualizado!`);
          this.router.navigate([
            './contribuyentes/list',
            comprobanteFiscal.data.id,
          ]);
        });
      return;
    }
    console.log(this.comprobanteFiscalForm.value);

    this.comprobanteFiscalService
      .addComprobanteFiscal(this.currentComprobanteFiscal)
      .subscribe((comprobanteFiscal) => {
        this.dialogRef.close(true);

        this.showSnackbar(`Registro Creado!`);
        window.location.reload();
      });
  }

  showSnackbar(message: string): void {
    this.snackbar.open(message, 'done', { duration: 2500 });
  }
}
