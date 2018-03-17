import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';

interface GetInfoState {
    companyName: string;
    redirectUrl: string;
    clientId: string;
}

export class GetInfo extends React.Component<RouteComponentProps<{}>, GetInfoState> {

    constructor() {
        super();

        this.state = {
            companyName: '',
            redirectUrl: '',
            clientId: '',
        }

        this.handleInputChange = this.handleInputChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }

    handleInputChange(event: any) {
        const target = event.target;
        const value = target.type === 'checkbox' ? target.checked : target.value;
        const name = target.name;

        this.setState({
            [name]: value
        });
    }

    handleSubmit(event: any) {



        event.preventDefault();
    }

    public render() {
        return <div>
            <form id="login-form" role="form" style={{ display: 'block' }} onSubmit={this.handleSubmit}>
                <div className="form-group">
                    <input type="text" name="clientId" id="clientId" tabIndex={1} className="form-control" placeholder="Client ID" value={this.state.clientId} onChange={this.handleInputChange} />
                </div>
                <div className="form-group">
                    <div className="row">
                        <div className="col-sm-6 col-sm-offset-3">
                            <input type="submit" name="login-submit" id="login-submit" tabIndex={4} className="form-control btn btn-login" value="Get My Info" />
                        </div>
                    </div>
                </div>
                {
                    this.state.companyName != ''
                    ? <div className="alert alert-info" role="alert">
                            <strong style={{fontSize: '18'}}>Here is your info</strong>
                            <hr/>
                            <strong>Company Name:</strong> {this.state.companyName}<br />
                            <strong>Redirect Url:</strong> {this.state.redirectUrl}<br />
                            <strong>Client ID:</strong> {this.state.clientId}
                    </div>
                    :null
                }
            </form>
        </div>;
    }
}
