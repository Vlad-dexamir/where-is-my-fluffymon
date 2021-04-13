import styled from 'styled-components';

export const LoginFormWrapper = styled.div`
  position: absolute;
  left: 50%;
  top: 50%;
  transform: translate(-50%, -50%);
`;

export const LoginFormField = styled.div`
  padding: 8px 0;

  &:last-of-type {
    padding-bottom: 16px;
  }
`;

export const Form = styled.form`
  display: flex;
  flex-flow: column;
`;
