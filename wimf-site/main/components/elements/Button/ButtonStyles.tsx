import styled from 'styled-components';

import { color, font } from '../../../globalStyle';

export const ButtonStyles = styled.button`
  background-color: ${color.dark.primary};
  border: 1px solid ${color.dark.primary};
  box-sizing: border-box;
  color: ${color.light.primary};
  cursor: pointer;
  font-family: ${font.primary};
  font-weight: 500;
  font-size: 16px;
  text-align: center;
  margin: 0;
  padding: 16px 32px;
  text-transform: uppercase;
  line-height: 24px;
  border-radius: 4px;

  &:hover {
    background-color: ${color.dark.tertiary};
    border: 1px solid ${color.dark.tertiary};

    color: ${color.light.primary};
  }

  &:focus {
    outline: 0;
  }

  &:active {
    background-color: ${color.dark.quaternary};
    border: 1px solid ${color.dark.quaternary};
  }

  &:disabled {
    background-color: ${color.light.tertiary};
    border: 1px solid ${color.light.tertiary};

    color: ${color.dark.quaternary};
  }

  &.small {
    padding: 8px 16px;
  }
`;
