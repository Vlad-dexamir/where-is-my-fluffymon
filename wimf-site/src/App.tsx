import React from 'react';
import './App.css';
import {LandingPage} from "./pages/LandingPage/LandingPage";
import {Layout} from "./components/Layout";
import { BrowserRouter as Router, Route, Switch } from 'react-router-dom';
import {HomePage} from "./pages/Homepage/HomePage";
import {Context} from "./Context";
import {HttpApiService} from "./services/HttpApiService";
import swal from 'sweetalert2';

function App() {
   Context.initialize({
       apiService: new HttpApiService(),
       alertService: swal,
   });

  return (
      <Layout hideHeader={Context.isUserAuthorized()}>
      <Router>
              <Switch>
                  <Route exact path="/" component={LandingPage}/>
                  <Route path="/wimf/" component={HomePage} />
                  {/*<Route path="/wimf/post/:id" component={PostPage} /> */}
              </Switch>
      </Router>
      </Layout>
  );
}

export default App;
