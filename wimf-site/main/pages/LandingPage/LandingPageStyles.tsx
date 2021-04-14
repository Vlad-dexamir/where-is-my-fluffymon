import styled from 'styled-components';

import {color, font} from '../../globalStyle';

export const LandingPageContainer = styled.div`
  display: grid;
  grid-template-columns: 1fr 1fr 1fr;
  grid-template-rows: 0.5fr 2.6fr 1.3fr;
  gap: 0 0;
  background: ${color.other.tertiary};
`;

export const LandingPageHeader = styled.div`
grid-area: 1 / 1 / 2 / 4;
display: flex;
flex-flow: column;
width: 100%;
align-items: center;
justify-content: center;
color: ${color.light.primary};
padding-top: 5%;
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
  background-image: url('https://storage.cloudconvert.com/tasks/b03b6bbe-8131-4f4b-a54e-92cba7024d00/banner-img.jpg?AWSAccessKeyId=cloudconvert-production&Expires=1618487997&Signature=alH5H42sX0k2AMArMebS%2BMFpRVE%3D&response-content-disposition=inline%3B%20filename%3D%22banner-img.jpg%22&response-content-type=image%2Fjpeg');
  background-position: right top;
  background-repeat: repeat space;
  padding-top: 100%;
  width: 100%;
  transform: scaleX(-1);
`;

export const LandingPageBannerLogoRight = styled.div`
grid-area: 2 / 3 / 3 / 4;
background-image: url('https://storage.cloudconvert.com/tasks/b03b6bbe-8131-4f4b-a54e-92cba7024d00/banner-img.jpg?AWSAccessKeyId=cloudconvert-production&Expires=1618487997&Signature=alH5H42sX0k2AMArMebS%2BMFpRVE%3D&response-content-disposition=inline%3B%20filename%3D%22banner-img.jpg%22&response-content-type=image%2Fjpeg');
background-position: right top;
background-repeat: repeat space;
padding-top: 100%;
width: 100%;

`;

export const LandingPageBannerDescription = styled.div`
grid-area: 2 / 2 / 3 / 3;
font: normal 24px/20px ${font.tertiary};
  padding-top: 25%;
  text-align: center;
  color: ${color.light.primary};
`;
