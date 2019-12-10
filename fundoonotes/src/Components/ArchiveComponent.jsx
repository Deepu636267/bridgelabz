import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import ArchiveIcon from "@material-ui/icons/Archive";
import {Archive} from '../Service/NotesServices'
class ArchiveComponent extends Component {
    constructor(props) {
        super(props)
    
        this.state = {
             IsArchive:false
        }
    }
    handleArcheive=()=>{
        
        let data={
            'IsArchive':true,
            'Id':this.props.archeiveId
        }
          console.log("Archive",data);
        Archive(data).then((result) => {
            console.log("Archive",result);
            this.props.refresh(true)

        }).catch((err) => {
            console.log("error Archieve", err)
        });

    }
    
    render() {
        return (
            <div>
                <ArchiveIcon onClick={this.handleArcheive}/>
            </div>
        )
    }
}
export default withRouter (ArchiveComponent)
