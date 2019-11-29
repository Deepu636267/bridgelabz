import React, { Component } from 'react'
import Avatar from '@material-ui/core/Avatar';
import {withRouter} from 'react-router-dom'
import Popper from '@material-ui/core/Popper';
import Fade from '@material-ui/core/Fade';
import Paper from '@material-ui/core/Paper';
import {getUser } from '../Service/UserService'
export class ProfilePicComponent extends Component {
    state = {
        anchorEl: null,
        open: false,
        placement: null,
        user: [],
              };
            
              handleClick = placement => event => {
                const { currentTarget } = event;
                this.setState(state => ({
                  anchorEl: currentTarget,
                  open: state.placement !== placement || !state.open,
                  placement,
                }));
              };
    getUserData=()=>{
        getUser()
            .then(result=>
                {
                    console.log(result);
                    this.setState({
                        user:result
                    })
                })
                .catch(err => {
                    console.log("Erroe occur while taking all notes", err);
                });
    }
    render() {
        const { anchorEl, open, placement } = this.state;
        return (
            <div>
                 <Popper open={open} anchorEl={anchorEl} placement={placement} transition>
              {({ TransitionProps }) => (
                <Fade {...TransitionProps} timeout={350}>
                  <Paper>
                   <div className='img_name_email'>
                       <div>
                       <Avatar alt="Remy Sharp" src={require('../Assets/dog.jpg')}  />
                       </div>
                       <div>
                       <div>
                          firstname
                       </div>
                       <div>
                         
                               email
                        
                       </div>
                       </div>
                   </div>
                   <div>
                       signout
                   </div>
                  </Paper>
                </Fade>
              )}
            </Popper>
            <Avatar alt="Remy Sharp" src={require('../Assets/dog.jpg')} onClick={this.handleClick('bottom')}/>
          </div>
        )
    }
}

export default withRouter (ProfilePicComponent)















// import React, { Component } from 'react'
// import {withRouter} from 'react-router-dom'
// import Popper from '@material-ui/core/Popper';
// import Typography from '@material-ui/core/Typography';
// import Button from '@material-ui/core/Button';
// import Fade from '@material-ui/core/Fade';
// import Paper from '@material-ui/core/Paper';
// import Grid from '@material-ui/core/Grid';
// import Avatar from '@material-ui/core/Avatar';
//  class ProfilePicComponent extends Component {
//     state = {
//         anchorEl: null,
//         open: false,
//         placement: null,
//       };
    
//       handleClick = placement => event => {
//         const { currentTarget } = event;
//         this.setState(state => ({
//           anchorEl: currentTarget,
//           open: state.placement !== placement || !state.open,
//           placement,
//         }));
//       };
     
//     render() {
//         const { anchorEl, open, placement } = this.state;
//         return (
//             <div >
//             <Popper open={open} anchorEl={anchorEl} placement={placement} transition>
//               {({ TransitionProps }) => (
//                 <Fade {...TransitionProps} timeout={350}>
//                   <Paper>
//                     <Typography className="root">The content of the Popper.</Typography>
//                   </Paper>
//                 </Fade>
//               )}
//             </Popper>
//             {/* <Grid item> */}
//             <div className="imageroot">
//                 {/* <Button onClick={this.handleClick('bottom')}>bottom</Button> */}
//                 <Avatar alt="Remy Sharp"src={require('../Assets/Fundoo.png')} onClick={this.handleClick('bottom')} className='bigAvatar' />
//                 </div>
//             {/* </Grid> */}
//       </div>
//         )
//     }
// }
// export default withRouter (ProfilePicComponent)