import styled from 'styled-components';
import { color, device } from '../../../globalStyle';

export const ArrowBtnTrays = styled.button<{
  alignToRight?: boolean;
}>`
  outline: none;
  background-color: ${color.dark.primary};
  border: 4px solid ${color.accent.tertiary};
  border-radius: 100%;
  position: absolute;
  cursor: pointer;
  color: ${color.light.primary};
  ${({ alignToRight }) => (alignToRight ? 'right: -10px;' : 'left: -10px;')}
  z-index: 5;
  top: 50%;
  transform: translateY(calc(-50% - 62px));
  font-size: 1rem;
  padding: 8px 12px;
  display: none;

  @media ${device.tablet} {
    display: flex;
  }
`;
