import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import {TextField, Card,Button,InputBase,Paper, Popper, MenuItem, Fade} from "@material-ui/core";
import CheckBoxOutlinedIcon from "@material-ui/icons/CheckBoxOutlined";
import EditOutlinedIcon from "@material-ui/icons/EditOutlined";
import ImageOutlinedIcon from "@material-ui/icons/ImageOutlined";
import AddAlertIcon from "@material-ui/icons/AddAlert";
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import ColorLensIcon from "@material-ui/icons/ColorLens";
import ArchiveIcon from "@material-ui/icons/Archive";
import MoreVertIcon from "@material-ui/icons/MoreVert";
import { createNotes } from "../Service/NotesServices";
import ClickAwayListener from "@material-ui/core/ClickAwayListener";
import { MuiThemeProvider, createMuiTheme } from "@material-ui/core";
var theme = createMuiTheme({
  overrides: {
    MuiPaper: {
      rounded: {
        borderRadius: "16px"
      },
      elevation1: {
        boxShadow:
          "0px 3px 14px 1px rgba(0,0,0,0.2), 0px 2px 9px 5px rgba(0,0,0,0.14), -2px -1px 9px 7px rgba(0,0,0,0.12)"
      }
    }
  }
});
class CreateNoteComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      title: "",
      description: "",
      open: false,
      reminder: "",
      color: "",
      openAlert: false,
      anchorEl: null,
      placement: null,
      date: "2019-12-24T10:30"
    };
  }

  handleDescription = e => {
    console.log("description", e.target.value);

    this.setState({
      description: e.target.value
    });
  };

  handleCreateNote = () => {
    this.setState({
      open: true
    });
  };

  handleTitle = e => {
    this.setState({
      title: e.target.value
    });
  };

  handleClose = () => {
    let data = {
      Title: this.state.title,
      Description: this.state.description,
      Reminder: this.state.reminder,
      Color: this.state.color
    };
    createNotes(data)
      .then(result => {
        console.log("result in create note component for add notes", result);

        this.setState({
          open: false,
          title: "",
          description: ""
        });
      })
      .catch(err => {
        console.log("Error occur during back-end hitting", err);
      });
  };

  handleClickAway = () => {
    console.log("dhfhdjshf");

    this.setState({
      open: false
    });
  };

  handleAlert = () => {
    console.log("reminder");
  };

  handleCustomizedDate = e => {
    console.log("data", e.target.value);
    const data = e.target.value;
    this.setState({
      date: data
    });
    console.log("data", this.state.date);
  };

  handleDFGH = placement => event => {
    const { currentTarget } = event;
    this.setState(state => ({
      anchorEl: currentTarget,
      openAlert: state.placement !== placement || !state.openAlert,
      placement
    }));
  };

  setLaterToday = () => {
    var d = new Date();
    d.setHours(20, 0, 0);
    console.log("date", d);
    this.setState({
      reminder: d.toString(),
      openAlert: false
    });
    console.log("Reminder", this.state.reminder);
  };

  setTomorrow = () => {
    var d = new Date();
    d.setDate(d.getDate() + 1);
    d.setHours(8, 0, 0);
    this.setState({
      reminder: d.toString()
    });
  };

  setNextWeek = () => {
    var d = new Date();
    d.setDate(d.getDate() + 7);
    d.setHours(8, 0, 0);
    this.setState({
      reminder: d.toString()
    });
  };

  render() {
    return !this.state.open ? (
      <MuiThemeProvider theme={theme}>
        <div className="CreatemainNotesOpen">
          <Card className="CreatecardNoteswithoutOpen">
            <div className="mainIcon">
              <InputBase
                placeholder="Take a note"
                onClick={this.handleCreateNote} />
              <div className="wholeIconwithoutOpen">
                <div className="checkboxIcon">
                  <CheckBoxOutlinedIcon />
                </div>
                <div className="editOutlinedIcon">
                  <EditOutlinedIcon />
                </div>
                <div className="imageIcon">
                  <ImageOutlinedIcon />
                </div>
              </div>
            </div>
          </Card>
        </div>
      </MuiThemeProvider>
    ) : (
      <ClickAwayListener
        onClickAway={!this.state.openAlert ? this.handleClickAway : this.handleAlert}>
        <div className="CreatemainNotesOpen">
          <Card className="CreateNotecard">
            <div className="wholedivCreateNote">
              <div className="input_field">
                <div className="inputBase">
                  <InputBase
                    placeholder="Title"
                    multiline
                    onChange={this.handleTitle}
                    className="title_field"/>
                </div>
                <div>
                  <InputBase
                    placeholder="Take a note...."
                    multiline
                    onChange={this.handleDescription}
                    className="description_Field"
                  />
                </div>
              </div>
              <div className="noteIcon">
                <div className="createNote_Icons">
                  <div>
                    <div>
                      <AddAlertIcon
                        className="getNotesIcon"
                        onClick={this.handleDFGH("bottom")} />
                      {this.state.openAlert ? (
                        <Popper
                          open={this.state.openAlert}
                          anchorEl={this.state.anchorEl}
                          placement={this.state.placement}
                          transition >
                          {({ TransitionProps }) => (
                            <Fade {...TransitionProps} timeout={350}>
                              <Paper className="Paper_reminder">
                                <div className="Remindertitle"> Reminder </div>
                                <div>
                                  <MenuItem onClick={this.setLaterToday}>
                                    <div className="setreminder_Value">
                                      LaterToday{" "}
                                    </div>
                                    <div>20:00</div>
                                  </MenuItem>
                                  <MenuItem onClick={this.setTomorrow}>
                                    <div className="setreminder_Value">
                                      Tomorrow
                                    </div>
                                    <div>08:00</div>
                                  </MenuItem>
                                  <MenuItem onClick={this.setNextWeek}>
                                    Next-Week
                                  </MenuItem>
                                  <MenuItem>
                                    <TextField
                                      id="datetime-local"
                                      label="Customized Date Time"
                                      type="datetime-local"
                                      defaultValue={this.state.date}
                                      onChange={this.handleCustomizedDate}
                                      InputLabelProps={{
                                        shrink: true
                                      }}
                                    />
                                  </MenuItem>
                                </div>
                              </Paper>
                            </Fade>
                          )}
                        </Popper>
                      ) : null}
                    </div>
                  </div>
                  <div>
                    <PersonAddIcon className="icon" />
                  </div>
                  <div>
                    <ColorLensIcon />
                  </div>
                  <div>
                    <ImageOutlinedIcon className="icon" />
                  </div>
                  <div>
                    <ArchiveIcon className="icon" />
                  </div>
                  <div>
                    <MoreVertIcon className="icon" />
                  </div>
                </div>
                <div className="closeButton">
                  <Button
                    style={{ margin: "spacing.unit" }}
                    onClick={this.handleClose} >
                    Close
                  </Button>
                </div>
              </div>
            </div>
          </Card>
        </div>
      </ClickAwayListener>
    );
  }
}
export default withRouter(CreateNoteComponent);