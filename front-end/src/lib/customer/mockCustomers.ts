import { CustomerType } from './CustomerType';
import { COMPANY, PERSON } from '../../app/enums/dashboard/customers/customerTypeEnum';

export const customers: CustomerType[] = [
  {
    id: 1,
    type: COMPANY,
    name: 'Test Client 1',
    email: 'test@client1.com',
    currency: 'PLN',
    vatnumber: 'PL 1234567890'
  },
  {
    id: 2,
    type: COMPANY,
    name: 'Test Client 2',
    email: 'test@client2.com',
    currency: 'PLN',
    vatnumber: '9876543210'
  },
  {
    id: 3,
    type: PERSON,
    name: 'John Doe',
    email: 'johndoe@gmail.com',
    currency: 'PLN'
  },
  {
    id: 4,
    type: PERSON,
    name: 'John Smith',
    email: 'john@smithjohn.com',
    currency: 'PLN'
  }
];
