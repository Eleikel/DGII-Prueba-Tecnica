import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ContribuyenteRoutingModule } from './contribuyente-routing.module';
import { MaterialModule } from 'src/app/shared/material/material.module';
import { LayoutPageComponent } from './pages/layout-page/layout-page.component';
import { ListPageComponent } from './pages/list-page/list-page.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { ModalComprobanteFiscalListComponent } from '../comprobante-fiscal/components/modal-comprobante-fiscal-list/modal-comprobante-fiscal-list.component';
import { NewPageComponent } from './pages/new-page/new-page.component';
import { ModalNewComprobanteFiscalListComponent } from '../comprobante-fiscal/components/modal-new-comprobante-fiscal-list/modal-new-comprobante-fiscal-list.component';
import { ModalDeleteComponent } from './components/modal-delete/modal-delete.component';

@NgModule({
  declarations: [
    LayoutPageComponent,
    ListPageComponent,
    ModalComprobanteFiscalListComponent,
    NewPageComponent,
    ModalNewComprobanteFiscalListComponent,
    ModalDeleteComponent,
  ],
  imports: [
    CommonModule,
    ContribuyenteRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
    FormsModule,
  ],
})
export class ContribuyenteModule {}
