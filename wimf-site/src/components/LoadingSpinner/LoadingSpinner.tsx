import React from 'react';

import { LoadingLogo } from './LoadingLogo';
import { LoadingSpinnerStyles } from './LoadingSpinnerStyles';

export const LoadingSpinner: React.FC = () => (
  <LoadingSpinnerStyles>
    <LoadingLogo />
  </LoadingSpinnerStyles>
);
