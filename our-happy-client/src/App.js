import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';

class App extends Component {

  uniSignBankViewUrl = "http://localhost:61665/api/BankView";

  componentDidMount() {
    fetch(this.uniSignBankViewUrl)
      .then((response) => response.json())
      .then((responseJson) => console.log(responseJson));
  }

  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <div id="uniSignRoot">
          <ul>
            <li>
              <button>SEB Login</button>
            </li>
            <li>
              <button>Swedbank Login</button>
            </li>
          </ul>
        </div>
      </div>
    );
  }
}

export default App;
