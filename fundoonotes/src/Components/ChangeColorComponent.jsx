import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import ColorLensIcon from "@material-ui/icons/ColorLens";

 class ChangeColorComponent extends Component {
    render() {
        return (
            <div>
                <ColorLensIcon/>
            </div>
        )
    }
}
export default withRouter (ChangeColorComponent)
