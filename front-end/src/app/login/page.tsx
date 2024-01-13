'use client';
import { ChangeEvent, useState } from 'react';


import { redirect } from 'next/navigation';

import { Button } from '../components/shared/button';
import { LabeledInput } from '../components/shared/labeled-input';

import { navigate } from '../utils/navigate';
import { useAuthContext } from '../auth-provider';

import './page.scss';

const initialInputsState = {
  username: {
    value: '',
    valid: false
  },
  password: {
    value: '',
    valid: false
  }
};

export default function Page() {
  const [inputs, setInputs] = useState(initialInputsState);
  const { setToken } = useAuthContext();

  const handleChange = (event: ChangeEvent<HTMLInputElement>) => {
    const {
      name,
      value,
      validity: { valid }
    } = event.target;

    setInputs((values) => ({
      ...values,
      [name]: {
        value,
        valid
      }
    }));
  };

  const handleSubmit = () => {
    fetch('https://localhost:7110/api/auth', {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        userName: inputs.username.value,
        password: inputs.password.value
      }),
      mode: 'cors'
    })
      .then((response) => response.json())
      .then(({ token }: { token: string }) => {
        setToken(token);

        return navigate('/dashboard');
      });
  };

  return (
    <div className="container">
      <div className="row h-100">
        <div className="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-12">
          <header>
            <h1>Login</h1>
          </header>
        </div>

        <div className="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-12">
          <form>
            <LabeledInput
              change={handleChange}
              label="Username"
              minLength={5}
              name="username"
              type="text"
              placeholder="Enter username"
              required={true}
            />

            <LabeledInput
              autoComplete="on"
              change={handleChange}
              label="Password"
              minLength={5}
              name="password"
              placeholder="Enter password"
              required={true}
              type="password"
            />

            <Button
              click={handleSubmit}
              disabled={Object.values(inputs).some(({ valid }) => !valid)}
              theme="primary"
            >
              Log In
            </Button>
          </form>
        </div>
      </div>
    </div>
  );
}
