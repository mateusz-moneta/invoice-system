// invoice status
const DRAFT = 'Draft';
const NEW = 'New';
const SENT = 'Sent';
const PENDING = 'Pending';

// payment status
const UNPAID = 'Unpaid';
const PAID = 'Paid';
const PARTIALLY = 'Partially';

export type InvoiceStatus = typeof DRAFT | typeof NEW | typeof SENT | typeof PENDING;
export type PaymentStatus = typeof UNPAID | typeof PAID | typeof PARTIALLY;

export { DRAFT, NEW, SENT, PENDING, UNPAID, PAID, PARTIALLY };
