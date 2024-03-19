import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Contribuyente } from '../models/contribuyente.model';
import { ResponseData } from 'src/app/core/models/response.model';
import { Observable } from 'rxjs';

const base_url = environment.base_url;

@Injectable({
  providedIn: 'root',
})
export class ContribuyenteService {
  constructor(private http: HttpClient) {}

  addContribuyente(
    contribuyente: Contribuyente
  ): Observable<ResponseData<Contribuyente>> {
    const url = `${base_url}/v1/Contribuyente`;
    return this.http.post<ResponseData<Contribuyente>>(url, contribuyente);
  }

  getContribuyentes(): Observable<ResponseData<Contribuyente[]>> {
    const url = `${base_url}/v1/Contribuyente`;
    return this.http.get<ResponseData<Contribuyente[]>>(url);
  }

  getContribuyenteId(id: number): Observable<ResponseData<Contribuyente>> {
    const url = `${base_url}/v1/Contribuyente/${id}`;
    return this.http.get<ResponseData<Contribuyente>>(url);
  }

  deleteContribuyenteById(id: number): Observable<ResponseData<Contribuyente>> {
    const url = `${base_url}/v1/Contribuyente/${id}`;
    return this.http.delete<ResponseData<Contribuyente>>(url);
  }

  updateContribuyente(
    contribuyente: Contribuyente
  ): Observable<ResponseData<Contribuyente>> {
    const url = `${base_url}/v1/Contribuyente/${contribuyente.id!}`;
    return this.http.put<ResponseData<Contribuyente>>(url, contribuyente);
  }
}
