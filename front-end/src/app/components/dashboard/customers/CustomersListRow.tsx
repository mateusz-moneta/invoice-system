'use client';
import {CustomerType} from "@/lib/customer/CustomerType";

export type CustomersRowType = CustomerType & {classNameTr: string, classNameTd: string, onClick?: Function}
export default function CustomersListRow(props: CustomersRowType) {
    return (
        <tr className={props.classNameTr} onClick={() => props.onClick?.()}>
            <td className={props.classNameTd}>{props.id}</td>
            <td className={props.classNameTd}>{props.type}</td>
            <td className={props.classNameTd}>{props.name}</td>
            <td className={props.classNameTd}>{props.email}</td>
            <td className={props.classNameTd}>{props.currency}</td>
            <td className={props.classNameTd}>{props.vatnumber ?? '-'}</td>
        </tr>
    );
}