import React, { Component } from 'react';
import AddAlertIcon from "@material-ui/icons/AddAlert";
import {withRouter} from 'react-router-dom'
import { Paper, Popper, ClickAwayListener, MenuItem,Fade } from '@material-ui/core';
import {SetReminder} from '../Service/NotesServices'
class ReminderCompnent extends Component {
constructor(props) {
    super(props)

    this.state = {
        anchorEl: null,
        open: false,
        placement: null,
     
    }
}

handleClickAway = () => {
        this.setState({
            open: false
        })
    }
    handleReminder  = placement => event => {
        const { currentTarget } = event;
        this.setState(state => ({
          anchorEl: currentTarget,
          open: state.placement !== placement || !state.open,
          placement,
        }));
      };
      setLaterToday=()=>{
           var d = new Date();
            d.setHours(20,0,0);
          let data={
           'Reminder':d.toString(),
           'Id':this.props.reminderNoteId
          }
          SetReminder(data).then((result) => {
              console.log("reminder",result)
              
          }).catch((err) => {
              console.log("error",err)
          }); 
      }
      setTomorrow=()=>{
        var d = new Date();
        d.setDate(d.getDate() + 1);
        d.setHours(8,0,0);
        let data={
            'Reminder':d.toString(),
           'Id':this.props.reminderNoteId
        }
         SetReminder(data).then((result) => {
              console.log("reminder",result)
              
          }).catch((err) => {
              console.log("error",err)
          }); 
      }
      setNextWeek=()=>{
        var d = new Date();
        d.setDate(d.getDate() + 7);
        d.setHours(8,0,0);
         let data={
            'Reminder':d.toString(),
           'Id':this.props.reminderNoteId
        }
         SetReminder(data).then((result) => {
              console.log("reminder",result)
              
          }).catch((err) => {
              console.log("error",err)
          }); 
      }
   
    render() {
        return (
            <ClickAwayListener onClickAway={this.handleClickAway}>
            <div>
                <div>                      
                    <AddAlertIcon className='getNotesIcon' onClick={this.handleReminder('bottom')}/>
                     {this.state.open?(
                     <Popper open={this.state.open} anchorEl={this.state.anchorEl} placement={this.state.placement} transition>
                         {({ TransitionProps }) => (
                         <Fade {...TransitionProps} timeout={350}>
                            <Paper className='Paper_reminder'>
                            <div className='Remindertitle'> Reminder </div>
                            <div>
                                <MenuItem onClick={this.setLaterToday}><div className="setreminder_Value">LaterToday </div><div>20:00</div></MenuItem>
                                <MenuItem onClick={this.setTomorrow}><div className="setreminder_Value">Tomorrow</div><div>08:00</div></MenuItem>
                                <MenuItem onClick={this.setNextWeek}>Next-Week</MenuItem>
                            </div>
                        </Paper>
                        </Fade>
                        )}
                    </Popper>
                    ):null}
                     </div>
            </div>
            </ClickAwayListener>
        )
    }
}
export default withRouter (ReminderCompnent)