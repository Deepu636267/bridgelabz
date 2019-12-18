import React, { Component } from "react";
import { Card } from "@material-ui/core";
import { InputBase, Tooltip, Chip, Button } from "@material-ui/core";
import {GetAllNotes,RemoveRminder,UpdateNotes,SetColor,BulkDelete,dragAndDrop} from "../Service/NotesServices";
import ReminderCompnent from "../Components/ReminderCompnent";
import ArchiveComponent from "../Components/ArchiveComponent";
import AddImageComponent from "../Components/AddImageComponent";
import ColorComponent from "../Components/ColorComponent";
import CollaboratorComponent from "../Components/CollaboratorComponent";
import MoreComponent from "../Components/MoreComponent";
import PinComponent from "../Components/PinComponent";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import { MuiThemeProvider, createMuiTheme } from "@material-ui/core";
import BulkTrashComponent from "../Components/BulkTrashComponent";
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
    },
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
function Transition(props) {
  return <Slide direction="up" {...props} />;
}
class GetAllNotesComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      notes: [],
      openNote: false,
      shiftDrawer: false,
      title: "",
      description: "",
      notesId: "",
      color: "",
      count: 0,
      borderColor: "",
      bulkTrashId: "",
      values: [],
      dragId: "",
      dropId: ""
    };
  }
  componentDidMount() {
    this.getNotes();
  }

  getNotes = () => {
    GetAllNotes().then(result => {
      console.log("data", result);
      this.setState({
        notes: result.data
      });
      console.log("after putting value", this.state.notes);
      console.log("after putting value in get", this.state.values);
    });
  };

  handleRefresh = () => {
    if (true) {
      this.getNotes();
    }
  };

  handleRefreshDelete = () => {
    if (true) {
      this.getNotes();
    }
  };

  handleDeleteReminder = id => {
    let data = {
      Id: id,
      Reminder: ""
    };

  RemoveRminder(data)
      .then(result => {
        console.log("remove reminder", result);
      })
      .catch(err => {
        console.log("Remove Reminder Error", err);
      });
  };

  handleClickOpen = data => {
    this.setState({
      openNote: true,
      notesId: data.id,
      title: data.title,
      description: data.description
    });
  };

  handleTitle = e => {
    this.setState({
      title: e.target.value
    });
  };

  handleDescription = e => {
    this.setState({
      description: e.target.value
    });
  };

  handleUpdate = dataitem => {
    let data = {
      Id: this.state.notesId,
      Title: this.state.title,
      Description: this.state.description
    };

  UpdateNotes(data)
      .then(result => {
        console.log("Update Data", result);
        this.setState({
          openNote: false
        });
        this.getNotes();
      })
      .catch(err => {
        console.log("Update Error", err);
      });
  };

  handleNoteColor = (col, notesId) => {
    let data = {
      color: col,
      Id: notesId
    };
    console.log("response coming from color componenet", data);
    this.setState({
      color: col
    });

    SetColor(data)
      .then(res => {
        console.log("Response while hettinf back-end Api", res);
        this.getNotes();
      })
      .catch(err => {
        console.log("error occur while hetting back-end", err);
      });
  };

  async handleBulkSelect(ide) {
    const { notes } = this.state;
    console.log("fdsdgf", notes[ide]);
    notes[ide].selected = !notes[ide].selected;
    if (notes[ide].selected === true) {
      await this.setStateAsync({
        count: this.state.count + 1
      });
      console.log("bulk Count", this.state.count);
    } else {
      console.log("bulk Count", this.state.count);
      await this.setStateAsync({
        count: this.state.count - 1
      });
    }
    this.setState({
      notes,
      borderColor: "black",
      bulkTrashId: ide
    });
    console.log("dsfdghf", this.state.notes);
    this.props.handleBulkButton(true);
  }

  setStateAsync(state) {
    return new Promise(resolve => {
      this.setState({ state, resolve });
    });
  }

  handleBulkCardDelete = () => {
    this.state.notes.map((note) => {
      console.log("selected", note.selected);
      if (note.selected) {
        this.state.values.push(note);
      }
      return null;
    });

  BulkDelete(this.state.values)
      .then(result => {
        this.setState({
          count: 0
        });
        this.getNotes();
      })
      .catch(err => {
        console.log("Bulk Delted error", err);
      });
  };

  handleCount = () => {
    return this.state.count;
  };

  handleCloseBulkIcon = () => {
    this.setState({
      count: 0
    });
    this.state.notes.map((note, index) => {
      if (note.selected) {
        note.selected = false;
      }
      return null;
    });
  };

  onDragStart = (e, id) => {
    this.setState({
      dragId: id
    });
  };

  onDragOver = ev => {
    ev.preventDefault();
    ev.dataTransfer.effectAllowed = "move";
  };

  onDrop = (ev, id) => {
    this.setState({
      dropId: id
    });
    console.log(this.state.dragId, this.state.dropId);
  };

  handleonDragEnd = () => {
    dragAndDrop(this.state.dragId, this.state.dropId)
      .then(result => {
        this.getNotes();
      })
      .catch(err => {
        console.log("drag and drop result error", err);
      });
  };

  render() {
    values: this.state.notes.map(data => {
      return { ...data, selected: false };
    });

    return !this.state.openNote ? 
    (
      // get-container
      <div className="getNoteAllcard">
        {this.state.notes.map((data, index) => {
          console.log("create note final data", data);
          return (
            <MuiThemeProvider theme={theme}>
              <div className="get_Whole_Card" key={data.id}>
                {data.isArchive == false &&
                data.isTrash == false &&
                data.isPin == false ? (
                  <div draggable>
                    <BulkTrashComponent handleBulkColor={() => this.handleBulkSelect(index)}/>
                    <div className="get_card_effect">
                      <Card
                        className="get_cards1"
                        style={{
                          backgroundColor: data.color,
                          borderColor: data.selected ? "red" : null,
                          border: "1px solid"
                        }}
                        onClick={this.handleGHFj}
                        draggable
                        onDragStart={e => this.onDragStart(e, data.indexValue)}
                        onDragOver={e => this.onDragOver(e)}
                        onDrop={e => this.onDrop(e, data.indexValue)}
                        onDragEnd={this.handleonDragEnd}>
                        <div
                          className="get-cardDetails"
                          onClick={() => this.handleClickOpen(data)}>
                          <div className="pinNotes">
                            <InputBase value={data.title} multiline></InputBase>
                            <PinComponent
                              propsNoteId={data.id}
                              className="PinIcon"/>
                          </div>
                          <InputBase
                            value={data.description}
                            multiline
                            className="descriptionDetails"
                            onClick={() => this.handleUpdate(data)}/>
                        </div>

                        <div>
                          {data.reminder != "" && data.reminder != null ? (
                            <Tooltip title="Reminder">
                              <Chip
                              label={data.reminder.slice(0, 21)}
                              onDelete={() =>this.handleDeleteReminder(data.id)}
                              variant="outlined"/>
                            </Tooltip>
                          ) : null}
                        </div>
                        <div className="onHoverVisible">
                          <div className="WholeGetIcon">
                            <div>
                              <ReminderCompnent
                                reminderNoteId={data.id}/>
                            </div>
                            <div>
                              <CollaboratorComponent
                                propsCollabList={data.collaborators}
                                ownerEamil={data.email}
                                noteId={data.id}
                                refresh={this.handleRefresh}/>
                            </div>
                            <div>
                              <ColorComponent
                                propsToColorPallate={this.handleNoteColor}
                                notesId={data.id} />
                            </div>
                            <div>
                              <AddImageComponent propsNoteId={data.id} />
                            </div>
                            <div>
                              <ArchiveComponent
                                archeiveId={data.id}
                                refresh={this.handleRefresh}/>
                            </div>
                            <div>
                              <MoreComponent
                                deleteNotesId={data.id}
                                notesId={data.id}
                                refreshDelete={this.handleRefreshDelete}
                                createlabelPropsToMore={this.handleRefresh}/>
                            </div>
                          </div>
                        </div>
                      </Card>
                    </div>
                  </div>
                ) : null}
              </div>
            </MuiThemeProvider>
          );
        })}
      </div>
    ) : (
      <Dialog
        open={this.state.openNote}
        TransitionComponent={Transition}
        keepMounted
        onClose={this.handleClose}
        aria-labelledby="alert-dialog-slide-title"
        aria-describedby="alert-dialog-slide-description">
        <DialogTitle id="alert-dialog-slide-title">{"Update Note"}</DialogTitle>
        <DialogContent>
          <div>
            <InputBase
              placeholder="Title"
              multiline
              spellCheck={true}
              value={this.state.title}
              onChange={this.handleTitle}/>
          </div>
          <div>
            <InputBase
              placeholder="Take a note...."
              multiline
              spellCheck={true}
              value={this.state.description}
              onChange={this.handleDescription}  />
          </div>
        </DialogContent>
        <DialogActions>
          <Button onClick={this.handleUpdate} color="primary">
            Update
          </Button>
        </DialogActions>
      </Dialog>
    );
  }
}
export default GetAllNotesComponent;
