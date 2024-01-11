import {NEW, PAID, PARTIALLY, SENT, UNPAID} from "@/app/enums/dashboard/invoices/statusEnum";
import {InvoiceType} from "@/lib/invoice/InvoiceType";

export const invoices: InvoiceType[] = [
    {
        id: 1,
        client: 'Test Client 1',
        date: new Date('2023-12-29'),
        paymentDate: new Date('2024-01-10'),
        currency: 'PLN',
        netPrice: 1000,
        grossPrice: 1230,
        vatRate: 23,
        vatAmount: 230,
        status: NEW,
        paymentStatus: UNPAID
    },
    {
        id: 2,
        client: 'Test Client 2',
        date: new Date('2023-12-27'),
        paymentDate: new Date('2024-01-27'),
        currency: 'PLN',
        netPrice: 1000,
        vatRate: 23,
        status: NEW,
        paymentStatus: PARTIALLY
    },
    {
        id: 3,
        client: 'Test Client 1',
        date: new Date('2023-11-30'),
        paymentDate: new Date('2023-12-9'),
        currency: 'PLN',
        netPrice: 11000,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 4,
        client: 'Test Client 2',
        date: new Date('2023-11-30'),
        paymentDate: new Date('2023-12-30'),
        currency: 'PLN',
        netPrice: 20000,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 5,
        client: 'John Doe',
        date: new Date('2023-10-27'),
        paymentDate: new Date('2023-10-27'),
        currency: 'PLN',
        netPrice: 500,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 6,
        client: 'John Smith',
        date: new Date('2023-10-20'),
        paymentDate: new Date('2023-10-27'),
        currency: 'USD',
        netPrice: 800,
        vatRate: 0,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 7,
        client: 'Test Client 1',
        date: new Date('2023-12-29'),
        paymentDate: new Date('2024-01-10'),
        currency: 'PLN',
        netPrice: 1000,
        grossPrice: 1230,
        vatRate: 23,
        vatAmount: 230,
        status: NEW,
        paymentStatus: UNPAID
    },
    {
        id: 8,
        client: 'Test Client 2',
        date: new Date('2023-12-27'),
        paymentDate: new Date('2024-01-27'),
        currency: 'PLN',
        netPrice: 1000,
        vatRate: 23,
        status: NEW,
        paymentStatus: PARTIALLY
    },
    {
        id: 9,
        client: 'Test Client 1',
        date: new Date('2023-11-30'),
        paymentDate: new Date('2023-12-9'),
        currency: 'PLN',
        netPrice: 11000,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 10,
        client: 'Test Client 2',
        date: new Date('2023-11-30'),
        paymentDate: new Date('2023-12-30'),
        currency: 'PLN',
        netPrice: 20000,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 11,
        client: 'John Doe',
        date: new Date('2023-10-27'),
        paymentDate: new Date('2023-10-27'),
        currency: 'PLN',
        netPrice: 500,
        vatRate: 23,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 12,
        client: 'John Smith',
        date: new Date('2023-10-20'),
        paymentDate: new Date('2023-10-27'),
        currency: 'USD',
        netPrice: 800,
        vatRate: 0,
        status: SENT,
        paymentStatus: PAID
    },
    {
        id: 13,
        client: 'John Smith',
        date: new Date('2023-10-20'),
        paymentDate: new Date('2023-10-27'),
        currency: 'PLN',
        netPrice: 1999.99,
        vatRate: 8,
        status: SENT,
        paymentStatus: PAID
    }
];