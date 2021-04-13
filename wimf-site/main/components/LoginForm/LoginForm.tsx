import React, { FC } from 'react';
import * as Yup from 'yup';
import { PersonError } from '../../core/errors/PersonError';
import { PersonConstraints } from '../../core/domain/PersonInfo';
import { useFormik } from 'formik';
import { LoginFormWrapper, Form, LoginFormField } from './LoginFormStyles';
import { Button } from '../elements/Button/Button';
import { Input } from '../elements/Input/Input';

type LoginFormValues = {
  email: string;
  password: string;
};

const validationSchema: Yup.SchemaOf<LoginFormValues> = Yup.object().shape({
  email: Yup.string()
    .email(PersonError.EMAIL_INVALID)
    .required(PersonError.EMAIL_REQUIRED),
  password: Yup.string()
    .min(PersonConstraints.passwordMin, PersonError.PASSWORD_MIN)
    .max(PersonConstraints.passwordMax, PersonError.PASSWORD_MAX)
    .required(PersonError.PASSWORD_REQUIRED),
});

const initialValues: LoginFormValues = {
  email: '',
  password: '',
};

const LoginForm: FC = () => {
  const onSubmit = (values: LoginFormValues) => {
    console.log(values);
  };

  const formik = useFormik<LoginFormValues>({
    initialValues,
    validationSchema,
    onSubmit,
  });

  const {
    handleSubmit,
    handleChange,
    errors,
    touched,
    values: { email, password },
  } = formik;

  return (
    <LoginFormWrapper>
      <Form onSubmit={handleSubmit}>
        <LoginFormField>
          <Input
            name="email"
            label="Email"
            type="email"
            value={email}
            placeholder="Email"
            handleChange={handleChange}
            errorMessage={(touched.email && errors.email) as string}
          />
        </LoginFormField>
        <LoginFormField>
          <Input
            name="password"
            label="Password"
            type="password"
            value={password}
            placeholder="Password"
            handleChange={handleChange}
            errorMessage={(touched.password && errors.password) as string}
          />
        </LoginFormField>
        <Button type="submit">Login</Button>
      </Form>
    </LoginFormWrapper>
  );
};

export { LoginForm };
