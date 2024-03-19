import { Contribuyente } from '../../contribuyente/models/contribuyente.model';

export interface ComprobanteFiscal {
  id?: number;
  ncf?: string;
  monto?: number;
  itbis18?: number;
  contribuyenteId?: number;
  rncCedula?: string;
  contribuyente?: Contribuyente;
}
