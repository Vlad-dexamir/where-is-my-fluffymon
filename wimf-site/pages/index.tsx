import { NextPage, NextPageContext } from 'next';
import { Store } from 'redux';
import { AppState } from '../main/store/AppState';

const Index: NextPage = () => null;

Index.getInitialProps = async ({
  reduxStore,
}: NextPageContext & { reduxStore: Store<AppState> }) => {
  return reduxStore.getState();
};
export default Index;
