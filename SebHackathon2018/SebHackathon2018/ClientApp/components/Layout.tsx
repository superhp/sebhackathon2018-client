import * as React from 'react';
import { NavMenu } from './NavMenu';

export interface LayoutProps {
    children?: React.ReactNode;
}

export class Layout extends React.Component<LayoutProps, {}> {
    public render() {
        return <div className='container-fluid'>
            <div className="col-md-6 col-md-offset-3">
                <div className="panel panel-login">
                    <div className="panel-heading">
                        <NavMenu />
                        <hr />
                    </div>
                    <div className="panel-body">
                        <div className="row">
                            <div className="col-lg-12">
                                {this.props.children}
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>;
    }
}
