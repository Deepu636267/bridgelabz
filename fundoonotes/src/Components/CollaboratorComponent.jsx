import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import PersonAddIcon from "@material-ui/icons/PersonAdd";

 class CollaboratorComponent extends Component {
    render() {
        return (
            <div>
                <PersonAddIcon/>
            </div>
        )
    }
}
export default withRouter (CollaboratorComponent)
