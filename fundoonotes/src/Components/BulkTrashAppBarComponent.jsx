import React, { Component } from "react";
import { AppBar} from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";
import DeleteIcon from "@material-ui/icons/Delete";
class BulkTrashAppBarComponent extends Component {
 
  handleBulkTrash = () => {
    this.props.handlePropsDelete(true);
  };

  handleBulkAppBarClose = () => {
    this.props.handlePropsAppBarBulkClose(true);
  };

  render() {
    return (
      <div>
        <div>
          <AppBar
            style={{ backgroundColor: "#fff", color: "inherit" }}
            position="fixed" >
            <div className="bulkAppWhole">
              <div className="closeIconSelected">
                <div className="closeBulk">
                  <CloseIcon onClick={this.handleBulkAppBarClose} />
                </div>
                <div className="bulkSelectedNotes">
                  {this.props.CountNumber} Selected
                </div>
              </div>
              <div>
                <DeleteIcon onClick={this.handleBulkTrash} />
              </div>
            </div>
          </AppBar>
        </div>
      </div>
    );
  }
}
export default BulkTrashAppBarComponent