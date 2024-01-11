'use client';
import InvoicesListRow, {InvoiceRowType} from "@/app/components/dashboard/invoices/InvoicesListRow";
import {invoices} from "@/lib/invoice/mockInvoices";
import React from "react";
import DataTable from "@/app/components/dashboard/DataTable";

export default function InvoicesList() {
    return (
        <DataTable rows={invoices}
                   columns={[
                       'id',
                       'Client Name',
                       'Created at',
                       'Payment date',
                       'Net price',
                       'VAT rate',
                       'VAT amount',
                       'Gross price',
                       'Status',
                       'Payment status'
                   ]}
                   rowComponent={(props: InvoiceRowType & {key: number}) => <InvoicesListRow {...props} key={props.key} />}
                   rowsPerPage={5}
                   pageName={'invoices'}
        />
    )
}