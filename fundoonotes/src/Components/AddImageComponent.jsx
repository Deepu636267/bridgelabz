import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import ImageOutlinedIcon from "@material-ui/icons/ImageOutlined";


 class AddImageComponent extends Component {
    render() {
        return (
            <div>
                <ImageOutlinedIcon/>
            </div>
        )
    }
}
export default withRouter (AddImageComponent)
