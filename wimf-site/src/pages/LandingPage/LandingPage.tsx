import React, { useState } from 'react';
import { FontAwesomeIcon } from '@fortawesome/react-fontawesome';
import { faQuestion } from '@fortawesome/free-solid-svg-icons';

import {
  LandingPageAboutUsContainer,
  LandingPageAboutUsHeader,
  LandingPageAboutUsIconWrapper,
  LandingPageAboutUsTitle,
  LandingPageBannerDescription,
  LandingPageBannerLogoLeft,
  LandingPageBannerLogoRight,
  LandingPageContainer,
  LandingPageHeader,
  LandingPageJoinUsContainer,
  LandingPageLegalInfoContainer,
  LandingPageServicesContainer,
  LandingPageSubtitle,
  LandingPageTitle,
} from './LandingPageStyles';
import {ModalBox} from "../../components/elements/Modal";
import {Button} from "../../components/elements/Button/Button";
import {LoginForm} from "../../components/LoginForm";
import {RegisterForm} from "../../components/RegisterForm";
import {landingPageMock} from "../../mocks/landingPageMock";

export type LandingPageProps = {
  title: string;
  subtitle: string;
  description: string;
};

export const LandingPage: React.FC<LandingPageProps> = ({
  title = landingPageMock.title,
  subtitle = landingPageMock.subtitle,
  description = landingPageMock.description,
}) => {
  const [isLoginMounted, updateLoginMounted] = useState<boolean>(false);
  const [isRegisterMounted, updateRegisterMounted] = useState<boolean>(false);

  const handleClose = () => {
    updateLoginMounted(false);
    updateRegisterMounted(false);
  };

  const mountLogin = () => {
    updateLoginMounted(true);
    updateRegisterMounted(false);
  };

  const mountRegister = () => {
    updateRegisterMounted(true);
    updateLoginMounted(false);
  };

    return (
    <LandingPageContainer>
            <ModalBox
                isOpen={isLoginMounted || isRegisterMounted}
                handleClose={handleClose}
            >
              <>
                {isLoginMounted && <LoginForm/>}
                {isRegisterMounted && <RegisterForm/>}
              </>
            </ModalBox>
      <LandingPageHeader>
        <LandingPageTitle>{title}</LandingPageTitle>
        <LandingPageSubtitle>{subtitle}</LandingPageSubtitle>
      </LandingPageHeader>
      <LandingPageBannerLogoLeft />
      <LandingPageBannerLogoRight />
      <LandingPageBannerDescription>
        {description}
        <LandingPageJoinUsContainer>
          <Button type="button" handleClick={mountLogin}>
            Login
          </Button>
          <Button type="button" handleClick={mountRegister}>
            Register
          </Button>
        </LandingPageJoinUsContainer>
      </LandingPageBannerDescription>
      <LandingPageAboutUsContainer>
        <LandingPageAboutUsHeader>
          <LandingPageAboutUsTitle>About us</LandingPageAboutUsTitle>
          <LandingPageAboutUsIconWrapper>
            <FontAwesomeIcon icon={faQuestion} size="lg" />
          </LandingPageAboutUsIconWrapper>
        </LandingPageAboutUsHeader>
      </LandingPageAboutUsContainer>
      <LandingPageServicesContainer></LandingPageServicesContainer>
      <LandingPageLegalInfoContainer></LandingPageLegalInfoContainer>
    </LandingPageContainer>
  );
};
