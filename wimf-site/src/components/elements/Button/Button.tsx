import React from 'react';

import { ButtonStyles } from './ButtonStyles';

type ButtonProps = {
  children?: React.ReactNode;
  className?: string;
  disabled?: boolean;
  handleClick?: (
    event: React.MouseEvent<HTMLButtonElement, MouseEvent>,
  ) => void;
  handleTouchStart?: (event: React.TouchEvent<HTMLButtonElement>) => void;
  type: 'button' | 'submit' | 'reset';
};

export const Button: React.FC<ButtonProps> = ({
  children,
  className,
  disabled,
  handleClick,
  handleTouchStart,
  type = 'button',
}) => (
  <ButtonStyles
    className={className}
    disabled={disabled}
    onClick={handleClick}
    onTouchStart={handleTouchStart}
    type={type}
  >
    {children}
  </ButtonStyles>
);
