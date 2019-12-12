// import React, { Component } from 'react'
// import {withRouter} from 'react-router-dom'
// import MoreVertIcon from "@material-ui/icons/MoreVert";
// import { Paper, Popper, ClickAwayListener, MenuItem,Fade,InputBase } from '@material-ui/core';
// import {DeleteNote} from '../Service/NotesServices';
// import LabelComponent from '../Components/LabelComponent'

//  class MoreComponent extends Component {
//      constructor(props) {
//     super(props)

//     this.state = {
//         anchorEl: null,
//         open: false,
//         placement: null,
       
     
//     }
// }

// // handleClickAway = () => {
// //         this.setState({
// //             open: false
// //         })
// //     }
//     handleMore  = placement => event => { 
//         const { currentTarget } = event;
//         this.setState(state => ({
//            anchorEl: currentTarget,
//           open: state.placement !== placement || !state.open,
//           placement,
//         }));
//       };
//       handleLabelProps = (isTrue) => {
//         this.props.createlabelPropsToMore(isTrue)
//     }

    
//       deleteNote=()=>{
//           let data={
//               'IsTrash':true,
//               'Id':this.props.deleteNotesId
//           }
//           DeleteNote(data).then((result) => {
//               console.log("Delete Data",result)
//               this.props.refreshDelete(true)
//           }).catch((err) => {
//               console.log("Delete Error",err)
//           });
//       }
//     render() {
//         return (
       
//             <div>
//                    <ClickAwayListener onClickAway={this.handleClickAway}>
                  
//                     <div>                   
//                     <MoreVertIcon className='getNotesIcon' onClick={this.handleMore('bottom')}/>
//                     </div>
//                     </ClickAwayListener>  
                  
//                       <div> 
//                      <Popper open={this.state.open} anchorEl={this.state.anchorEl} placement={this.state.placement} transition>
//                          {({ TransitionProps }) => (
//                          <Fade {...TransitionProps} timeout={350}>
//                             <Paper className='Paper_reminder'>
//                             <div>
//                                 <MenuItem onClick={this.deleteNote}>Delete Note</MenuItem>
//                                 <MenuItem><LabelComponent notesIdToLabel={this.props.notesId} createlabelPropsToMore={this.handleLabelProps} /></MenuItem>
//                             </div>
//                         </Paper>
//                         </Fade>
//                         )}
//                     </Popper>
               
//                  </div>
                    
//             </div>
         
//         )
//     }
// }
// export default withRouter (MoreComponent)
import React, { Component } from 'react'
import { withRouter } from "react-router-dom";
import { Paper, Popper, ClickAwayListener, MenuItem } from '@material-ui/core';
import MoreVertIcon from '@material-ui/icons/MoreVertOutlined';
// import TrashComponent from '../component/TrashComponent';
import LabelComponent from '../Components/LabelComponent';
import {DeleteNote} from '../Service/NotesServices';

class moreComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            open: false,
            anchorEl: null,
            trashNotesId: "",
            quesNotesId:"",
        }
    }
    handleMore = (e) => {
        console.log("notes id is ", this.props.notesId);

        this.setState({
            anchorEl: this.state.anchorEl ? false : e.target,
            open: true,
            trashNotesId: this.props.notesId
        });
    }

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







    handleClose = () => {
        this.setState({
            open: false
        })
    }
    handleLabelProps = (isTrue) => {
        this.props.createlabelPropsToMore(isTrue)
    }

  
    render() {
        return (
            <div>
                <ClickAwayListener onClickAway={this.handleClose}>
                    <MoreVertIcon
                        onClick={(e) => this.handleMore(e)}
                    />
                </ClickAwayListener>
                <Popper open={this.state.anchorEl} anchorEl={this.state.anchorEl} style={{ zIndex: "9999" }}>
                    <Paper className="moreOption">
                         <MenuItem onClick={this.deleteNote}>Delete Note</MenuItem>
                        <MenuItem><LabelComponent notesIdToLabel={this.props.notesId} createlabelPropsToMore={this.handleLabelProps} /></MenuItem>
                        


                    </Paper>
                </Popper>
            </div>


        )
    }
}

export default withRouter(moreComponent)
