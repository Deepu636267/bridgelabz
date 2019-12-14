import React, { Component } from 'react';
import { BrowserRouter as Router, Route } from 'react-router-dom'
import './App.css';
import Registration from './Pages/Registration';
import Login from './Pages/Login';
import ForgotPassword from './Pages/ForgotPassword'
import Reset from './Pages/Reset';
import Dashboard from './Pages/DashBoard';
import AppBar from './Pages/AppBar';
import Drwaer from './Pages/Drawer';
import ProfilePic from './Pages/ProfilePic';
import ServiceCard from './Pages/ServiceCard';
import CreateNote from './Pages/CreateNote';
import GetAllNotes from './Pages/GetAllNotes';
import GetReminder from './Pages/GetReminder';
import GetArchive from './Pages/GetArchive';
import GetTrash from './Pages/GetTrash';
import LabelDisplay from './Pages/LabelDisplay'
//import { Drawer } from '@material-ui/core';
// import ForgotPassword from './Pages/ForgotPassword';
class App extends Component {
  render() {
    return (
      <div>
        <Router>
          <Route path='/registration' component={Registration}></Route>
          <Route path='/login' component={Login}></Route>
          <Route path='/dashboard' component={Dashboard}></Route>
          <Route path='/reset' component={Reset}></Route>
          <Route path ='/forgot' component ={ForgotPassword}></Route>
          <Route path ='/appbar' component ={AppBar}></Route>
          <Route path='/drawer' component={Drwaer}></Route>
          <Route path='/profile' component={ProfilePic}></Route>
          <Route path='/card' component={ServiceCard}></Route>
          <Route path='/addnote' component={CreateNote}></Route>
          <Route path='/getnotes' component={GetAllNotes}></Route>
          <Route path='/getReminder' component={GetReminder}></Route>
          <Route path='/getArchive' component={GetArchive}></Route>
          <Route path='/getTrash' component={GetTrash}></Route>
          <Route path='/labelDisplay' component={LabelDisplay}></Route>
          {/* <Route path='/forgot' component={ForgotPassword}></Route> */}
        </Router>
      </div>
    )
  }
}
//import { formatMs } from '@material-ui/core/styles';

export default App;