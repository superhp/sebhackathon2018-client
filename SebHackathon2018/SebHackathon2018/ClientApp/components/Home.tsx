import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { NavLink, Redirect } from 'react-router-dom';
import '../css/Home.css';

export class Home extends React.Component<RouteComponentProps<{}>, {}> {

    constructor() {
        super();
    }

    public render() {
        return <div>
            <Redirect to="/register"/>
        </div>;
    }
}
