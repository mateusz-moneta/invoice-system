'use client';
import Link from 'next/link';
import { useRef } from 'react';

type MenuType = { title: string; link: string };

const menuItems: MenuType[] = [
  { title: 'Dashboard', link: '/dashboard' },
  { title: 'Invoices', link: '/dashboard/invoices' },
  { title: 'Customers', link: '/dashboard/customers' }
];

export default function LeftMenu() {
  const menuRef = useRef(null);
  const mobileMenu = (show: boolean) => {
    const menu = menuRef.current;
    if (!show) {
      menu.className += ' -translate-x-full';
      menu.parentElement.onclick = () => {};
    }
    if (show) {
      menu.className =
        'fixed top-0 left-0 z-40 w-64 h-screen transition-transform sm:translate-x-0';
      menu.parentElement.onclick = () => mobileMenu(false);
    }
  };
  return (
    <>
      <button
        aria-controls="default-sidebar"
        type="button"
        className={
          'inline-flex items-center p-2 mt-2 ms-3 text-sm text-gray-400 rounded-lg sm:hidden focus:outline-none focus:ring-2 hover:bg-gray-700 focus:ring-gray-600'
        }
        onClick={() => mobileMenu(true)}
      >
        <span className={'sr-only'}>Open sidebar</span>
        <svg
          className={'w-6 h-6'}
          aria-hidden="true"
          fill="currentColor"
          viewBox="0 0 20 20"
          xmlns="http://www.w3.org/2000/svg"
        >
          <path
            clipRule="evenodd"
            fillRule="evenodd"
            d="M2 4.75A.75.75 0 012.75 4h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 4.75zm0 10.5a.75.75 0 01.75-.75h7.5a.75.75 0 010 1.5h-7.5a.75.75 0 01-.75-.75zM2 10a.75.75 0 01.75-.75h14.5a.75.75 0 010 1.5H2.75A.75.75 0 012 10z"
          />
        </svg>
      </button>

      <aside
        id="default-sidebar"
        className={
          'fixed top-0 left-0 z-40 w-64 h-screen transition-transform -translate-x-full sm:translate-x-0'
        }
        aria-label="Sidebar"
        ref={menuRef}
      >
        <div className={'h-full px-3 py-4 overflow-y-auto bg-gray-800'}>
          <ul className={'space-y-2 font-medium'}>
            {menuItems.map((item: MenuType, index: number) => (
              <li key={index}>
                <Link
                  href={item.link}
                  className={'flex items-center p-2 rounded-lg text-white hover:bg-gray-700 group'}
                >
                  <span className={'ms-3'}>{item.title}</span>
                </Link>
              </li>
            ))}
          </ul>
        </div>
      </aside>
    </>
  );
}
