import React, { Component } from 'react'
import {Card} from '@material-ui/core'
import {withRouter} from 'react-router-dom'
 class DashboardComponent extends Component {
    render() {
        return (
            <div className='dashboard_Container'>
                <Card>
                <div className='dashboard_Header'>
                    <h1>Fundoo</h1>
                </div>
                </Card>
                <Card>
                <div className='dashboard_MainContent'>
                <h1>Fundoo Content</h1> 
                </div>
                </Card>
            </div>
        )
    }
}
export default withRouter (DashboardComponent)
