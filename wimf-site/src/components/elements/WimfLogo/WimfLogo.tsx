import React from 'react';
import { StyledLogo } from './WimfLogoStyles';
import logo from '../../../mocks/images/logo.png';

export const WimfLogo: React.FC = () => (
  <StyledLogo src={logo} alt="WimfLOGO" width={200} />
);
