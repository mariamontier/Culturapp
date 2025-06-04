import { PhoneResponse } from './phone-response.model';
import { AddressResponse } from './address-response.model';
import { EventResponse } from './event-response.model';
import { CheckingResponse } from './checking-response.model';

export interface ClientUserResponse {
  userName?: string;
  fullName?: string;
  cpf?: string;

  phoneResponse?: PhoneResponse;
  addressResponse?: AddressResponse;

  eventResponse?: (EventResponse | null)[];
  checkingResponse?: (CheckingResponse | null)[];
}
