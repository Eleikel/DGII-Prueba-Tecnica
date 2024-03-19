export interface ResponseData<T> {
  data: T;
  message: string;
  status: number;
}

export interface Token<T> {
  value: string | null;
  expire: Date | null;
  info: T | null;
}
