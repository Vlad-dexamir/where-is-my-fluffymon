import { NextPage, NextPageContext } from 'next';
import { Store } from 'redux';
import { AppState } from '../main/store/AppState';
import React from 'react';
import { LandingPage } from '../main/pages/LandingPage/LandingPage';
import { landingPageMock } from '../mockData/landingPageMock';

const Index: NextPage = () => (
  <LandingPage
    title={landingPageMock.title}
    description={landingPageMock.description}
    subtitle={landingPageMock.subtitle}
  />
);

Index.getInitialProps = async ({
  reduxStore,
}: NextPageContext & { reduxStore: Store<AppState> }) => {
  return reduxStore.getState();
};
export default Index;
