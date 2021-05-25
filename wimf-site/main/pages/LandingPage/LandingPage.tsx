import React from 'react';
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
import { Button } from '../../components/elements/Button/Button';

export type LandingPageProps = {
  title: string;
  subtitle: string;
  description: string;
};

export const LandingPage: React.FC<LandingPageProps> = ({
  title,
  subtitle,
  description,
}) => {
  return (
    <LandingPageContainer>
      <LandingPageHeader>
        <LandingPageTitle>{title}</LandingPageTitle>
        <LandingPageSubtitle>{subtitle}</LandingPageSubtitle>
      </LandingPageHeader>
      <LandingPageBannerLogoLeft />
      <LandingPageBannerLogoRight />
      <LandingPageBannerDescription>
        {description}
        <LandingPageJoinUsContainer>
          <Button type="button">Join us</Button>
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
