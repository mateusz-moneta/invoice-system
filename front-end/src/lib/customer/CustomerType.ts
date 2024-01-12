import { CustomerTypeEnum } from '@/app/enums/dashboard/customers/customerTypeEnum';

export type CustomerType = {
  id: number;
  type: CustomerTypeEnum;
  name: string;
  email: string;
  currency: string;
  vatnumber?: string;
};
