import { ErrorProps } from 'next/error';
import Head from 'next/head';
import React from 'react';
import styled from 'styled-components';
import Link from 'next/link';
import { color, font } from '../main/globalStyle';
import { Context } from '../main/Context';

/**
 * Renders the error page.
 * This component should be displayed when any unrecoverable error happens,
 * like page not found, API error, etc.
 */

const StyledError = styled.div`
  display: flex;
  flex-direction: column;
  align-items: flex-start;
  justify-content: center;
  min-height: 400px;
  max-width: 400px;
  margin: 0 auto;
  text-align: left;
  padding: 16px;
  h3 {
    font-family: ${font.secondary};
    font-size: 34px;
    font-weight: 700;
    letter-spacing: -0.25px;
    line-height: 37.4px;
    margin-bottom: 32px;
  }
  p {
    text-align: left;
    font-size: 16px;
    font-family: ${font.primary};
  }
  a {
    margin-top: 32px;
    text-decoration: none;
    background: ${color.dark.primary};
    color: ${color.light.primary};
    padding: 1rem 2rem;
    font-family: ${font.secondary};
  }
`;

const errorPage = (props: ErrorProps) => {
    const { statusCode } = props;

    return (
        <>
            <Head>
                <title>Error</title>
            </Head>
            <StyledError>
                <h3>
                    {statusCode === 404
                        ? 'Sorry, page not found.'
                        : 'Sorry, an unexpected error has occurred.'}
                </h3>
                <p>
                    The page you are looking for might have been removed or is temporarily
                    unavailable.
                </p>
                <Link href={`${Context.BASE_PATH}/`}>
                    <a>Go to Homepage</a>
                </Link>
            </StyledError>
        </>
    );
};

export default errorPage;
