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
import UndoIcon from '@material-ui/icons/Undo';
import RedoIcon from '@material-ui/icons/Redo';
import {createNotes} from '../Service/NotesServices';
import ClickAwayListener from '@material-ui/core/ClickAwayListener';
class CreateNoteComponent extends Component {
  constructor(props) {
    super(props);

    this.state = {
      title: "",
      description: "",
      open: false,
      reminder:"",
      color:"",
     
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
  handleTitle=(e)=>{
    this.setState({
      title:e.target.value
    })
  }
  handleClose=()=>{
    let data={
      "Title":this.state.title,
      'Description':this.state.description,
      "Reminder":this.state.reminder,
      "Color":this.state.color,
     
   
    }
    createNotes(data).then((result) => {
          console.log("result in create note component for add notes", result);
      
                this.setState({
                    open: false,
                    title:"",
                    description:"",
                })
               
          
        }). catch (err=> {
            console.log("Error occur during back-end hitting", err);

        })
  }
  handleClickAway = () => {
    console.log("dhfhdjshf");
    this.setState({
      open:false
    })
  };

  render() {
    return !this.state.open ? (
      // <ClickAwayListener onClickAway={handleClickAway}>
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
     
      <div className="CreatemainNotesOpen">
       <ClickAwayListener onClickAway={this.handleClickAway}>
        <Card className="CreateNotecard">
      <div className='wholedivCreateNote'>
            <div className="input_field">
           
              <div classNmae='inputBase' >
                <InputBase
                  placeholder="Title"
                  multiline
                  onChange={this.handleTitle}
                  className='title_field'
                />
              </div>
              {/* <div>
              <img src={require('../Assets/pin.svg')} />  
              </div> */}
             
              <div>
                <InputBase
                  placeholder="Take a note...."
                  multiline
                  onChange={this.handleDescription}
                  className='description_Field'
                />
              </div>
            </div>
         
              <div className='noteIcon'>
            
            <div className="createNote_Icons">
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
                  <ImageOutlinedIcon className="icon" />
                </div>
                <div>
                  <ArchiveIcon className="icon" />
                </div>
                <div>
                  <MoreVertIcon className="icon" />
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
        </ClickAwayListener>
      </div>
    
      // </ClickAwayListener>
     
    )
    
  }
}
export default withRouter(CreateNoteComponent);
