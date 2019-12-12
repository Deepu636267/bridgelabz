import React, { Component } from 'react'
import { withRouter } from 'react-router-dom'
import { Paper, Popper, ClickAwayListener, InputBase, Button, List, Checkbox ,MenuItem} from '@material-ui/core';
import {  getLabel,CreateLabel } from '../Service/LabelServices';
import DoneIcon from '@material-ui/icons/Done';
import EditOutlineIcon from '@material-ui/icons/EditOutlined';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';
function Transition(props) {
    return <Slide direction="up" {...props} />;
}
 class EditLabelComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            anchorEl: null,
            check: false,
            labelData: '',
            open: false,
            placement:null,
            allLabels: [],
            openNote:false
        }
    }
    componentDidMount() {
        this.getLabel()
    }
   
    getLabel = () => {
        getLabel().then(async (res) => {
            console.log("RES_AFTER_GET_LABEL", res);

            await this.setState({
                allLabels: res.data.result
            })
            console.log("response coming from get all labels Api", this.state.allLabels);

        }).catch((err) => {
            console.log("Error occur while heatting get Label back-end Api", err);
        })
    }
  
    handleAddLabel = ()=> {
       this.setState({
            openNote:true
       })
      };
    
    handleClose = () => {
        this.setState({
            anchorEl: false
        })
    }
    CheckedNotes = (label) => {
        this.setState({
            check: !this.state.check,
            anchorEl: false
        })
        console.log("state of check notes ", this.props.notesIdToLabel)
        var data = {
            "label": label,
            "noteId": this.props.notesIdToLabel
        }
        console.log("data in create label component", data);
        CreateLabel(data).then((res) => {
            console.log("response coming from note label back-end aApi", res);
            this.setState({
                anchorEl:false
            })
            this.props.createlabelPropsToMore(true)
        }).catch((err) => {
            console.log("Error occur while heatting note Label back-end Api ", err);
        })
    }
    handleChangeCreateLabel = async (e) => {
        console.log("even data", e.target.value);
        await this.setState({
            labelData: e.target.value
        })
    }
    handleCreateLabel=()=>{
        var data={
            "label": this.state.labelData,
            "noteId": this.props.notesIdToLabel
        }
        CreateLabel(data).then((res) => {
            console.log("response coming from note label back-end aApi", res);
            this.setState({
                anchorEl:false
            })
            this.props.createlabelPropsToMore(true)
            
        }).catch((err) => {
            console.log("Error occur while heatting note Label back-end Api ", err);
        })
    }
    handleDoneLabel=()=>{
        this.setState({
            openNote:false
        })
    }
    render() {
        var allLabelData = this.state.allLabels.map((key) => {
            return (
                <div>
                    <List>
                        <Checkbox
                            value={key.label}
                            onClick={() => this.CheckedNotes(key.label)}>
                        </Checkbox>
                        {key.label}
                    </List>
                </div>
            )
        }
        )
        return (
            !this.state.openNote ?
            (
                <div>
                    {this.state.allLabels.map((key)=>
                        <div >
                            <ul type="none"  style={{ margin: 0,padding: 0 }}>
                            
                            <li className="DrawerIcons">
                            <MenuItem style={{backgroundColor:"transparent"}}>
                            <div className="Icon">   <img src={require("../Assets/LabelIcon.svg")} /></div>
                            <div className="iconName">{key.label}</div> 
                            </MenuItem>
                            </li> 
                            </ul>  
                        </div>
                
                    )}
                  <div >
                        <ul type="none"  style={{ margin: 0,padding: 0 }}>
                           
                        <li className="DrawerIcons">
                        <MenuItem style={{backgroundColor:"transparent"}}>
                         <EditOutlineIcon className="Icon"/> <div onClick={this.handleAddLabel} className="iconName">Edit Label</div>
                         </MenuItem>
                         </li> 
                        </ul>  
                    </div>
                    </div>
                ):(
                    <Dialog
                    open={this.state.openNote}
                    TransitionComponent={Transition}
                    keepMounted
                    onClose={this.handleClose}
                    aria-labelledby="alert-dialog-slide-title"
                    aria-describedby="alert-dialog-slide-description" >
                    <DialogTitle id="alert-dialog-slide-title">
                        {"Update Note"}
                    </DialogTitle>
                    <DialogContent>
                        <div>{"Label note ?"}</div>
                        <div>
                            <InputBase
                                placeholder="Enter Label name"
                                multiline
                                spellCheck={true}
                                value={this.state.labelData}
                                onChange={this.handleChangeCreateLabel}
                            />
                            <DoneIcon />
                        </div>
                        {allLabelData}
                        </DialogContent>
                        <DialogActions>
                        <div >
                            <Button onClick={this.handleDoneLabel}><span>Done</span></Button>
                        </div>
                        </DialogActions>
                </Dialog>
                 
            
            )
        )
    }
}
export default withRouter (EditLabelComponent)