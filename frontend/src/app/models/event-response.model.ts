import { AddressResponse } from './address-response.model';
import { CheckingResponse } from './checking-response.model';
import { ClientUserResponse } from './client-user-response.model';
import { StatusResponse } from './status-response.model';
import { FaqResponse } from './faq-response.model';
import { EnterpriseUserResponse } from './enterprise-user-response.model';
import { CategoryResponse } from './category-response.model';
import { PhoneResponse } from './phone-response.model';

export class EventResponse {
  id?: number;
  name?: string;
  startDate?: Date;
  endDate?: Date;
  description?: string;

  locationAddressId?: number;
  addressResponse?: AddressResponse;

  capacity?: number;
  ticketPrice?: number;

  salesStartDate?: Date;
  salesEndDate?: Date;

  scoreValue?: number;

  statusId?: number;
  statusResponse?: StatusResponse;

  checkingId?: number;
  checking?: CheckingResponse;

  faqId?: number;
  faqResponse?: FaqResponse;

  enterpriseId?: number;
  enterpriseUserResponse?: EnterpriseUserResponse;

  categoryId?: number;
  categoryResponse?: CategoryResponse;

  phoneResponses?: PhoneResponse[];
  clientUserResponses?: ClientUserResponse[];
}
