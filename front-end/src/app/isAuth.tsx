'use client';

import { useEffect } from 'react';
import { redirect } from 'next/navigation';

import { useAuthContext } from './auth-provider';

export default function isAuth(Component: any) {
  return (props: any) => {
    const { token } = useAuthContext();

    useEffect(() => {
      if (!token) {
        return redirect('/login');
      }
    }, []);

    if (!token) {
      return null;
    }

    return <Component {...props} />;
  };
}
