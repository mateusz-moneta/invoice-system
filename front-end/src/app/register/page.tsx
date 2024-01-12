'use client';
import { ChangeEvent, useState } from 'react';

import { Button } from '../components/shared/button';
import { LabeledInput } from '../components/shared/labeled-input';

import './page.scss';
import { navigate } from '@/app/utils/navigate';

const initialInputsState = {
  name: {
    value: '',
    valid: false
  },
  surname: {
    value: '',
    valid: false
  },
  username: {
    value: '',
    valid: false
  },
  email: {
    value: '',
    valid: false
  },
  password: {
    value: '',
    valid: false
  },
  repeatPassword: {
    value: '',
    valid: false
  }
};

export default function Page() {
  const [inputs, setInputs] = useState(initialInputsState);

  const handleChange = (event: ChangeEvent<HTMLInputElement | HTMLSelectElement>) => {
    const {
      name,
      value,
      validity: { valid }
    } = event.target;

    console.log(inputs);

    setInputs((values) => ({
      ...values,
      [name]: {
        value,
        valid
      }
    }));
  };

  const handleSubmit = () => {
    fetch('https://localhost:7110/api/users', {
      method: 'POST',
      headers: {
        accept: 'text/plain',
        'Content-Type': 'application/json'
      },
      body: JSON.stringify({
        name: inputs.name.value,
        surname: inputs.surname.value,
        userName: inputs.username.value,
        email: inputs.email.value,
        password: inputs.password.value
      }),
      mode: 'cors'
    })
      .then((response) => response.json())
      .then((response) => {
        console.log(response);
      });
  };

  return (
    <div className="container">
      <div className="row">
        <div className="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-12">
          <header>
            <h1>Register</h1>
          </header>
        </div>

        <div className="col-md-6 offset-md-3 col-sm-8 offset-sm-2 col-12">
          <form>
            <LabeledInput
              change={handleChange}
              label="Name"
              minLength={5}
              name="name"
              type="text"
              placeholder="Enter name"
              required={true}
            />

            <LabeledInput
              change={handleChange}
              label="Surname"
              minLength={5}
              name="surname"
              type="text"
              placeholder="Enter surname"
              required={true}
            />

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
              change={handleChange}
              label="E-mail"
              minLength={5}
              name="email"
              type="email"
              placeholder="Enter e-mail"
              required={true}
            />

            <LabeledInput
              change={handleChange}
              label="Password"
              name="password"
              placeholder="Enter password"
              required={true}
              type="password"
            />

            <LabeledInput
              change={handleChange}
              label="Repeat password"
              name="repeatPassword"
              placeholder="Repeat password"
              required={true}
              type="password"
            />

            <Button
              click={handleSubmit}
              disabled={
                Object.values(inputs).some(({ valid }) => !valid) ||
                inputs.password.value !== inputs.repeatPassword.value
              }
              theme="primary"
            >
              Create
            </Button>
          </form>
        </div>
      </div>
    </div>
  );
}
