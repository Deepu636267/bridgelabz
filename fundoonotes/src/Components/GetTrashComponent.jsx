import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Card, Button } from "@material-ui/core";
import { InputBase, Tooltip, Chip } from "@material-ui/core";
import { GetAllNotes, DeleteAll } from "../Service/NotesServices";
import AppBarComponent from "../Components/AppBarComponent";
import RestoreComponent from "../Components/RestoreComponent";
class GetTrashComponent extends Component {
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

  handleRefreshRestore = () => {
    this.getNotes();
  };

  DeleteAllNotesFromTrash = () => {
    DeleteAll()
      .then(result => {
        console.log("deleteAll", result);
        this.getNotes();
      })
      .catch(err => {
        console.log("error deleteAll", err);
      });
  };

  render() {
    return !this.state.openNote ? (
      // get-container
      <div>
        <div>
          <AppBarComponent showProps={true}></AppBarComponent>
        </div>
        <div className="getNoteAllcard">
          {this.state.notes.map(data => {
            console.log("create note final data", data);
            return (
              <div className="get_Whole_Card">
                {data.isTrash === true ? (
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
                        <RestoreComponent
                          restoreId={data.id}
                          refreshRestore={this.handleRefreshRestore} ></RestoreComponent>
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
export default withRouter(GetTrashComponent);
