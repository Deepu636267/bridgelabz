import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import RestoreFromTrashIcon from '@material-ui/icons/RestoreFromTrash';
import DeleteForeverIcon from '@material-ui/icons/DeleteForever';
import {DeleteNote,DeleteForever,DeleteAll} from '../Service/NotesServices';
import {Button} from '@material-ui/core';
class RestoreComponent extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             IsArchive:false
        }
    }
    handleRestore=()=>{
        
        let data={
            'IsTrash':false,
            'Id':this.props.restoreId
        }
          console.log("Restore",data);
          DeleteNote(data).then((result) => {
            console.log("Restore",result);
            this.props.refreshRestore(true)

        }).catch((err) => {
            console.log("error Restore", err)
        });

    }
    handleDeleteForever=()=>{
        
        let data={
            'Id':this.props.restoreId
        }
          console.log("deleteForever",data);
          DeleteForever(data).then((result) => {
            console.log("deleteForever",result);
            this.props.refreshRestore(true)

        }).catch((err) => {
            console.log("error deleteForever", err)
        });

    }   
   
    render() {
        return (
            <div>
                
                <RestoreFromTrashIcon onClick={this.handleRestore}/>
                <DeleteForeverIcon onClick={this.handleDeleteForever}></DeleteForeverIcon>
            </div>
        )
    }
}
export default withRouter (RestoreComponent)
