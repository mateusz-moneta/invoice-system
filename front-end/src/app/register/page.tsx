'use client'
import { ChangeEvent, useState } from "react";

import { Button } from "../components/shared/button";
import { LabeledInput } from "../components/shared/labeled-input";

import "./page.scss";

const initialInputsState = {
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

        setInputs((values) => ({
            ...values,
            [name]: {
                value,
                valid
            }
        }));
    };

    const handleSubmit = () => {};

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
                                inputs.password !== inputs.repeatPassword
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
