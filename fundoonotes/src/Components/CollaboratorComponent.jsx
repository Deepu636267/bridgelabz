import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { InputBase, Tooltip, Chip, Button, Avatar } from "@material-ui/core";
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import {createNotes,removeCollaborators} from "../Service/CollaboratorServices";
import CloseIcon from "@material-ui/icons/Close";
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

function Transition(props) {
  return <Slide direction="up" {...props} />;
}

class CollaboratorComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      openCollab: false,
      id: "",
      receiverEmail: ""
    };
  }

  handleClick = () => {
    this.setState({
      openCollab: true
    });
  };

  handleReceiverEmail = e => {
    console.log("receiverEmail", e.target.value);
    this.setState({
      receiverEmail: e.target.value
    });
    console.log("recv", this.state.receiverEmail);
  };

  handleRemoveCollaborator = (collabId, notesId, recEmail) => {
    let data = {
      NoteId: notesId,
      Id: collabId,
      ReciverEamil: recEmail
    };
    console.log("data", data);
    removeCollaborators(data)
      .then(result => {
        console.log("RemoveCollab", result);
        this.props.refresh(true);
      })
      .catch(err => {
        console.log(" Collaborator not Remove", err);
      });
  };

  handleSave = () => {
    let data = {
      NoteId: this.props.noteId,
      ReciverEamil: this.state.receiverEmail
    };
    createNotes(data)
      .then(result => {
        console.log(" Collaborator Added", result);
        this.setState({
          openCollab: false,
          receiverEmail: ""
        });
        this.props.refresh(true);
      })
      .catch(err => {
        console.log(" Collaborator not Added", err);
      });
  };

  handleCancel = () => {
    this.setState({
      openCollab: false
    });
  };

  render() {
    return !this.state.openCollab ? (
      <div>
        <PersonAddIcon onClick={this.handleClick} />
      </div>
    ) : (
      <MuiThemeProvider theme={theme}>
        <Dialog
          open={this.state.openCollab}
          TransitionComponent={Transition}
          keepMounted
          onClose={this.handleClose}
          aria-labelledby="alert-dialog-slide-title"
          aria-describedby="alert-dialog-slide-description" >
          <MuiThemeProvider theme={theme}>
            <DialogTitle id="alert-dialog-slide-title">
              {"Collaborators"}
            </DialogTitle>
          </MuiThemeProvider>
          <DialogContent>
            <div className="collaboratorOwnerDetails">
              <div>
                <Avatar
                  alt="Remy Sharp"
                  src={localStorage.getItem("UserProfile")}
                  className="profile_Big_Avatar" />
              </div>
              <div>
                <div>
                  {localStorage.getItem("UserFirstName")}{" "}
                  {localStorage.getItem("UserLastName")} (Owner)
                </div>
                <div>{this.props.ownerEamil}</div>
              </div>
            </div>
            {this.props.propsCollabList.map(data => {
              return (
                <div>
                  {data.reciverEamil != null ? (
                    <div className="collaboratorReciverEmail">
                      <div className="emailOrImage">
                        <div>
                          <Avatar style={{ backgroundColor: "purple" }}>
                            {data.reciverEamil.slice(0, 1).toUpperCase()}
                          </Avatar>
                        </div>
                        <div className="recevierEmail">{data.reciverEamil}</div>
                      </div>
                      <div>
                        <CloseIcon
                          onClick={() =>this.handleRemoveCollaborator(data.id, data.noteId, data.reciverEamil ) } />
                      </div>
                    </div>
                  ) : null}
                </div>
              );
            })}

            <div className="inputFieldCollaborator">
              <InputBase
                placeholder="Person or Email to share with"
                multiline
                spellCheck={true}
                value={this.state.receiverEmail}
                onChange={this.handleReceiverEmail}
                className="inputFieldCollaborator" />
            </div>
          </DialogContent>
          <DialogActions style={{ backgroundColor: "#ded7d7" }}>
            <Button onClick={this.handleCancel} color="primary">
              Cancel
            </Button>
            <Button onClick={this.handleSave} color="primary">
              Save
            </Button>
          </DialogActions>
        </Dialog>
      </MuiThemeProvider>
    );
  }
}
export default withRouter(CollaboratorComponent);