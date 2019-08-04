import React, { Component } from 'react';
import logo from './logo.svg';
import './App.css';
import UserInput from './UserComps/UserInput';
import UserOutput from './UserComps/UserOutput';

class App extends Component {

  state = {
    username: 'Gil'
  }

  usernameChangedHandler = (event) => {
    this.setState({username: event.target.value});
  }


  render() {
    return (
      <div className="App">
        <header className="App-header">
          <img src={logo} className="App-logo" alt="logo" />
          <h1 className="App-title">Welcome to React</h1>
        </header>
        <UserInput
        changed={this.usernameChangedHandler}
        currentName={this.state.username} />
        <UserOutput userName={this.state.username} />
        <UserOutput userName={this.state.username} />
        <UserOutput userName="Gilgol" />
      </div>
    );
  }
}

export default App;
