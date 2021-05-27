import styled from 'styled-components';
import { color, font, queries } from '../../../globalStyle';

export const PostHeaderWrapper = styled.div`
  display: block;
`;

export const PostHeaderMetadataWrapper = styled.div`
  display: flex;
  padding-top: 16px;

  @media ${queries.mobile} {
    padding-top: 8px;
  }

  span:first-child {
    margin-left: 8px;
  }

  span:nth-child(2) {
    margin: 0 8px;
    display: flex;

    div:first-child {
      margin-right: 8px;
    }
  }

  span:last-child {
    border-right: 0;
  }
`;

export const PostHeaderMetadataElement = styled.span`
  color: ${color.dark.primary};
  font-family: ${font.primary};
  font-size: 24px;
  letter-spacing: 1px;
  line-height: 24px;
  text-align: left;
  border-right: 1px solid ${color.light.quaternary};
  padding-right: 2px;

  @media ${queries.mobile} {
    font-size: 12px;
    line-height: 18px;
    margin-left: 8px;
  }
`;

export const PostHeaderTitle = styled.h1`
  color: ${color.dark.primary};
  font-family: ${font.primary};
  font-size: 96px;
  font-weight: 600;
  margin: 16px 0 8px 0;
  letter-spacing: -1.5px;
  text-align: left;
  text-transform: capitalize;

  @media ${queries.tablet} {
    font-size: 60px;
    letter-spacing: -0.5px;
  }

  @media ${queries.mobile} {
    font-size: 34px;
  }
`;
