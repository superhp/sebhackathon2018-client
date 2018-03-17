import React, {Component} from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {

  appId = "our-happy-client";
  uniSignBankViewUrl = "http://localhost:61392/api/BankView/" + this.appId;

  constructor() {
    super();
    this.state = {
      bankTemplate: ""
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
        

      </div>
    );
  }
}

export default App;
