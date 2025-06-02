export enum AccountType {
  ClientUser = 0,
  EnterpriseUser = 1
}

export class RegisterRequest {
  userName?: string;
  fullName?: string;
  email?: string;
  password?: string;
  accountType?: AccountType;
  cnpj?: string;
  cpf?: string;
}
