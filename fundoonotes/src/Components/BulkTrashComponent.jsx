import React, { Component } from "react";
import CheckIcon from "@material-ui/icons/Check";
import Avatar from "@material-ui/core/Avatar";
export default class BulkTrashComponent extends Component {
  
    handleBulk = () => {
    this.props.handleBulkColor(true);
  };

  render() {
    return (
      <div>
        <Avatar
          alt="Remy Sharp"
          className="checkIConBulk"
          style={{ width: "30px", height: "28px" }} >
          {" "}
          <CheckIcon onClick={this.handleBulk}></CheckIcon>
        </Avatar>
      </div>
    );
  }
}
