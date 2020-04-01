import React, { Component }  from "react";
import "./App.css";
import { Route, Switch, Link} from 'react-router-dom';
import {BrowserRouter as Router} from 'react-router-dom';
import CheckIn from './Pages/CheckIn';
import Deferment from './Pages/DefermentMessage';
import Review from './Pages/Review';
import Login from './Pages/LoginTemp';

function App() {
  return (
  <div>
    whatever 
    <Router>
    <Switch>
      <Route exact path="/" component={Login} />
      <Route exact path="/checkin" component={CheckIn} />
      <Route exact path="/deferment" component={Deferment} />
      <Route  path="/review" component={Review} /> 
    </Switch>
    </Router>    
   </div> 
    
  );
}

export default App;

   {/*<div className="App"> 
     
  </div> */}