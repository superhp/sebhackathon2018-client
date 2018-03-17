import * as React from 'react';
import { Link, NavLink } from 'react-router-dom';

export class NavMenu extends React.Component<{}, {}> {
    public render() {
        return <div className="row">
            <div className="col-xs-6">
                <NavLink to="/getInfo" activeClassName="active">Get My Info</NavLink>
            </div>
            <div className="col-xs-6">
                <NavLink to="/register" activeClassName="active">Register App</NavLink>
            </div>
        </div>;
    }
}
