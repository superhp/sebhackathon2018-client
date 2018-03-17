import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {

  appId = "our-happy-client";
  uniSignBankViewUrl = "http://localhost:61392/api/BankView/" + this.appId;
  userInfoUrl = "http://localhost:61392/api/BankView/UserInfo/";

  constructor() {
    super();
    this.state = {
      bankTemplate: "",
      greeting: null
    }
    this.fetchUserInfo = this.fetchUserInfo.bind(this);
  }

  fetchUserInfo(userToken) {
    fetch(this.userInfoUrl + userToken)
      .then((res) => res.json())
      .then((body) => this.setState({ greeting: "Hello there, " + body.fullName + "!"}));
  }

  componentDidMount() {
    const search = this.props.location.search;
    if (search) {
      const params = new URLSearchParams(search);
      const userToken = params.get('token');
      this.fetchUserInfo(userToken);
    } 
  }

  componentWillMount() {
    fetch(this.uniSignBankViewUrl)
    .then((response) => response.json())
    .then((res) => {
      this.setState({bankTemplate: res.bankViewTemplate});
    });
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo"/>
          <h1 className="App-title">Very Important Business Consumer</h1>
        </header>
        <div dangerouslySetInnerHTML={{__html: this.state.bankTemplate}}></div>
        <h5>
          {this.state.greeting}
        </h5>

      </div>
    );
  }
}

export default App;
