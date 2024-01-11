'use client';
import {customers} from "../../../../lib/customer/mockCustomers";
import React from "react";
import DataTable from "@/app/components/dashboard/DataTable";
import CustomersListRow, {CustomersRowType} from "./CustomersListRow";

export default function CustomersList() {
    return (
        <DataTable rows={customers}
                   columns={[
                       'id',
                       'type',
                       'name',
                       'email',
                       'currency',
                       'VAT number'
                   ]}
                   rowComponent={(props: CustomersRowType & {key: number}) => <CustomersListRow {...props} key={props.key} />}
                   rowsPerPage={5}
                   pageName={'customers'}
        />
    )
}