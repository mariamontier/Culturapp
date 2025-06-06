import { AddressResponse } from "./address-response.model";
import { PhoneResponse } from "./phone-response.model";

export class EnterpriseUserResponse {
  id?: number;
  cnpj?: string;
  name?: string;
  email?: string;
  faqId?: number;
  phones?: (PhoneResponse | null)[];
  addressId?: number;
  address?: AddressResponse | null;
}
