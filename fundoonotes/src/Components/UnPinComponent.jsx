import React, { Component } from 'react'
import {SetUnPin} from '../Service/NotesServices'
export default class UnPinComponent extends Component {
    handle=()=>{
        
            
       
        SetUnPin(this.props.propsNoteId).then((result) => {
            console.log("pin Result",result)
            this.props.refresh(true)
        }).catch((err) => {
            console.log("Pin Error",err);
            
        });
    }
    render() {
        return (
            <div>
                <div className="pinGet" aria-label="pinNotes" onClick={this.handle}>
                    <img src={require("../Assets/Unpin1.png")} style={{height:"20px",width:"20px" }} />
                </div> 
            </div>
        )
    }
}