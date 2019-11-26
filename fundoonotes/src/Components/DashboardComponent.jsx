import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
 class DashboardComponent extends Component {
    render() {
        return (
            <div>
                <h1>Welcome In DashBoard</h1>
            </div>
        )
    }
}
export default withRouter (DashboardComponent)
