import { ComprobanteFiscal } from '../../comprobante-fiscal/models/comprobantefiscal.model';

export interface Contribuyente {
  id?: number;
  rncCedula?: string;
  nombre?: string;
  tipo?: string;
  estatus?: boolean;
  comprobantesFiscales: ComprobanteFiscal[] | null;
}

export enum TiposContribuyente {
  PersonaFisica = 'Persona Física',
  PersonaJuridica = 'Persona Jurídica',
}

export enum EstatusContribuyente {
  Activo = 'Activo',
  Inactivo = 'Inactivo',
}
