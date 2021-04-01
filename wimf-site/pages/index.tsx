import { NextPage, NextPageContext } from 'next';
import { Store } from 'redux';
import { AppState } from '../main/store/AppState';

const Index: NextPage = () => <div>Hello</div>;

Index.getInitialProps = async ({
  reduxStore,
  res,
}: NextPageContext & { reduxStore: Store<AppState> }) => {
   if(res){
     res.writeHead(301, {
       Location: 'where-is-my-fluffymon'
     });
     res.end();
   }
  return reduxStore.getState();
};
export default Index;