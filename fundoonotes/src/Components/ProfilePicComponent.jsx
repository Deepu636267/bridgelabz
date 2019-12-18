import React, { Component } from "react";
import Avatar from "@material-ui/core/Avatar";
import { withRouter } from "react-router-dom";
import Popper from "@material-ui/core/Popper";
import Fade from "@material-ui/core/Fade";
import Paper from "@material-ui/core/Paper";
import { getUser, ProfilePicUpload } from "../Service/UserService";
import { Button ,ClickAwayListener} from "@material-ui/core";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import { MuiThemeProvider, createMuiTheme } from "@material-ui/core";
const theme = createMuiTheme({
  overrides: {
    MuiDialogTitle: {
      root: {
        padding: "0px"
      }
    },
    MuiDialog: {
      paper: {
        margin: "0px",
        width: "45%"
      }
    },
    MuiList: {
      padding: {
        paddingTop: "0px",
        paddingBottom: "0px"
      }
    }
  }
});

function Transitions(props) {
  return <Slide direction="up" {...props} />;
}

export class ProfilePicComponent extends Component {
  state = {
    anchorEl: null,
    open: false,
    placement: null,
    user: [],
    openNote: false,
    imageData: ""
  };

  handleClick = placement => event => {
    const { currentTarget } = event;
    this.setState(state => ({
      anchorEl: currentTarget,
      open: state.placement !== placement || !state.open,
      placement
    }));
  };

  getUserData = () => {
    getUser()
      .then(async result => {
        console.log("result before setstate", result);

        await this.setState({
          user: result.data
        });
        console.log("==========================", this.state.user);
        localStorage.setItem("UserProfile", this.state.user.profilePic);
        localStorage.setItem("UserFirstName", this.state.user.firstName);
        localStorage.setItem("UserLastName", this.state.user.lastName);
      })
      .catch(err => {
        console.log("Erroe occur while taking all notes", err);
      });
  };

  componentDidMount() {
    this.getUserData();
  }

  handleSubmitSignOut = () => {
    localStorage.clear();
    this.props.history.push("/login");
  };

  handleOpenDialog = () => {
    this.setState({
      openNote: true
    });
  };

  handleProfile = async event => {
    console.log("Handle_Profilre_Pic", event.target.files[0]);
    this.setState({ imageData: event.target.files[0] });
  };

  handleUpload = () => {
    const formData = new FormData();
    formData.append("file", this.state.imageData);
    ProfilePicUpload(formData)
      .then(result => {
        console.log("Profile Result", result);
        this.setState({
          openNote: false
        });
        this.getUserData();
      })
      .catch(err => {
        console.log("Profile Error", err);
      });
  };

  handleClose = () => {
    this.setState({
      open: false,
    })
  }

  render() {
    const { anchorEl, open, placement } = this.state;

    return (
      <ClickAwayListener onClickAway={this.handleClose}>
      <div className="profile_Root">
        <div className="openFileView">
          <Popper
            open={open}
            anchorEl={anchorEl}
            placement={placement}
            transition >
            {({ TransitionProps }) =>
              !this.state.openNote ? (
                <Fade {...TransitionProps} timeout={350}>
                  <Paper>
                    <div className="img_name_email">
                      <div className="imgIcon">
                        <Avatar
                          alt="Remy Sharp"
                          src={this.state.user.profilePic}
                          style={{ width: "100px", height: "100px" }}
                          onClick={this.handleOpenDialog} />
                      </div>
                      <div>
                        <div className="profileName">
                          {this.state.user.firstName}
                          {this.state.user.lastName}
                        </div>
                        <div className="profileEmail">
                          {this.state.user.email}
                        </div>
                      </div>
                    </div>
                    <div className="profilePic_SignOut_Button">
                      <Button
                        style={{background: "5f5fc1",color: "red",width: "98%"}}
                        onClick={this.handleSubmitSignOut}
                        color="primary"
                        variant="outlined">
                        SignOut
                      </Button>
                    </div>
                  </Paper>
                </Fade>
              ) : (
                <MuiThemeProvider theme={theme}>
                  <Dialog
                    open={this.state.openNote}
                    TransitionComponent={Transitions}
                    keepMounted
                    onClose={this.handleClose}
                    aria-labelledby="alert-dialog-slide-title"
                    aria-describedby="alert-dialog-slide-description" >
                    <MuiThemeProvider theme={theme}>
                      <DialogTitle id="alert-dialog-slide-title">
                        {"Upload_Image"}
                      </DialogTitle>
                    </MuiThemeProvider>
                    <DialogContent>
                      <div>
                        <input
                          type="file"
                          onChange={event => this.handleProfile(event)} />
                      </div>
                    </DialogContent>
                    <DialogActions>
                      <Button onClick={this.handleUpload} color="primary">
                        Upload
                      </Button>
                    </DialogActions>
                  </Dialog>
                </MuiThemeProvider>
              )
            }
          </Popper>
         
        </div>
        <Avatar
          alt="Remy Sharp"
          src={this.state.user.profilePic}
          onClick={this.handleClick("bottom")} />
      </div>
      </ClickAwayListener>
    );
  }
}
export default withRouter(ProfilePicComponent)