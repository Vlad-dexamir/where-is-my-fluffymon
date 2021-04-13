import React from 'react';

import {
  InputWrapper,
  InputLabel,
  InputStyle,
  InputFeedback,
  InputHelper,
} from './InputStyles';

type InputProps = {
  name: string;
  label: string;
  value?: string | number;
  placeholder?: string;
  className?: string;
  type?: string;
  disabled?: boolean;
  errorMessage?: string;
  helperMessage?: string;
  handleChange?: (event: React.ChangeEvent<HTMLInputElement>) => void;
  handleKeyDown?: (event: React.KeyboardEvent<HTMLInputElement>) => void;
};

export const Input: React.FC<InputProps> = (props: InputProps) => {
  const {
    name,
    label,
    value,
    placeholder,
    className,
    type,
    disabled = false,
    errorMessage,
    helperMessage,
    handleChange,
    handleKeyDown,
  } = props;

  const onChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    if (handleChange) {
      handleChange(e);
    }
  };

  const onKeyDown = (e: React.KeyboardEvent<HTMLInputElement>) => {
    if (handleKeyDown) {
      handleKeyDown(e);
    }
  };

  return (
    <InputWrapper className={className}>
      <InputLabel htmlFor={name} disabled={disabled}>
        {label}
      </InputLabel>
      <InputStyle
        id={name}
        type={type}
        className={errorMessage ? 'error' : ''}
        placeholder={placeholder}
        disabled={disabled}
        value={value}
        onChange={onChange}
        onKeyDown={onKeyDown}
      />

      {errorMessage && <InputFeedback>{errorMessage}</InputFeedback>}

      {helperMessage && (
        <InputHelper disabled={disabled}>{helperMessage}</InputHelper>
      )}
    </InputWrapper>
  );
};
