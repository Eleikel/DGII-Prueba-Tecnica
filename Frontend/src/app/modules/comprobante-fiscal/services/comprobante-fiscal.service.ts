import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { ComprobanteFiscal } from '../models/comprobantefiscal.model';
import { Observable } from 'rxjs';
import { ResponseData } from 'src/app/core/models/response.model';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root',
})
export class ComprobanteFiscalService {
  constructor(private http: HttpClient) {}

  addComprobanteFiscal(
    comprobanteFiscal: ComprobanteFiscal
  ): Observable<ResponseData<ComprobanteFiscal>> {
    const url = `${base_url}/v1/ComprobanteFiscal`;
    return this.http.post<ResponseData<ComprobanteFiscal>>(
      url,
      comprobanteFiscal
    );
  }

  getComprobantesFiscales(): Observable<ResponseData<ComprobanteFiscal[]>> {
    const url = `${base_url}/v1/ComprobanteFiscal`;
    return this.http.get<ResponseData<ComprobanteFiscal[]>>(url);
  }

  getComprobanteFiscalById(
    id: number
  ): Observable<ResponseData<ComprobanteFiscal>> {
    const url = `${base_url}/v1/ComprobanteFiscal/${id}`;
    return this.http.get<ResponseData<ComprobanteFiscal>>(url);
  }

  deleteComprobanteFiscalById(
    id: number
  ): Observable<ResponseData<ComprobanteFiscal>> {
    const url = `${base_url}/v1/ComprobanteFiscal/${id}`;
    return this.http.delete<ResponseData<ComprobanteFiscal>>(url);
  }

  updateComprobanteFiscal(
    comprobanteFiscal: ComprobanteFiscal
  ): Observable<ResponseData<ComprobanteFiscal>> {
    const url = `${base_url}/v1/ComprobanteFiscal/${comprobanteFiscal.id!}`;
    return this.http.put<ResponseData<ComprobanteFiscal>>(
      url,
      comprobanteFiscal
    );
  }
}
