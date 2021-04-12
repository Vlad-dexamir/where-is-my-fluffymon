import React from 'react';
import App, { AppContext, AppProps } from 'next/app';
import { Store } from 'redux';
import { Provider } from 'react-redux';
import Router from 'next/router';

import { AppState } from '../main/store/AppState';
import { withStore } from '../main/components/withRedux';
import { Context } from '../main/Context';
import { HttpApiService } from '../main/services/HttpApiService';

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

  render() {
    const { reduxStore, Component, pageProps } = this.props;

    return (
      <Provider store={reduxStore}>
        <Component {...pageProps} />
      </Provider>
    );
  }
}

export default withStore(ReduxApp);
