import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import { Card } from '@material-ui/core'
import {InputBase} from '@material-ui/core'
import {GetAllNotes} from '../Service/NotesServices'
 class GetAllNotesComponent extends Component {
     constructor(props) {
         super(props)
     
         this.state = {
              notes:[],
              openNote: false
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
     
    render() {
        return (
            !this.state.openNote ?
                (
                    // get-container
                    <div className='getNoteAllcard'>
                        {this.state.notes.map((data) => {
                            console.log("create note final data", data);

                            return (
                              
                                <div className="get_Whole_Card">
                                    <div className="get_card_effect">
                                        <Card className="get_cards1">
                                            <div className="get-cardDetails"
                                                onClick={this.handleClickOpen}>
                                                <InputBase
                                                 value={data.title}
                                                    multiline  
                                                >
                                                </InputBase>
                                                <InputBase value={data.description}
                                                    multiline  
                                                >
                                                </InputBase>
                                            </div>
                                        </Card>
                                    </div>
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