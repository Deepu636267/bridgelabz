import React, { Component } from "react";
import { AppBar,IconButton, InputBase } from "@material-ui/core";
import MenuIcon from "@material-ui/icons/Menu";
import SearchIcon from "@material-ui/icons/Search";
import RefreshIcon from "@material-ui/icons/Refresh";
import { withRouter } from "react-router-dom";
import SettingsIcon from "@material-ui/icons/Settings";
import ViewStreamIcon from "@material-ui/icons/ViewStream";
import DrawerComponent from "../Components/DrawerComponent";
import ProfilePicComponent from "../Components/ProfilePicComponent";
import GetAllNotesComponent from "../Components/GetAllNotesComponent";
import CreateNoteComponent from "../Components/CreateNoteComponent";
import PinDisplayComponent from "../Components/PinDisplayComponent";
import BulkTrashAppBarComponent from "../Components/BulkTrashAppBarComponent";

class AppBarComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      menu: false,
      openAppBar: false,
      value: 0
    };
  }
  handleMenu = async () => {
    await this.setState({
      menu: !this.state.menu
    });
    // this.props.transition(this.state.menu);
    console.log("state ", this.state.menu);
  };

  handleBulkAppBarOpen = () => {
    console.log("dgfjgdsfgdsfhg")
    this.setState({
      value: this.refs.child.handleCount()
    });

    console.log("sdbfjgsdfhg", this.state.value);
    if (this.state.value > 0) {
      this.setState({
        openAppBar: true
      });
    } else {
      this.setState({
        openAppBar: false
      });
    }
  };
  handleDeleteSelectedCard = () => {
    console.log("dfjgdfjgdhfg");
    this.refs.child.handleBulkCardDelete(1);
    this.setState({
      value: 0,
      openAppBar: false
    });
  };
  handleCloseAppBar = () => {
    this.refs.child.handleCloseBulkIcon();
    this.setState({
      value: 0,
      openAppBar: false
    });
  };

  render() {
    var transitions = this.state.menu ? "transition_left" : "transition_right";
    return this.props.showProps !== true ? (
      <div className="root">
        <div>
          {!this.state.openAppBar ? (
            <div>
              <AppBar
                style={{ backgroundColor: "#fff", color: "inherit" }}
                position="fixed" >
                <div className="whole">
                  <div className="main_menu_image_name">
                    <div className="menuButton">
                      <IconButton
                        className="menuButton"
                        edge="start"
                        color="inherit"
                        aria-label="open drawer"
                        onClick={this.handleMenu} >
                        <MenuIcon />
                      </IconButton>
                      <DrawerComponent menuSelect={this.state.menu} />
                    </div>

                    <div className="menu_image" aria-label="FundooNotes">
                      <img
                        src={"https://www.gstatic.com/images/branding/product/1x/keep_48dp.png"} alt="ref" />
                    </div>
                    <div className="title">Fundoo</div>
                  </div>
                  <div className="search">
                    <div className="searchIcon">
                      <SearchIcon className="searchIcon" />
                    </div>
                    <InputBase placeholder="Search…" className="searchField" />
                  </div>
                  <div className="ref_Acc">
                    <div className="refresh">
                      <RefreshIcon />
                    </div>
                    <div className="setting">
                      <SettingsIcon />
                    </div>
                    <div className="listView">
                      <ViewStreamIcon />
                    </div>
                    <div className="sectionDesktop">
                      <ProfilePicComponent />
                    </div>
                  </div>
                </div>
              </AppBar>
            </div>
          ) : (
            <BulkTrashAppBarComponent
              CountNumber={this.state.value}
              handlePropsDelete={this.handleDeleteSelectedCard}
              handlePropsAppBarBulkClose={this.handleCloseAppBar} />
          )}
        </div>
        <div className="AppBarDiv">
          <div className={transitions}>
            <CreateNoteComponent></CreateNoteComponent>
          </div>
          <div className={transitions}>
            <PinDisplayComponent></PinDisplayComponent>
          </div>
          <div className={transitions}>
            <GetAllNotesComponent
              handleBulkButton={this.handleBulkAppBarOpen}
              ref="child"
            ></GetAllNotesComponent>
          </div>
        </div>
      </div>
    ) : (
      <div className="root">
        <div>
          <AppBar
            style={{ backgroundColor: "#fff", color: "inherit" }}
            position="fixed" >
            <div className="whole">
              <div className="main_menu_image_name">
                <div className="menuButton">
                  <IconButton
                    className="menuButton"
                    edge="start"
                    color="inherit"
                    aria-label="open drawer"
                    onClick={this.handleMenu} >
                    <MenuIcon />
                  </IconButton>
                  <DrawerComponent menuSelect={this.state.menu} />
                </div>
                <div className="menu_image" aria-label="FundooNotes">
                  <img src={require("../Assets/Fundoo.png")} alt="ref"/>
                </div>
                <div className="title">
                  <span>FundooNotes</span>
                </div>
              </div>
              <div className="search">
                <div className="searchIcon">
                  <SearchIcon className="searchIcon" />
                </div>
                <InputBase placeholder="Search…" className="searchField" />
              </div>
              <div className="ref_Acc">
                <div className="refresh">
                  <RefreshIcon />
                </div>
                <div className="setting">
                  <SettingsIcon />
                </div>
                <div className="listView">
                  <ViewStreamIcon />
                </div>
                <div className="sectionDesktop">
                  <ProfilePicComponent />
                </div>
              </div>
            </div>
          </AppBar>
        </div>
      </div>
    );
  }
}
export default withRouter(AppBarComponent);
