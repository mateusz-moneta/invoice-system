import {InvoiceStatus, PaymentStatus} from "@/app/enums/dashboard/invoices/statusEnum";

export type InvoiceType = {
    id: number,
    client: string,
    date: Date,
    paymentDate: Date,
    currency: string,
    netPrice: number,
    grossPrice?: number,
    vatRate: number,
    vatAmount?: number,
    status: InvoiceStatus,
    paymentStatus: PaymentStatus
};