import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Card } from "@material-ui/core";
import { InputBase, Tooltip, Chip } from "@material-ui/core";
import { GetAllNotes, UnArchive } from "../Service/NotesServices";
import ReminderCompnent from "../Components/ReminderCompnent";
import UnArchiveComponent from "../Components/UnArchiveComponent";
import AddImageComponent from "../Components/AddImageComponent";
import ColorComponent from "../Components/ColorComponent";
import CollaboratorComponent from "../Components/CollaboratorComponent";
import MoreComponent from "../Components/MoreComponent";
import CreateNoteComponent from "../Components/CreateNoteComponent";
import AppBarComponent from "../Components/AppBarComponent";

class GetArchiveComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      notes: [],
      openNote: false
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
    });
  };

  handleRefreshUnArchive = () => {
    if (true) {
      this.getNotes();
    }
  };

  render() {
    return !this.state.openNote ? (
      // get-container
      <div>
        <div>
          <AppBarComponent showProps={true}></AppBarComponent>
        </div>
        <div className="CreateNoteComp_AppBar">
          <CreateNoteComponent></CreateNoteComponent>
        </div>
        <div className="getNoteAllcard">
          {this.state.notes.map(data => {
            console.log("create note final data", data);
            return (
              <div className="get_Whole_Card">
                {data.isArchive === true && data.isTrash === false ? (
                  <div className="get_card_effect">
                    <Card className="get_cards1">
                      <div
                        className="get-cardDetails"
                        onClick={this.handleClickOpen} >
                        <InputBase value={data.title} multiline></InputBase>
                        <InputBase
                          value={data.description}
                          multiline
                          className="descriptionDetails" ></InputBase>
                      </div>
                      <div>
                        {data.reminder != null ? (
                          <Tooltip title="Reminder">
                            <Chip
                              style={{ backgroundColor: "rgba(0,0,0,0.08)" }}
                              className="chip"
                              label={data.reminder.slice(0, 21)} ></Chip>
                          </Tooltip>
                        ) : null}
                      </div>
                      <div className="WholeGetIcon">
                        <div>
                          <ReminderCompnent
                            reminderNoteId={data.id}></ReminderCompnent>
                        </div>
                        <div>
                          <CollaboratorComponent />
                        </div>
                        <div>
                          <ColorComponent />
                        </div>
                        <div></div>
                        <AddImageComponent />
                        <div>
                          <UnArchiveComponent
                            unarcheiveId={data.id}
                            refreshUnArchive={this.handleRefreshUnArchive}
                          ></UnArchiveComponent>
                          {/* <UnarchiveIcon onClick={this.handleUnArchieve} value={}></UnarchiveIcon> */}
                        </div>
                        <div>
                          <MoreComponent deleteNotesId={data.id} />
                        </div>
                      </div>
                    </Card>
                  </div>
                ) : null}
              </div>
            );
          })}
        </div>
      </div>
    ) : (
      <Card></Card>
    );
  }
}
export default withRouter(GetArchiveComponent);
