import React, { Component } from "react";
import { withRouter } from "react-router-dom";
import ImageOutlinedIcon from "@material-ui/icons/ImageOutlined";
import Dialog from "@material-ui/core/Dialog";
import DialogActions from "@material-ui/core/DialogActions";
import DialogContent from "@material-ui/core/DialogContent";
import DialogTitle from "@material-ui/core/DialogTitle";
import Slide from "@material-ui/core/Slide";
import { MuiThemeProvider, createMuiTheme, Button } from "@material-ui/core";
import { ImageUpload } from "../Service/NotesServices";

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
    }
  }
});

function Transitions(props) {
  return <Slide direction="up" {...props} />;
}

class AddImageComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      open: false,
      imageData: ""
    };
  }

  handleAddImage = () => {
    this.setState({
      open: true
    });
  };

  handleProfile = async event => {
    console.log("Handle_Profilre_Pic", event.target.files[0]);
    this.setState({ imageData: event.target.files[0] });
  };

  handleUpload = () => {
    const formData = new FormData();
    formData.append("file", this.state.imageData);
    ImageUpload(formData, this.props.propsNoteId)
      .then(result => {
        console.log("Profile Result", result);
        this.setState({
          open: false
        });
        this.getUserData();
      })
      .catch(err => {
        console.log("Profile Error", err);
      });
  };

  render() {
    return (
      <div>
        <ImageOutlinedIcon onClick={this.handleAddImage} />
        <MuiThemeProvider theme={theme}>
          <Dialog
            open={this.state.open}
            TransitionComponent={Transitions}
            keepMounted
            onClose={this.handleClose}
            aria-labelledby="alert-dialog-slide-title"
            aria-describedby="alert-dialog-slide-description" >
            <MuiThemeProvider theme={theme}>
              <DialogTitle id="alert-dialog-slide-title">
                {"Upload_Image"}
              </DialogTitle>
            </MuiThemeProvider>
            <DialogContent>
              <div>
                <input
                  type="file"
                  onChange={event => this.handleProfile(event)} />
              </div>
            </DialogContent>
            <DialogActions>
              <Button onClick={this.handleUpload} color="primary">
                Upload
              </Button>
            </DialogActions>
          </Dialog>
        </MuiThemeProvider>
      </div>
    );
  }
}
export default withRouter(AddImageComponent);
