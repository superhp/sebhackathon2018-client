import * as React from 'react';
import { RouteComponentProps } from 'react-router';
import { Link } from 'react-router-dom';

//company name
//redirect url

interface RegisterAppState {
    companyName: string;
    redirectUrl: string;
    clientId: string;
}

export class RegisterApp extends React.Component<RouteComponentProps<{}>, RegisterAppState> {

    constructor() {
        super();

        this.state = {
            companyName: '',
            redirectUrl: '',
            clientId: '',
        };

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

        fetch('api/registration', {
            method: 'POST',
            headers: {
                'content-type': 'application/json'
            },
            body: JSON.stringify({ companyName: this.state.companyName, redirectUrl: this.state.redirectUrl })
        })
            .then(response => response.json() as Promise<RegisterAppState>)
            .then(data => this.setState(data));


        event.preventDefault();
    }

    public render() {
        return <div>
            <form id="register-form" role="form" style={{ display: 'block' }} onSubmit={this.handleSubmit}>
                <div className="form-group">
                    <input type="text" name="companyName" id="companyName" tabIndex={1} className="form-control" placeholder="Company Name" value={this.state.companyName} onChange={this.handleInputChange} />
                </div>
                <div className="form-group">
                    <input type="text" name="redirectUrl" id="redirectUrl" tabIndex={1} className="form-control" placeholder="Redirect Url" value={this.state.redirectUrl} onChange={this.handleInputChange}/>
                </div>
                <div className="form-group">
                    <div className="row">
                        <div className="col-sm-6 col-sm-offset-3">
                            <input type="submit" name="register-submit" id="register-submit" tabIndex={4} className="form-control btn btn-register" value="Register Now" onChange={this.handleInputChange}/>
                        </div>
                    </div>
                </div>
                {
                    this.state.clientId != ''
                        ? <div className="alert alert-success" role="alert">
                            <strong>App succesfully registered!</strong> Your client ID is <strong>{this.state.clientId}</strong>
                            <hr />
                            Be sure to save this ID! If you do not remember your information use <Link to="/getInfo" className="alert-link">Get My Info</Link> function
                        </div>
                        : null
                }
            </form>
        </div>;
    }
}
