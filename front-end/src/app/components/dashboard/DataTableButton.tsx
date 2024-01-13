import { Children } from 'react';
import Link from 'next/link';

type Props = {
  first?: boolean;
  middle?: boolean;
  last?: boolean;
  onClick?: Function;
  children: Children;
  disabled?: boolean;
  link?: string;
};

const classNames = {
  first:
    'px-4 py-2 text-sm font-medium border bg-gray-700 border-gray-600 rounded-s-lg text-white hover:text-white hover:bg-gray-600 focus:ring-blue-500 focus:text-white',
  middle:
    'px-4 py-2 text-sm font-medium border-t border-b focus:z-10 focus:ring-2 focus:ring-blue-700 focus:text-blue-700 bg-gray-700 border-gray-600 text-white hover:text-white hover:bg-gray-600 focus:ring-blue-500 focus:text-white',
  last: 'px-4 py-2 text-sm font-medium border rounded-e-lg focus:z-10 focus:ring-2 focus:ring-blue-700 focus:text-blue-700 bg-gray-700 border-gray-600 text-white hover:text-white hover:bg-gray-600 focus:ring-blue-500 focus:text-white'
};
export default function DataTableButton(props: Props) {
  const className: string = props.first
    ? classNames.first
    : props.middle
      ? classNames.middle
      : classNames.last;
  return (
    <>
      {props.onClick ? (
        <button
          className={className}
          onClick={() => props.onClick()}
          disabled={props.disabled as boolean}
        >
          {props.children}
        </button>
      ) : props.link ? (
        <Link href={props.disabled ? '#' : props.link} className={className}>
          {props.children}
        </Link>
      ) : (
        <></>
      )}
    </>
  );
}
