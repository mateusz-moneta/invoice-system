import { Children } from 'react';

type Props = {
  title: string;
  children: Children;
};

export default function Form(props: Props) {
  return (
    <>
      <form>
        <h1 className={'h1 mb-3'}>{props.title}</h1>
        {props.children}
        <button
          type="submit"
          className={
            'text-white focus:ring-4 focus:outline-none font-medium rounded-lg text-sm w-full sm:w-auto px-5 py-2.5 text-center bg-blue-600 hover:bg-blue-700 focus:ring-blue-800'
          }
        >
          Submit
        </button>
      </form>
    </>
  );
}
