import styled from 'styled-components';

import { color, font } from '../../globalStyle';

export const LandingPageContainer = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-rows: 0.5fr 1fr 1.2fr;
  gap: 0 0;
  background: ${color.other.tertiary};
  scroll-behavior: smooth;
`;

export const LandingPageHeader = styled.div`
  grid-area: 1 / 1 / 2 / 4;
  display: flex;
  flex-flow: column;
  width: 100%;
  align-items: center;
  justify-content: center;
  color: ${color.light.primary};
  padding: 64px 0;
`;

export const LandingPageTitle = styled.div`
  font: bold 64px/32px ${font.quaternary};
  margin: 12px 0 24px;
`;

export const LandingPageSubtitle = styled.div`
  font: normal 36px/24px ${font.tertiary};
  letter-spacing: 1.5px;
  margin: 12px 0;
`;

export const LandingPageBannerLogoLeft = styled.div`
  grid-area: 2 / 1 / 3 / 2;
  background-image: url('https://toppng.com/public/uploads/thumbnail/ug-free-png-image-dog-pug-115629722354gjk8cx7fs.png');
  background-position: center top;
  background-repeat: no-repeat;
  padding-top: 100%;
  width: 100%;
  height: 0;
  transform: scaleX(1);
`;

export const LandingPageBannerLogoRight = styled.div`
  grid-area: 2 / 3 / 3 / 4;
  background-image: url('https://toppng.com/public/uploads/thumbnail/ug-free-png-image-dog-pug-115629722354gjk8cx7fs.png');
  background-position: center top;
  background-repeat: no-repeat;
  padding-top: 100%;
  width: 100%;
  height: 0;
  transform: scaleX(-1);
`;

export const LandingPageBannerDescription = styled.div`
  grid-area: 2 / 2 / 3 / 3;
  font: normal 24px/20px ${font.quaternary};
  padding-top: 48px;
  text-align: center;
  color: ${color.dark.primary};
`;

export const LandingPageJoinUsContainer = styled.div`
  padding: 32px 0;
  display: flex;
  align-items: center;
  justify-content: space-around;

  button {
    font-family: ${font.quaternary};
  }
`;

export const LandingPageAboutUsContainer = styled.div`
  grid-area: 3 / 1 / 3 / 2;
  display: flex;
  flex-flow: column;
  margin: 0 48px 48px;
  align-items: center;
  max-height: 425px;
  box-shadow: 0 0 35px 5px ${color.dark.primary};
`;

export const LandingPageAboutUsHeader = styled.div`
  display: flex;
  padding: 24px 0;
  color: ${color.light.primary};
  font-family: ${font.quaternary};
  font-size: 28px;
`;

export const LandingPageAboutUsIconWrapper = styled.div`
  margin: 0 8px;
  font-size: 24px;
`;

export const LandingPageAboutUsTitle = styled.h2`
  margin: 0 8px;
`;
export const LandingPageAboutUsText = styled.div``;

export const LandingPageServicesContainer = styled.div`
  grid-area: 3 / 2 / 3 / 3;
`;

export const LandingPageLegalInfoContainer = styled.div`
  grid-area: 3 / 3 / 3 / 4;
`;
