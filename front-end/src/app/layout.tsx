import type { Metadata } from 'next';
import { Nunito } from 'next/font/google';

import { AuthProvider } from './user-provider';

import 'bootstrap/dist/css/bootstrap.css';
import './globals.scss';

const nunito = Nunito({ subsets: ['latin'] });

export const metadata: Metadata = {
  title: 'Invoice System'
};

export default function RootLayout({ children }: { children: React.ReactNode }) {
  return (
    <html lang="en">
      <AuthProvider>
        <body className={nunito.className}>{children}</body>
      </AuthProvider>
    </html>
  );
}
