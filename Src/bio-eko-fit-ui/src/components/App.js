import React, { Component } from 'react';
import { BrowserRouter as Router } from "react-router-dom";
import NavigationBar from './NavigationBar';
import './App.css';
import { PageContent } from './PageContent';

 class App extends Component {
   render() {
     return (
       <Router>
         <div>
          <NavigationBar></NavigationBar>
          <PageContent></PageContent>
         </div>
       </Router>
     );
   }
}

export default App;
