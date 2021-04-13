import styled from 'styled-components';
import { font } from '../../globalStyle';

export const LandingPageTitle = styled.div`
  font: bold 32px/24px ${font.primary};
  text-align: center;
  position: absolute;
  left: 50%;
  top: 20%;
  transform: translate(-50%, -50%);
`;

export const LandingPageContainer = styled.div`
  padding: 32px;
  display: flex;
  justify-content: center;
`;
