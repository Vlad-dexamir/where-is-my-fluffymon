import styled from 'styled-components';

import { color, font, queries } from '../../../globalStyle';

export const InputWrapper = styled.div`
  display: flex;
  flex-flow: column;
  font-family: ${font.primary};
`;

export const InputLabel = styled.label<{ disabled: boolean }>`
  color: ${color.dark.primary};
  font-size: 16px;
  letter-spacing: 1px;
  text-align: left;
  margin-bottom: 8px;
  font-weight: 400;

  ${({ disabled }) => disabled && `color: ${color.dark.quaternary};`}
`;

export const InputStyle = styled.input<{ disabled: boolean }>`
  background-color: ${color.light.primary};
  flex-basis: 100%;
  text-align: left;
  padding: 16px;
  border: 1px solid ${color.dark.primary};
  font-family: ${font.primary};
  border-radius: 4px;
  min-width: 300px;

  ${({ disabled }) =>
    disabled &&
    `
    color: ${color.dark.quaternary};
    border: 1px solid ${color.dark.quaternary};
    `}

  &::placeholder {
    color: ${color.dark.quaternary};
  }

  &:focus {
    outline: none;
    border: 1px solid ${color.other.primary};
  }

  &.error {
    border: 1px solid ${color.accent.primary};

    &:focus {
      border: 1px solid ${color.accent.primary};
    }
  }

  @media ${queries.tablet} {
    padding: 8px 16px;
  }

  @media ${queries.mobile} {
    min-width: auto;
  }
`;

export const InputFeedback = styled.p`
  color: ${color.accent.primary};
  margin: 0;
  font-size: 12px;
  padding-top: 4px;
  font-weight: 400;
`;

export const InputHelper = styled.p<{ disabled: boolean }>`
  color: ${color.dark.primary};
  margin: 0;
  padding-top: 4px;
  font-size: 12px;
  font-weight: 400;

  ${({ disabled }) =>
    disabled &&
    `
    color: ${color.dark.quaternary};
    `}
`;
