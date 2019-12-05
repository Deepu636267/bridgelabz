import React, { Component } from 'react'
import Avatar from '@material-ui/core/Avatar';
import {withRouter} from 'react-router-dom'
import Popper from '@material-ui/core/Popper';
import Fade from '@material-ui/core/Fade';
import Paper from '@material-ui/core/Paper';
import {getUser } from '../Service/UserService'
import{Button} from '@material-ui/core'
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
            .then(async result=>
                {
                    console.log("result before setstate",result);

                   await this.setState({
                        user:result.data
                    })
                    console.log("==========================",this.state.user)
                   
                })
                .catch(err => {
                    console.log("Erroe occur while taking all notes", err);
                });
    }
    componentDidMount(){ 
      this.getUserData();
    }
    handleSubmitSignOut=()=>{
      localStorage.clear();
      this.props.history.push('/login')
    }
    render() {
        const { anchorEl, open, placement } = this.state;
      
        return (
            <div className="profile_Root">
                 <Popper open={open} anchorEl={anchorEl} placement={placement} transition>
              {({ TransitionProps }) => (
                <Fade {...TransitionProps} timeout={350}>
                  <Paper>
                   <div className='img_name_email'>
                       <div>
                       <Avatar alt="Remy Sharp" src={this.state.user.profilePic}  className='profile_Big_Avatar'/>
                       </div>
                       <div>
                       <div>
                          {this.state.user.firstName}{this.state.user.lastName}
                       </div>
                       <div>
                         
                               {this.state.user.email}
                        
                       </div>
                       </div>
                   </div>
                   <div>
                   <Button
                      onClick={this.handleSubmitSignOut}
                      color='primary' style={{fontSize:18,fontFamily:'TimesNewRoman'}} variant="outlined">SignOut</Button>

                   </div>
                  </Paper>
                </Fade>
              )}
            </Popper>
            <Avatar alt="Remy Sharp" src={this.state.user.profilePic} onClick={this.handleClick('bottom')}/>
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