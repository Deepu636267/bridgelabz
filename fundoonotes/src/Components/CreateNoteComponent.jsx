import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { TextField, Card, Button, InputBase } from "@material-ui/core";
import CheckBoxOutlinedIcon from "@material-ui/icons/CheckBoxOutlined";
import EditOutlinedIcon from "@material-ui/icons/EditOutlined";
import ImageOutlinedIcon from "@material-ui/icons/ImageOutlined";
import AddAlertIcon from "@material-ui/icons/AddAlert";
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import ColorLensIcon from "@material-ui/icons/ColorLens";
import ArchiveIcon from "@material-ui/icons/Archive";
import MoreVertIcon from "@material-ui/icons/MoreVert";
class CreateNoteComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      title: "",
      description: "",
      open: false
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

  render() {
    return !this.state.open ? (
      <div className="CreatemainNotesOpen">
        <Card className="CreatecardNoteswithoutOpen">
          <div className="mainIcon">
            <InputBase
              placeholder="Take a note"
              onClick={this.handleCreateNote}
            />

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
    ) : (
      <div className="createNotesOpen">
        <Card className="CreateNotecard">
          <div>
            <div className="input_field">
              <div>
                <InputBase
                  placeholder="Title"
                  multiline
                  onChange={this.handleTitle}
                />
              </div>
              <div>
                <InputBase
                  placeholder="Take a note...."
                  multiline
                  onChange={this.handleDescription}
                />
              </div>
            </div>
            <div>
              <div>
                <div>
                  <AddAlertIcon className="icon" />
                </div>
                <div>
                  <PersonAddIcon className="icon" />
                </div>
                <div>
                  <ColorLensIcon />
                </div>
                <div>
                  <ImageIcon className="icon" />
                </div>
                <div>
                  <ArchiveIcon className="icon" />
                </div>
                <div>
                  <MoreVertIcon className="icon" />
                </div>
                <div>
                  <UndoIcon className="iconEffect" />
                </div>
                <div>
                  <RedoIcon className="icon" />
                </div>
              </div>
              <div className="closeButton">
                <Button
                  style={{ margin: "spacing.unit" }}
                  onClick={this.handleClose}
                >
                  Close
                </Button>
              </div>
            </div>
          </div>
        </Card>
      </div>
    );
  }
}
export default withRouter(CreateNoteComponent);
