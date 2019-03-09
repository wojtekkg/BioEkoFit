import React from 'react';
import { Switch, Route } from "react-router-dom";

import Products from './Products';
import Meals from './Meals';
import Menus from './Menus';

const PageContent = () => 
    <Switch>
        <Route exact path="/" component={Products}/>
        <Route path="/products" component={Products}/>
        <Route path="/meals" component={Meals}/>
        <Route path="/menus" component={Menus}/>
    </Switch>

export {
    PageContent
}