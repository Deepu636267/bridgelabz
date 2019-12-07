import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import { Card } from '@material-ui/core'
import {InputBase,Tooltip,Chip,Button } from '@material-ui/core'
import {GetAllNotes,RemoveRminder,UpdateNotes,SetColor} from '../Service/NotesServices'
import ReminderCompnent from '../Components/ReminderCompnent'
import ArchiveComponent from '../Components/ArchiveComponent'
import AddImageComponent from '../Components/AddImageComponent'
import ColorComponent from '../Components/ColorComponent'
import CollaboratorComponent from '../Components/CollaboratorComponent'
import MoreComponent  from '../Components/MoreComponent';
import CloseIcon from '@material-ui/icons/Close';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';
import Slide from '@material-ui/core/Slide';
function Transition(props) {
    return <Slide direction="up" {...props} />;
}
 class GetAllNotesComponent extends Component {
     constructor(props) {
         super(props)
     
         this.state = {
              notes:[],
              openNote: false,
              shiftDrawer:false,
              title:"",
              description:"",
              notesId:"",
              color:""
         }
     }
     componentDidMount() {
        this.getNotes();

    }
     getNotes=()=>
     {
         GetAllNotes().then(result=>{
             console.log("data" ,result)
             this.setState({
                 notes:result.data
             })
             console.log("after putting value",this.state.notes)
         })
     }
     handleRefreshArchive = () => {
        if (true) {
            this.getNotes()
        }
    }
    handleRefreshDelete = () => {
        if (true) {
            this.getNotes()
        }
    }
    handleDeleteReminder=(id)=>{
        let data=
        {
            'Id':id,
            'Reminder':""
        }
        RemoveRminder(data).then((result) => {
            console.log("remove reminder",result)
            
        }).catch((err) => {
            console.log("Remove Reminder Error",err)
        });   
    }
    handleClickOpen = (data) => {
        this.setState({ 
            openNote: true,
            notesId:data.id,
            title:data.title,
            description:data.description 
         });
    };
    handleTitle=(e)=>{
        this.setState({
            title:e.target.value
        })
    }
    handleDescription=(e)=>{
        this.setState({
            description:e.target.value
        })   
    }
    handleUpdate=(dataitem)=>{
        let data={
            'Id':this.state.notesId,
            'Title':this.state.title,
            'Description':this.state.description
        }
        UpdateNotes(data).then((result) => {
            console.log("Update Data",result)
            this.setState({
                openNote:false
            })
           this.getNotes();
        }).catch((err) => {
            console.log("Update Error",err)
        });
    }
    handleNoteColor = (col, notesId) => {
        let data = {
            color: col,
            Id: notesId
        }
        console.log("response coming from color componenet", data);
        this.setState({
            color: col
        })
        SetColor(data).then((res) => {
            console.log("Response while hettinf back-end Api", res);
            this.getNotes();
        }).catch((err) => {
            console.log("error occur while hetting back-end", err);
        })
    }
    //  handleDrawerOpen=()=>{
    //     this. setState({
    //          shiftDrawer : true
    //      })
    //  }
    render() {
       
   
//    !this.state.shiftDrawer?  "transition_right" : {handleDrawerOpen}
   
   
//         if(!this.state.shiftDrawer){
//             "transition_right"
//         }else if (()=>{this.handleDrawerOpen}){
//             "transition_left"
//         }
        return (
            !this.state.openNote ?
                (
                    // get-container
                    <div className="getNoteAllcard">
                        {this.state.notes.map((data) => {
                            console.log("create note final data", data);

                            return (
                                <div className="get_Whole_Card">
                                      { data.isArchive==false && data.isTrash==false? (
                                    <div className="get_card_effect">
                                        <Card className="get_cards1" style={{backgroundColor:data.color }}>
                                            <div className="get-cardDetails"
                                                 onClick={() =>this.handleClickOpen(data)}>
                                                <InputBase
                                                 value={data.title}
                                                    multiline  
                                                >
                                                </InputBase>
                                                <InputBase value={data.description}
                                                    multiline  
                                                    className='descriptionDetails'
                                                    onClick={() =>this.handleUpdate(data)}
                                                >
                                                </InputBase>
                                            </div>
                                            
                                            <div>
                                                {data.reminder!="" && data.reminder!=null?(                                      
                                                       <Tooltip title="Reminder">
                                                            {/* <Chip style={{ backgroundColor: "rgba(0,0,0,0.08)" }} className="chip"
                                                                label={data.reminder.slice(0,21)}     >
                                                                    
                                                            </Chip> */}
                                                            <Chip
                                                                // icon={<FaceIcon />}
                                                                label={data.reminder.slice(0,21)} 
                                                                // onClick={handleClick}
                                                                onDelete={() => this.handleDeleteReminder(data.id)}
                                                                variant="outlined"
                                                                // deleteIcon={<CloseIcon />}
                                                            />
                                                        </Tooltip>
                                                )
                                                :
                                                null
                                                }
                                                  
                                            </div>
                                            <div className='WholeGetIcon'>
                                            <div>
                                                <ReminderCompnent reminderNoteId={data.id} ></ReminderCompnent>
                                            </div>
                                            <div>
                                                <CollaboratorComponent/>
                                            </div>
                                            <div>
                                                <ColorComponent
                                                propsToColorPallate={this.handleNoteColor}
                                                notesId={data.id}
                                                />
                                            </div>
                                            <div>
                                            
                                                <AddImageComponent/>
                                                </div>
                                            <div>
                                            <ArchiveComponent archeiveId={data.id}
                                            refreshArchive={this.handleRefreshArchive} ></ArchiveComponent>
                                            </div>
                                            <div>
                                            <MoreComponent
                                            deleteNotesId={data.id}
                                            refreshDelete={this.handleRefreshDelete}
                                            />
                                            </div>
                                            </div>
                                        </Card>
                                    </div>
                                    ) : null}
                                </div>
                            )
                        })}
                    </div>
                )
                :
                (
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
                        <div>
                            <InputBase placeholder="Title"
                                multiline
                                spellCheck={true}
                                value={this.state.title}
                                onChange={this.handleTitle} />
                        </div>
                        <div>
                            <InputBase
                                placeholder="Take a note...."
                                multiline
                                spellCheck={true}
                                value={this.state.description}
                                onChange={this.handleDescription} />
                        </div>
                    </DialogContent>
                    <DialogActions>
                        <Button onClick={this.handleUpdate} color="primary">Update</Button>
                    </DialogActions>
                </Dialog>
                )
        )
    }
}
export default withRouter (GetAllNotesComponent)