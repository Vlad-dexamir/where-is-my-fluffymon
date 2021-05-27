import { createGlobalStyle } from 'styled-components';

export const size = {
  mobileS: '320px',
  mobileM: '375px',
  mobileL: '424px',
  tablet: '767px',
  laptop: '1023px',
  laptopM: '1280px',
  laptopL: '1439px',
  desktop: '1919px',
};

export const device = {
  mobileS: `(min-width: ${size.mobileS})`,
  mobileM: `(min-width: ${size.mobileM})`,
  mobileL: `(min-width: ${size.mobileL})`,
  tablet: `(min-width: ${size.tablet})`,
  laptop: `(min-width: ${size.laptop})`,
  laptopL: `(min-width: ${size.laptopL})`,
  desktop: `(min-width: ${size.desktop})`,
};

export const queries = {
  mobileS: `screen and (max-width: ${size.mobileM})`,
  mobileM: `screen and (max-width: ${size.mobileL})`,
  mobile: `screen and (max-width: ${size.tablet})`,
  tablet: `screen and (max-width: ${size.laptop})`,
  laptopS: `screen and (max-width: ${size.laptopM})`,
  laptop: `screen and (max-width: ${size.laptopL})`,
  desktop: `screen and (max-width: ${size.desktop})`,
};

export const color = {
  dark: {
    primary: '#000000',
    secondary: '#2D2D2E',
    tertiary: '#48484A',
    quaternary: '#8E8E93',
  },
  light: {
    primary: '#FFFFFF',
    secondary: '#F2F2F2',
    tertiary: '#D1D1D6',
    quaternary: '#AEAEB2',
  },
  accent: {
    primary: '#ED1C24',
    primaryOver: '#9a031e',
    secondary: '#e36414',
    tertiary: '#EFF8FA',
    quaternary: '#7C0D11',
  },
  other: {
    primary: '#008AAF',
    secondary: '#32A6A6',
    tertiary: '#ecb42c',
    quaternary: '#95D5D1',
  },
};

export const font = {
  primary: 'Merriweather, sans-serif',
  secondary: 'Roboto Condensed, sans-serif',
  tertiary: 'Amatic SC, cursive',
  quaternary: 'Train One, cursive',
};

export const GlobalStyle = createGlobalStyle`
  * {
    box-sizing: border-box;
  }

  html, body, div, span, applet, object, iframe,
  h1, h2, h3, h4, h5, h6, p, blockquote, pre,
  a, abbr, acronym, address, big, cite, code,
  del, dfn, em, img, ins, kbd, q, s, samp,
  small, strike, strong, sub, sup, tt, var,
  b, u, i, center,
  dl, dt, dd, ol, ul, li,
  fieldset, form, label, legend,
  table, caption, tbody, tfoot, thead, tr, th, td,
  article, aside, canvas, details, embed,
  figure, figcaption, footer, header, hgroup,
  menu, nav, output, ruby, section, summary,
  time, mark, audio, video {
    margin: 0;
    padding: 0;
    border: 0;
    font-size: 100%;
    vertical-align: baseline;
  }
  
  /* HTML5 display-role reset for older browsers */
  article, aside, details, figcaption, figure,
  footer, header, hgroup, menu, nav, section {
    display: block;
  }
  
  body {
    line-height: 1;
  }
  
  ol, ul {
    list-style: none;
  }
  
  blockquote, q {
    quotes: none;
  }
  
  blockquote:before, blockquote:after,
  q:before, q:after {
    content: '';
    content: none;
  }
  
  table {
    border-collapse: collapse;
    border-spacing: 0;
  }
  
  .modal-title {
    font-family: ${font.primary};
  }
`;
