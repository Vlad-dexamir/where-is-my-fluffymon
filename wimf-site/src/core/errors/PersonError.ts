import { PersonConstraints } from '../domain/UserInfo';

export const PersonError = {
  EMAIL_INVALID: 'Email must be a valid one',
  EMAIL_REQUIRED: 'Email is a required field',
  PASSWORD_MIN: `Password must be at least ${PersonConstraints.passwordMin} characters`,
  PASSWORD_MAX: `Password must be maximum ${PersonConstraints.passwordMax} characters`,
  PASSWORD_REQUIRED: 'Password is a required field',
};
