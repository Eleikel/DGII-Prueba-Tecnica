import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {
    path: 'contribuyentes',
    loadChildren: () =>
      import('./modules/contribuyente/contribuyente.module').then(
        (m) => m.ContribuyenteModule
      ),
  },
  {
    path: '',
    redirectTo: 'contribuyentes',
    pathMatch: 'full',
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
