import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import { Card } from '@material-ui/core'
import {InputBase,Tooltip,Chip } from '@material-ui/core'
import {GetAllNotes} from '../Service/NotesServices'
import ReminderCompnent from '../Components/ReminderCompnent'
import ArchiveComponent from '../Components/ArchiveComponent'
import AddImageComponent from '../Components/AddImageComponent'
import ChangeColorComponent from '../Components/ChangeColorComponent'
import CollaboratorComponent from '../Components/CollaboratorComponent'
import MoreComponent  from '../Components/MoreComponent'
 class GetAllNotesComponent extends Component {
     constructor(props) {
         super(props)
     
         this.state = {
              notes:[],
              openNote: false,
              shiftDrawer:false
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
                                        <Card className="get_cards1" >
                                            <div className="get-cardDetails"
                                                onClick={this.handleClickOpen}>
                                                <InputBase
                                                 value={data.title}
                                                    multiline  
                                                >
                                                </InputBase>
                                                <InputBase value={data.description}
                                                    multiline  
                                                    className='descriptionDetails'
                                                >
                                                </InputBase>
                                            </div>
                                            
                                            <div>
                                                {data.reminder!=null?(                                      
                                                       <Tooltip title="Reminder">
                                                            <Chip style={{ backgroundColor: "rgba(0,0,0,0.08)" }} className="chip"
                                                                label={data.reminder.slice(0,21)} >
                                                            </Chip>
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
                                                <ChangeColorComponent/>
                                            </div>
                                            <div>
                                            </div>
                                                <AddImageComponent/>
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
                    <Card></Card>
                )
        )
    }
}
export default withRouter (GetAllNotesComponent)