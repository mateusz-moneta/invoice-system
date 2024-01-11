'use client';
import {InvoiceType} from "@/lib/invoice/InvoiceType";
import {dateFormatter, priceFormatter} from "../../../../lib/formatter";

export type InvoiceRowType = InvoiceType & {classNameTr: string, classNameTd: string, onClick?: Function}
export default function InvoicesListRow(props: InvoiceRowType) {
    const vatAmount: number = props.vatAmount ?? props.netPrice * (props.vatRate / 100);
    const grossPrice: number = props.grossPrice ?? props.netPrice + vatAmount;

    return (
        <tr className={props.classNameTr} onClick={() => props.onClick?.()}>
            <td className={props.classNameTd}>{props.id}</td>
            <td className={props.classNameTd}>{props.client}</td>
            <td className={props.classNameTd}>{dateFormatter(props.date)}</td>
            <td className={props.classNameTd}>{dateFormatter(props.paymentDate)}</td>
            <td className={props.classNameTd}>{priceFormatter(props.netPrice, props.currency)}</td>
            <td className={props.classNameTd}>{props.vatRate}%</td>
            <td className={props.classNameTd}>{priceFormatter(vatAmount, props.currency)}</td>
            <td className={props.classNameTd}>{priceFormatter(grossPrice, props.currency)}</td>
            <td className={props.classNameTd}>{props.status}</td>
            <td className={props.classNameTd}>{props.paymentStatus}</td>
        </tr>
    );
}