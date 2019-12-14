import React, { Component } from 'react'
import AppBarComponent from '../Components/AppBarComponent'
import {withRouter} from 'react-router-dom'
import GetAllNotesComponent from '../Components/GetAllNotesComponent';
import CreateNoteComponent from '../Components/CreateNoteComponent'
 class DashboardComponent extends Component {
    render() {
        return (
            <div className='dashboard_Container'>
                <div>
              <AppBarComponent></AppBarComponent>
              </div>
             
            </div>
        )
    }
}
export default withRouter (DashboardComponent)
