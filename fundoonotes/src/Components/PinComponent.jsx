import React, { Component } from "react";
import { SetPin } from "../Service/NotesServices";
export default class PinComponent extends Component {

  handle = () => {
    SetPin(this.props.propsNoteId)
      .then(result => {
        console.log("pin Result", result);
        this.props.refresh(true);
      })
      .catch(err => {
        console.log("Pin Error", err);
      });
  };
  
  render() {
    return (
      <div>
        <div className="pinGet" aria-label="pinNotes" onClick={this.handle}>
          <img src={require("../Assets/pin.svg")} alt="ref" />
        </div>
      </div>
    );
  }
}
