import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import { Input, InputBase, Button, MenuItem } from "@material-ui/core";
import {
  getLabel,
  CreateLabel,
  DeleteLabel,
  RenameLabel
} from "../Service/LabelServices";
import DoneIcon from "@material-ui/icons/Done";
import EditOutlineIcon from "@material-ui/icons/EditOutlined";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import EditIcon from "@material-ui/icons/Edit";
import LabelOutlinedIcon from "@material-ui/icons/LabelOutlined";

function Transition(props) {
  return <Slide direction="up" {...props} />;
}

class EditLabelComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      anchorEl: null,
      check: false,
      labelData: "",
      open: false,
      placement: null,
      allLabels: [],
      openNote: false,
      renamelabel: false,
      renamelabelData: "",
      labelid: ""
    };
  }

  componentDidMount() {
    this.getLabel();
  }

  getLabel = () => {
    getLabel()
      .then(async res => {
        console.log("RES_AFTER_GET_LABEL", res);

        await this.setState({
          allLabels: res.data.result
        });
        console.log(
          "response coming from get all labels Api",
          this.state.allLabels
        );
      })
      .catch(err => {
        console.log("Error occur while heatting get Label back-end Api", err);
      });
  };

  handleAddLabel = () => {
    this.setState({
      openNote: true
    });
  };

  handleClose = () => {
    this.setState({
      anchorEl: false
    });
  };

  CheckedNotes = label => {
    this.setState({
      check: !this.state.check,
      anchorEl: false
    });
    console.log("state of check notes ", this.props.notesIdToLabel);
    var data = {
      label: label,
      noteId: this.props.notesIdToLabel
    };
    console.log("data in create label component", data);
    CreateLabel(data)
      .then(res => {
        console.log("response coming from note label back-end aApi", res);
        this.setState({
          anchorEl: false
        });
        this.props.createlabelPropsToMore(true);
      })
      .catch(err => {
        console.log("Error occur while heatting note Label back-end Api ", err);
      });
  };

  handleChangeCreateLabel = async e => {
    console.log("even data", e.target.value);
    await this.setState({
      labelData: e.target.value
    });
  };

  handleCreateLabel = () => {
    var data = {
      label: this.state.labelData,
      noteId: this.props.notesIdToLabel
    };
    CreateLabel(data)
      .then(res => {
        console.log("response coming from note label back-end aApi", res);
        this.setState({
          anchorEl: false
        });
        this.props.createlabelPropsToMore(true);
      })
      .catch(err => {
        console.log("Error occur while heatting note Label back-end Api ", err);
      });
  };

  handleDoneLabel = () => {
    this.setState({
      openNote: false,
      renamelabel: false
    });
  };

  handleDeleteLabel = label => {
    DeleteLabel(label)
      .then(result => {
        console.log("LabelDeleteReulst", result);
        this.getLabel();
      })
      .catch(err => {
        console.log("label error", err);
      });
  };

  handleRenameLabelOpen = data => {
    this.setState({
      renamelabel: true,
      labelid: data
    });
    console.log("gdsfgjsdf", data);
  };

  handleRenameLabel = e => {
    this.setState({
      renamelabelData: e.target.value
    });
    console.log("labelRename", this.state.renamelabelData);
  };

  handleRenameLabelUpdate = () => {
    console.log("sdhfkhsdkjfgdf", this.state.labelid);
    RenameLabel(this.state.renamelabelData, this.state.labelid)
      .then(result => {
        console.log("Raname label Succes", result);
        this.setState({
          renamelabelData: "",
          renamelabel: false
        });
        this.getLabel();
      })
      .catch(err => {
        console.log("Rename Label Error", err);
      });
  };

  handlePushLabelPage = label => {
    this.props.history.push("/labelDisplay", label);
  };

  render() {
    var allLabelData = this.state.allLabels.map(key => {
      return (
        <div key={key.id}>
          <ul type="none" style={{ margin: 0, padding: 0 }}>
            <li
              className="labelEdit"
              style={{ margin: 0, padding: 0 }}
              key={key.id} >
              <MenuItem style={{ backgroundColor: "transparent" }}>
                <div
                  className="MenuLabelIcon"
                  onClick={() => this.handleDeleteLabel(key.label)}>
                  {" "}
                </div>
              </MenuItem>
              {!this.state.renamelabel ? (
                <MenuItem style={{ backgroundColor: "transparent" }}>
                  <MenuItem style={{ backgroundColor: "transparent" }}>
                    <div className="menuiconName">{key.label}</div>
                  </MenuItem>
                  <MenuItem style={{ backgroundColor: "transparent" }}>
                    <div className="labelEdit_Close_Icon">
                      <EditIcon
                        onClick={() => this.handleRenameLabelOpen(key.id)}
                      />
                    </div>
                  </MenuItem>
                </MenuItem>
              ) : (
                <MenuItem style={{ backgroundColor: "transparent" }}>
                  <MenuItem style={{ backgroundColor: "transparent" }}>
                    <Input
                      placeholder="LabelName"
                      multiline
                      spellCheck={true}
                      defaultValue={key.label}
                      onChange={this.handleRenameLabel} />
                  </MenuItem>
                  <MenuItem style={{ backgroundColor: "transparent" }}>
                    <DoneIcon onClick={this.handleRenameLabelUpdate} />
                  </MenuItem>
                </MenuItem>
              )}
            </li>
          </ul>
        </div>
      );
    });

    return (
      <div>
        {this.state.allLabels.map(key => (
          <div key={key.id}>
            <ul type="none" style={{ margin: 0, padding: 0 }}>
              <li className="DrawerIcons" key={key.id}>
                <MenuItem style={{ backgroundColor: "transparent" }}>
                  <LabelOutlinedIcon className="Icon" />
                  <div
                    className="iconName"
                    onClick={() => this.handlePushLabelPage(key.label)} >
                    {key.label}
                  </div>
                </MenuItem>
              </li>
            </ul>
          </div>
        ))}
        <div>
          <ul type="none" style={{ margin: 0, padding: 0 }}>
            <li className="DrawerIcons" key="1234_Icon">
              <MenuItem style={{ backgroundColor: "transparent" }}>
                <EditOutlineIcon className="Icon" />{" "}
                <div onClick={this.handleAddLabel} className="iconName">
                  Edit Label
                </div>
              </MenuItem>
            </li>
          </ul>
        </div>

        <Dialog
          open={this.state.openNote}
          TransitionComponent={Transition}
          keepMounted
          onClose={this.handleClose}
          aria-labelledby="alert-dialog-slide-title"
          aria-describedby="alert-dialog-slide-description" >
          <DialogTitle id="alert-dialog-slide-title">
            {"Edit Label"}
          </DialogTitle>
          <DialogContent>
            <div className="editLabelField">
              <MenuItem style={{ backgroundColor: "transparent" }}>
                {" "}
                <div className="labelEditCreateField"></div>
              </MenuItem>
              <MenuItem style={{ backgroundColor: "transparent" }}>
                <InputBase
                  placeholder="LabelName"
                  multiline
                  spellCheck={true}
                  value={this.state.labelData}
                  onChange={this.handleChangeCreateLabel} />
              </MenuItem>
              <MenuItem style={{ backgroundColor: "transparent" }}>
                <DoneIcon onClick={this.handleCreateLabel} />
              </MenuItem>
            </div>
            {allLabelData}
          </DialogContent>
          <DialogActions>
            <div className="ButtonEditlabel">
              <Button onClick={this.handleDoneLabel}>
                <span>Done</span>
              </Button>
            </div>
          </DialogActions>
        </Dialog>
      </div>
    );
  }
}
export default withRouter(EditLabelComponent);
