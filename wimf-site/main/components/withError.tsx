import { AppContext } from 'next/app';
import { ErrorProps } from 'next/error';
import React from 'react';
import ErrorPage from '../../pages/_error';

/**
 * Checks if there is a 'statusCode' prop,
 * if yes, show the error page
 */
const withError = (Component: any) =>
    class WithError extends React.Component<ErrorProps> {
        static async getInitialProps(ctx: AppContext) {
            return (
                (Component.getInitialProps
                    ? await Component.getInitialProps(ctx)
                    : null) || {}
            );
        }

        render() {
            const { statusCode } = this.props;

            if (statusCode) {
                console.log('[ WithError] ', statusCode, this.props);

                return <ErrorPage statusCode={statusCode} />;
            }
            return <Component {...this.props} />;
        }
    };

export default withError;
