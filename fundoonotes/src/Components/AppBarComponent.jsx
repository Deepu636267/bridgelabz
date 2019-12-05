import React, { Component } from 'react';
import {AppBar,Toolbar,IconButton,InputBase} from '@material-ui/core';
import MenuIcon from '@material-ui/icons/Menu';
import SearchIcon from '@material-ui/icons/Search';
import AccountCircle from '@material-ui/icons/AccountCircle';
import RefreshIcon from '@material-ui/icons/Refresh';
import {withRouter} from 'react-router-dom';
import SettingsIcon from '@material-ui/icons/Settings';
import ViewStreamIcon from '@material-ui/icons/ViewStream';
import DrawerComponent from '../Components/DrawerComponent';
import ProfilePicComponent from '../Components/ProfilePicComponent'; 
import GetAllNotesComponent from '../Components/GetAllNotesComponent';
import CreateNoteComponent from '../Components/CreateNoteComponent'

 class AppBarComponent extends Component
{ 
  constructor(props) {
    super(props)
  
    this.state = {
       menu  : false
    }
  }
  handleMenu = async () => {
    await this.setState({
        menu: !this.state.menu

    })
    // this.props.transition(this.state.menu);
    console.log("state ", this.state.menu);
}
  render() 
  {
    return (
    
     <div className='root'>
       <div>
      <AppBar style={{backgroundColor :"#fff",color:'inherit'}} position='static'>
        <div className="whole">
          <div className='main_menu_image_name'>
            <div className='menuButton'> 
              <IconButton className='menuButton'
                                edge="start"
                                color="inherit"
                                aria-label="open drawer"
                                onClick={this.handleMenu}
                            >

                                <MenuIcon />
                            </IconButton>             
                            <DrawerComponent menuSelect={this.state.menu}/>

            </div>
         
            <div className='menu_image' aria-label="FundooNotes">
              <img src={require('../Assets/Fundoo.png')} />  
            </div>
            <div className='title'>
              <span >FundooNotes</span>
            </div>
          </div>
        
          <div className='search'>
            <div className='searchIcon'>
              <SearchIcon className='searchIcon'/>
            </div>
            <InputBase
              placeholder="Search…"
              className='searchField'
            />
          </div>
          <div className="ref_Acc">
            <div className='refresh'>
              <RefreshIcon/>
            </div>
            <div className='setting'>
              <SettingsIcon/>
            </div>
            <div className='listView'>
              <ViewStreamIcon/>
            </div>
            <div className='sectionDesktop'>
             <ProfilePicComponent />
            </div>
          </div>
        </div>
      </AppBar>
      </div>
      <div className='CreateNoteComp_AppBar'>
        <CreateNoteComponent></CreateNoteComponent>
      </div>
      <div className="GetNotComp_Appbar">
        <GetAllNotesComponent></GetAllNotesComponent>
        </div>
         
      </div>
     
    )
  }
}
export default withRouter (AppBarComponent)