import React from 'react';
import { LandingPageContainer, LandingPageTitle } from './LandingPageStyles';
import { LoginForm } from '../../components/LoginForm/LoginForm';

export const LandingPage: React.FC = () => {
  return (
    <LandingPageContainer>
      <LandingPageTitle>Member Login</LandingPageTitle>
      <LoginForm />
    </LandingPageContainer>
  );
};
