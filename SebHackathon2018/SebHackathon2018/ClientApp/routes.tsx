import * as React from 'react';
import { Route } from 'react-router-dom';
import { Layout } from './components/Layout';
import { Home } from './components/Home';
import { RegisterApp } from './components/RegisterApp';
import { GetInfo } from './components/GetInfo';

export const routes = <Layout>
    <Route exact path='/' component={ Home } />
    <Route path='/register' component={RegisterApp} />
    <Route path='/getInfo' component={GetInfo} />
</Layout>;
