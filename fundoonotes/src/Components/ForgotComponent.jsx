import React, { Component } from "react";
import { TextField, Button, Card, Link } from "@material-ui/core";
import CloseIcon from "@material-ui/icons/Close";
import Snackbar from "@material-ui/core/Snackbar";
import { withRouter } from "react-router-dom";
import { forgot } from "../Service/UserService";
class ForgotComponent extends Component {
  constructor(props) {
    super(props);
    this.state = {
      emailId: "",
      open: false,
      snackbarMsg: "",
      snackbarOpen: false
    };
  }

  snackbarOpen = () => {
    this.setState({
      open: true
    });
  };

  snackbarClose = () => {
    this.setState({
      snackbarOpen: false
    });
  };

  handleClose = () => {
    this.setState({
      open: false
    });
  };

  handleEmailIDChange = e => {
    console.log("EmailId", e.target.value);
    this.setState({
      emailId: e.target.value
    });
  };

  handleSubmitForgot = () => {
    if (this.state.emailId === "") {
      this.setState({
        snackbarOpen: true,
        snackbarMsg: "Email cann't be empty..!!"
      });
    } else if (
      !/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/.test(this.state.emailId)
    ) {
      this.setState({
        snackbarOpen: true,
        snackbarMsg: "Invalid Email..!"
      });
    } else {
      console.log("Forgot True");
      let data = {
        Email: this.state.emailId
      };
      console.log("data to passsing to backend--------", data);
      forgot(data)
        .then(res => {
          console.log("response after login", res);
          localStorage.setItem("FundooUserToken", res.data.result);
          this.props.history.push("/reset");
          this.setState({
            snackbarOpen: true,
            snackbarMsg: "Message Sent check Your Mail"
          });
        })
        .catch(err => {
          console.log("err in login component ", err);
        });
    }
  };

  render() {
    return (
      <div className="forgot_Container">
        <Card className="forgot_Card">
          <div className="forgot_title">
            <div style={{ display: "flex", justifyContent: "center" }}>
              <span style={{color: "blue",fontFamily: "TimesNewRoman",fontSize: 25}}>F</span>
              <span style={{color: "red",fontFamily: "TimesNewRoman",fontSize: 25}}>u  </span>
              <span style={{color: "orange",fontFamily: "TimesNewRoman",fontSize: 25}}>n </span>
              <span style={{color: "blue",fontFamily: "TimesNewRoman",fontSize: 25}}>d</span>
              <span style={{color: "green",fontFamily: "TimesNewRoman",fontSize: 25}}>o </span>
              <span style={{color: "red",fontFamily: "TimesNewRoman",fontSize: 25}}>o</span>
            </div>
            <div
              style={{display: "flex",
                justifyContent: "center",
                marginTop: 17,
                color: "black",
                fontFamily: "TimesNewRoman",
                fontSize: 25
              }} >
              Find Your Email
            </div>
            <div
              style={{
                display: "flex",
                justifyContent: "center",
                marginTop: 17,
                color: "black",
                fontFamily: "TimesNewRoman",
                fontSize: 25
              }} >
              Enter Your Recovery Email
            </div>
          </div>
          <div className="forgot_Field">
            <div className="forgot_Email">
              <TextField
                id="emailId"
                value={this.state.emailId}
                onChange={this.handleEmailIDChange}
                label="EmailId"
                fullWidth
                required />
            </div>
          </div>
          <div className="forgot_button">
            <Button
              onClick={this.handleSubmitForgot}
              color="primary"
              style={{ fontSize: 18, fontFamily: "TimesNewRoman" }}
              variant="outlined">
              Next
            </Button>
          </div>
          <div className="forget_back">
            <Link href="" color="primary">
              Back
            </Link>
          </div>
        </Card>
        <Snackbar
          anchorOrigin={{
            vertical: "bottom",
            horizontal: "center"
          }}
          open={this.state.snackbarOpen}
          autoHideDuration={2000}
          onClose={this.snackbarClose}
          message={<span id="message-id">{this.state.snackbarMsg}</span>}
          action={[
            <Button key="undo" color="secondary" size="small">
              <CloseIcon onClick={this.snackbarClose} />
            </Button>
          ]}
        />
      </div>
    );
  }
}
export default withRouter(ForgotComponent);
