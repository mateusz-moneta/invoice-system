'use client';

import { createContext, Dispatch, SetStateAction, useContext, useState } from 'react';

interface AuthContextProps {
  token: string;
  setToken: Dispatch<SetStateAction<string>>;
}

const AuthContext = createContext<AuthContextProps>(undefined!);

export function AuthProvider({ children }: { children: React.ReactNode }) {
  const [token, setToken] = useState<string>('');

  return (
    <AuthContext.Provider
      value={{
        token,
        setToken
      }}
    >
      {children}
    </AuthContext.Provider>
  );
}

export function useAuthContext(): AuthContextProps {
  const context = useContext(AuthContext);

  if (typeof context === 'undefined') {
    throw new Error('useUserContext should be used within the UserContext provider!');
  }

  return context;
}
