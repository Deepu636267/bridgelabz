import React, { Component } from 'react'
import {withRouter} from 'react-router-dom'
import MoreVertIcon from "@material-ui/icons/MoreVert";
import { Paper, Popper, ClickAwayListener, MenuItem,Fade } from '@material-ui/core';
import {DeleteNote} from '../Service/NotesServices'
 class MoreComponent extends Component {
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
    handleMore  = placement => event => {
        const { currentTarget } = event;
        this.setState(state => ({
          anchorEl: currentTarget,
          open: state.placement !== placement || !state.open,
          placement,
        }));
      };
      deleteNote=()=>{
          let data={
              'IsTrash':true,
              'Id':this.props.deleteNotesId
          }
          DeleteNote(data).then((result) => {
              console.log("Delete Data",result)
              this.props.refreshDelete(true)
          }).catch((err) => {
              console.log("Delete Error",err)
          });
      }
    render() {
        return (
          <ClickAwayListener onClickAway={this.handleClickAway}>
            <div>
                <div>                      
                    <MoreVertIcon className='getNotesIcon' onClick={this.handleMore('bottom')}/>
                     {this.state.open?(
                     <Popper open={this.state.open} anchorEl={this.state.anchorEl} placement={this.state.placement} transition>
                         {({ TransitionProps }) => (
                         <Fade {...TransitionProps} timeout={350}>
                            <Paper className='Paper_reminder'>
                            <div>
                                <MenuItem onClick={this.deleteNote}>Delete Note</MenuItem>
                                <MenuItem onClick={this.addLabel}>Add Label</MenuItem>
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
export default withRouter (MoreComponent)
