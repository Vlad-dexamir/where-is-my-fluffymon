import styled from 'styled-components';
import { color, device, font, queries } from '../../globalStyle';

export const Logo = styled.div`
  svg {
    display: inline-block;
    height: 40px;
    width: auto;
    transition: height 0.3s ease-out;

    @media ${queries.tablet} {
      margin: 0;
      height: 24px;
    }

    @media ${queries.mobile} {
      height: 20px;
    }
  }
`;

export const Navigation = styled.nav`
  position: fixed;
  top: 0;
  width: 100%;
  z-index: 100;
  background-color: ${color.light.primary};
  border-bottom: thin solid ${color.light.tertiary};
  margin: 0;
  padding: 0 48px;
  height: 80px;
  display: flex;
  align-items: center;
  color: ${color.dark.primary};
  font-family: ${font.primary};
  font-weight: 600;
  font-size: 16px;
  text-transform: uppercase;
  letter-spacing: 1px;
  line-height: 24px;

  transition: height 0.3s ease-out;

  @media ${queries.tablet} {
    padding: 0 24px;
    height: 40px;
  }

  @media ${queries.mobile} {
    height: 40px;
    padding: 0;
  }

  .svg-inline--fa {
    margin-left: 4px;
  }

  &.scrolling-nav {
    @media ${device.laptop} {
      height: 64px;
      ${Logo} {
        svg {
          height: 32px;
        }
      }
    }
  }
`;

export const NavigationItem = styled.a`
  color: ${color.dark.primary};
  text-decoration: none;
  position: relative;
  cursor: pointer;
  text-align: left;
  margin-right: 24px;
  transition: color 0.4s ease-out;
  font-size: 20px;
  font-weight: 600;

  &:hover,
  &.active {
    color: ${color.other.primary};
  }

  @media ${queries.tablet} {
    font-size: 12px;
  }

  @media ${queries.mobile} {
    font-size: 16px;
    margin: 8px 0;
  }
`;

export const NavButton = styled.span`
  line-height: 1.5rem;
  padding: 8px 14px;
  cursor: pointer;

  > * {
    user-select: none;
  }

  @media ${device.tablet} {
    display: none;
  }

  .svg-inline--fa {
    margin: 0;
  }
`;

export const NavList = styled.span`
  padding: 0;
  display: flex;
  justify-content: space-between;
  align-items: center;
  width: 100%;
  z-index: 1000;
  position: absolute;
  top: calc(100% + 1px);
  left: 0;
  background-color: ${color.light.primary};
  transition: all 0.3s ease-in-out;

  @media ${device.tablet} {
    position: static;
  }

  @media ${queries.mobile} {
    max-height: 0;
    overflow: hidden;
    box-shadow: rgba(0, 0, 0, 0.1) 0px 8px 8px;
  }

  &.toggled {
    @media ${queries.mobile} {
      max-height: 600px;
    }
  }
`;

export const NavListContent = styled.span`
  padding: 0 16px;
  flex-direction: row;
  box-shadow: none;
  position: static;
  order: unset;
  visibility: unset;
  height: unset;
  width: unset;
  flex: 1;
  background-color: ${color.light.primary};
  @media ${queries.mobile} {
    padding: 8px 16px;
    display: flex;
    flex-direction: column;
    order: 1;
    .svg-inline--fa {
      float: right;
      margin-top: 4px;
    }
  }
`;
