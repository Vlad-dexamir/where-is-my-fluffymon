import React from 'react';
import Router from 'next/router';
import App, { AppContext, AppProps } from 'next/app';
import { Store } from 'redux';
import { Provider } from 'react-redux';

import { Context } from '../main/Context';
import { HttpApiService } from '../main/services/HttpApiService';
import { AppState } from '../main/store/AppState';
import { withStore } from '../main/components/withRedux';


Context.initialize({
    apiService: new HttpApiService(),
    routerService: Router,
});

class ReduxApp extends App<AppProps & { reduxStore: Store<AppState> }> {
    static async getInitialProps({ Component, ctx }: AppContext) {
        let pageProps: any = {};

        if (Component.getInitialProps) {
            pageProps = await Component.getInitialProps(ctx);
        }

        return { pageProps };
    }

    getApplicationWithLayout() {
        const { Component, pageProps } = this.props;

        return (
            <>
               <Component {...pageProps} />
            </>
        );
    }

    render() {
        const { reduxStore } = this.props;

        return (
            <Provider store={reduxStore}>{this.getApplicationWithLayout()}</Provider>
        );
    }
}

export default withStore(ReduxApp);