'use client'

import Form from "../Form";
import React, {useState} from "react";
import {COMPANY, PERSON} from "../../../enums/dashboard/customers/customerTypeEnum";

const labelClassName = 'block mb-2 text-sm font-medium text-white';
const inputClassName = 'border text-sm rounded-lg block w-full p-2.5 bg-gray-700 border-gray-600 placeholder-gray-400 text-white focus:ring-blue-500 focus:border-blue-500';

export default function InvoiceForm() {
    const [selectValue, setSelectValue] = useState(0);

    return (
        <Form title={'Add Customer'}>
            <div className={"grid gap-6 mb-6 md:grid-cols-2"}>
                <div>
                    <label htmlFor="customerType" className={labelClassName}>Select an option</label>
                    <select value={selectValue} onChange={(e: any) => setSelectValue(e.target.value)} id="customerType" className={inputClassName} required>
                        <option selected disabled value={0}>Choose a type</option>
                        <option value={COMPANY}>Company</option>
                        <option value={PERSON}>Person</option>
                    </select>
                </div>
                <div>
                    <label htmlFor="name" className={labelClassName}>Name</label>
                    <input type="text" id="name" className={inputClassName} placeholder="Name" required />
                </div>
                <div>
                    <label htmlFor="currency" className={labelClassName}>Currency</label>
                    <input type="text" id="currency" className={inputClassName} placeholder="Currency" required />
                </div>
                {selectValue === COMPANY ?
                <div>
                    <label htmlFor="vatnumber" className={labelClassName}>Phone number</label>
                    <input type="text" id="vatnumber" className={inputClassName} placeholder="VAT number" pattern="[A-Z]?[A-Z]?[0-9]{10}" required />
                </div> : null}
            </div>
            <div className={"mb-6"}>
                <label htmlFor="email" className={labelClassName}>Email address</label>
                <input type="email" id="email" className={inputClassName} placeholder="john.doe@company.com" required />
            </div>
        </Form>
    );
}