import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import UnarchiveIcon from "@material-ui/icons/Unarchive";
import { Archive } from "../Service/NotesServices";

class UnArchiveComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      IsArchive: false
    };
  }

  handleUnArcheive = () => {
    let data = {
      IsArchive: false,
      Id: this.props.unarcheiveId
    };
    console.log("UnArchive", data);
    Archive(data)
      .then(result => {
        console.log("UnArchive", result);
        this.props.refreshUnArchive(true);
      })
      .catch(err => {
        console.log("error UnArchieve", err);
      });
  };

  render() {
    return (
      <div>
        <UnarchiveIcon onClick={this.handleUnArcheive} />
      </div>
    );
  }
}
export default withRouter(UnArchiveComponent);
