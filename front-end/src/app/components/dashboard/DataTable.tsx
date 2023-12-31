'use client';

import React, {useState} from "react";

type Props = {
    rows: { [key: string]: any }[],
    columns: string[],
    rowComponent: Function,
    rowsPerPage?: number,
};

const makeRows = (rows: { [key: string]: any }[], rowComponent: Function): React.JSX.Element[] => {
    return rows.map((row: { [key: string]: any }, index: number) => {
        const props = {
            ...row,
            key: index,
            classNameTd: `border-b border-slate-700 p-4 text-slate-${index % 2 === 0 ? '800' : '400'}`,
            classNameTr: index % 2 === 0 ? 'bg-slate-600' : ''
        };

        return rowComponent(props)
    });
}

const limitRows = (rows: { [key: string]: any }, rowsPerPage: number, page: number): { [key: string]: any }[] => {
    const start: number = (page - 1) * rowsPerPage;
    const end: number = start + rowsPerPage;
    return rows.slice(start, end);
}

const thead = (columns: string[]): React.JSX.Element[] => columns.map((column: string, index: number): React.JSX.Element => (
    <th key={index} className={'border-slate-600 font-medium p-4 pt-0 pb-3 text-slate-200 text-left'}>{column}</th>
));

export default function DataTable(props: Props) {
    const rowsPerPage: number = props.rowsPerPage ?? 10;
    const numberOfPages: number = Math.ceil(props.rows.length / rowsPerPage);
    const [page, setPage] = useState(1);
    const [rows, setRows] = useState(makeRows(limitRows(props.rows, rowsPerPage, page), (_props: any) => props.rowComponent(_props)));
    const pagination = (action: 'plus'|'minus') => {
        const _page = action === 'plus' ?
            (page < numberOfPages ? page + 1 : 1) :
            (page > 1 ? page - 1 : numberOfPages);
        setPage(_page)
        setRows(makeRows(limitRows(props.rows, rowsPerPage, _page), (_props: any) => props.rowComponent(_props)));
    }

    return (
        <div className="relative rounded-xl overflow-auto">
            <div className="shadow-sm overflow-auto my-8">
                <table className={'border-collapse table-auto w-full overflow-scroll'}>
                    <caption className={'caption-bottom'}>
                        Page: {page} of {numberOfPages}
                        <button className={'p-2 bg-slate-600'} onClick={() => { pagination('minus') }}>-</button>
                        <button className={'p-2 bg-slate-600'} onClick={() => { pagination('plus') }}>+</button>
                    </caption>
                    <thead>
                        <tr>
                            {thead(props.columns)}
                        </tr>
                    </thead>
                    <tbody className={'bg-slate-800'}>
                        {rows}
                    </tbody>
                </table>
            </div>
        </div>
    );
}