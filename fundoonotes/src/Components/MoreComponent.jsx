import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Paper, Popper, ClickAwayListener, MenuItem } from "@material-ui/core";
import MoreVertIcon from "@material-ui/icons/MoreVertOutlined";
import LabelComponent from "../Components/LabelComponent";
import { DeleteNote } from "../Service/NotesServices";

class moreComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      open: false,
      anchorEl: null,
      trashNotesId: "",
      quesNotesId: ""
    };
  }

  handleMore = e => {
    console.log("notes id is ", this.props.notesId);
    this.setState({
      anchorEl: this.state.anchorEl ? false : e.target,
      open: true,
      trashNotesId: this.props.notesId
    });
  };

  deleteNote = () => {
    let data = {
      IsTrash: true,
      Id: this.props.deleteNotesId
    };

    DeleteNote(data)
      .then(result => {
        console.log("Delete Data", result);
        this.props.refreshDelete(true);
      })
      .catch(err => {
        console.log("Delete Error", err);
      });
  };

  handleClose = () => {
    this.setState({
      open: false
    });
  };

  handleLabelProps = isTrue => {
    this.props.createlabelPropsToMore(isTrue);
  };

  render() {
    return (
      <div>
        <ClickAwayListener onClickAway={this.handleClose}>
          <MoreVertIcon onClick={e => this.handleMore(e)} />
        </ClickAwayListener>
        <Popper
          open={this.state.anchorEl}
          anchorEl={this.state.anchorEl}
          style={{ zIndex: "9999" }}>
          <Paper className="moreOption">
            <MenuItem onClick={this.deleteNote}>Delete Note</MenuItem>
            <MenuItem>
              <LabelComponent
                notesIdToLabel={this.props.notesId}
                createlabelPropsToMore={this.handleLabelProps} />
            </MenuItem>
          </Paper>
        </Popper>
      </div>
    );
  }
}
export default withRouter(moreComponent)