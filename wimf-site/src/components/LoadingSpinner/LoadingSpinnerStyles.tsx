import styled from 'styled-components';

export const LoadingSpinnerStyles = styled.div`
  display: flex;
  align-items: center;
  justify-content: center;
  height: calc(100vh - 16px);
  width: calc(100vw - 16px);

  svg {
    &.wimf-loading {
      path {
        stroke-dasharray: 200;
        animation: dash 10s linear infinite;
      }

      @keyframes dash {
        to {
          stroke-dashoffset: 2000;
        }
      }
    }
  }
`;
