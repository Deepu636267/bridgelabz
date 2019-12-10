import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import {InputBase,Tooltip,Chip,Button,Avatar } from '@material-ui/core'
import PersonAddIcon from "@material-ui/icons/PersonAdd";
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';
import {createNotes,removeCollaborators} from '../Service/CollaboratorServices';
import CloseIcon from '@material-ui/icons/Close';
function Transition(props) {
    return <Slide direction="up" {...props} />;
}
 class CollaboratorComponent extends Component {
     constructor(props) {
         super(props)
     
         this.state = {
              openCollab:false,
               id:"",
              receiverEmail:""
         }
     }
     handleClick=()=>{
         this.setState({
             openCollab:true
         })
     }
     handleReceiverEmail=(e)=>{
         console.log("receiverEmail",e.target.value)
         this.setState({
            receiverEmail:e.target.value
         })
         console.log("recv",this.state.receiverEmail);
         
     }
     handleDeleteReminder=(collabId,notesId,recEmail)=>{
         let data={
            "NoteId":notesId,
            "Id":collabId,
            "ReciverEamil":recEmail
         }
         console.log("data",data)
         removeCollaborators(data).then((result) => {
             console.log("RemoveCollab",result)
             this.props.refresh(true)
         }).catch((err) => {
            console.log(" Collaborator not Remove",err)
         });
     }
     handleSave=()=>{
        
        let data={
            "NoteId":this.props.noteId,
            "ReciverEamil":this.state.receiverEmail

        }
        createNotes(data).then((result) => {
            console.log(" Collaborator Added",result)
            this.setState({
                openCollab:false,
              
            })
            this.props.refresh(true)
        }).catch((err) => {
            console.log(" Collaborator not Added",err)
        });
     }
     handleCancel=()=>{
         this.setState({
             openCollab:false
        })
     }
     
    render() {
        return (
            !this.state.openCollab?(
            <div>
                <PersonAddIcon onClick={this.handleClick}/>
            </div>
            ):(
               
                <Dialog
                open={this.state.openCollab}
                TransitionComponent={Transition}
                keepMounted
                onClose={this.handleClose}
                aria-labelledby="alert-dialog-slide-title"
                aria-describedby="alert-dialog-slide-description"
           
                 >
                <DialogTitle id="alert-dialog-slide-title">
                    {"Collaborators"}
                </DialogTitle>
                <DialogContent>
                <div className='collaboratorOwnerDetails'>
                       <div>
                       <Avatar alt="Remy Sharp" src={localStorage.getItem("UserProfile")}  className='profile_Big_Avatar'/>
                       </div>
                       <div>
                       <div>
                          {localStorage.getItem("UserFirstName")} {localStorage.getItem("UserLastName")} (Owner)
                       </div>
                       <div>
                         
                       {this.props.ownerEamil} 
                       </div>
                       </div>
                   </div>
                    {/* <div>
                        <div>
                        <Avatar alt="Remy Sharp" src={localStorage.getItem("UserProfile")} />
                        <div>
                            {localStorage.getItem("UserFirstName")} {localStorage.getItem("UserLastName")} (Owner)
                            </div>
                        </div>
                       {this.props.ownerEamil} 
                    </div> */}
                    {this.props.propsCollabList.map((data) =>{
                        return(
                            <div>
                                {data.reciverEamil!=null?(  
                                                     <div className="collaboratorReciverEmail">                                    
                                                     <div className="emailOrImage">
                                                         <div >
                                                         <Avatar style={{backgroundColor:"purple"}}>{data.reciverEamil.slice(0,1).toUpperCase()}</Avatar>
                                                            </div>
                                                        <div className="recevierEmail">
                                                         {data.reciverEamil}
                                                        </div>
                                                     </div>
                                                     <div>
                                                   <CloseIcon onClick={() => this.handleDeleteReminder(data.id,data.noteId,data.reciverEamil)}></CloseIcon>
                                                        
                                                     </div>
                                                     </div>
                                                           
                                                        //     <Chip
                                                        //         // icon={<FaceIcon />}
                                                        //         label={data.reciverEamil} 
                                                        //         // onClick={handleClick}
                                                        //         onDelete={() => this.handleDeleteReminder(data.id,data.noteId,data.reciverEamil)}
                                                        //         variant="outlined"
                                                        //         // deleteIcon={<CloseIcon />}
                                                        //     />
                                                        // </Tooltip>
                                                )
                                                :
                                                null
                                                }      
                       

                        </div>
                        )
                    })}
                   
                    
                    <div className="inputFieldCollaborator">
                        <InputBase
                            placeholder="Person or Email to share with"
                            multiline
                            spellCheck={true}
                            value={this.state.receiverEmail}
                            onChange={this.handleReceiverEmail} 
                            className="inputFieldCollaborator"/>
                    </div>
                
                </DialogContent>
                <DialogActions>
                <Button onClick={this.handleCancel} color="primary">Cancel</Button>
                    <Button onClick={this.handleSave} color="primary">Save</Button>
                </DialogActions>
            </Dialog>
       
            )
        )
    }
}
export default withRouter (CollaboratorComponent)
