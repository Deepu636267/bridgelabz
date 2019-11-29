import React, { Component } from 'react'
import { TextField, Card, Button,Link } from '@material-ui/core'
import CloseIcon from '@material-ui/icons/Close';
import Snackbar from '@material-ui/core/Snackbar'
import {withRouter} from 'react-router-dom'
import { login } from '../Service/UserService'
import PropTypes from 'prop-types';
// import CancelIcon from '@material-ui/icons/Cancel';
 class LoginComponent extends Component {
     constructor(props) {
         super(props)
     
         this.state = {
            emailId:"",
            password:"",
            snackbarOpen : false,
            snackbarMsg:''   
        }
    }
 
    snackbarOpen=()=>{
        this.setState({
            open:true
        })
    }
    snackbarClose=()=>{
        this.setState({
            snackbarOpen : false
        })
    }
    handleClose=()=>{
        this.setState({
            open : false
        })
    }
    handleEmailIDChange=(e)=>{
        console.log("emailId",e.target.value);
        this.setState({
            emailId:e.target.value
        })
    }
    handlePasswordChange=(e)=>{
        console.log("password",e.target.value);
        this.setState({
            password:e.target.value
        })
    }
    handleSubmitLogin=()=>{
        if (this.state.emailId === "") {
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "Email cann't be empty..!!"
            })
        } else if (!/[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/.test(this.state.emailId)) {
            console.log("entered", /[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$/.test(this.state.emailId));
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "Invalid Email..!"
            })
        } else if (this.state.password === "") {
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "Password cann't be empty..!!"
            })
        } else if (this.state.password.length < 6) {
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "password must be of atleast 6 characters..!!"
            })
        } else {
            console.log("Login True");
            let data = {
                'Email': this.state.emailId,
                'Password': this.state.password
            }
            console.log("data to passsing to backend--------", data);

            login(data).then((res) => {
                console.log("response after login", res);
                localStorage.setItem(this.state.emailId,res.data.result)
                // this.props.history.push('/login');
                this.props.history.push('/appbar')
                this.setState({ snackbarOpen: true, snackbarMsg: "Login done  successfully!!" })
            }).catch(err => {
                console.log("err in login component ", err);
            })
        }
    }
    handleLinkRegistration=()=>{
        this.props.history.push('/registration')
    }
    handleLinkForgotPassword=()=>{
        this.props.history.push('/forgot')
    }
    render() {
        return (
            <div className='login_Container'>
                <Card className='login_Card'>
                    <div className='login_title'>
                        <div style={{display:"flex", justifyContent:"center"}}>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>F</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>u</span>
                            <span style={{ color: 'orange', fontFamily: 'TimesNewRoman', fontSize: 25 }}>n</span>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>d</span>
                            <span style={{ color: 'green', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                        </div>
                        <div style={{display:"flex", justifyContent:"center",marginTop:17, color: 'black', fontFamily: 'TimesNewRoman', fontSize: 25 }}>Sign In</div>
                        <div style={{display:"flex", justifyContent:"center",marginTop:17, color: 'black', fontFamily: 'TimesNewRoman', fontSize: 25 }}>Continue To Fundoo</div>
                    </div>
                    <div className='login_Field'>
                        <div className='login_Email'>
                            <TextField
                                    id="emailId"
                                    value={this.state.emailId}
                                    onChange={this.handleEmailIDChange}
                                    label="EmailId"    
                                    fullWidth 
                                    required     
                            />
                        </div>
                        <div className='login_Password'>
                            <TextField
                                    id="passsword"
                                    value={this.state.password}
                                    onChange={this.handlePasswordChange}
                                    label="Password"    
                                    fullWidth 
                                    required     
                            />
                        </div>
                        <div className='login_button'>
                            <Button
                                onClick={this.handleSubmitLogin}
                            color='primary' style={{fontSize:18,fontFamily:'TimesNewRoman'}} variant="outlined">Log In</Button>
                        </div>
                        <div className='login_forget_create'>
                            <div className='login_create' >
                               <Link  onClick={this.handleLinkRegistration} color='secondary'>Don't have account CreateAccount</Link>
                            </div>
                            <div className='login_forget'>
                                <Link onClick={this.handleLinkForgotPassword} color='secondary'>Froget Password</Link>
                            </div>

                        </div>
                    </div>
                </Card>     
                <Snackbar
                    anchorOrigin={{
                        vertical: 'bottom',
                        horizontal: 'center',
                    }}
                    open={this.state.snackbarOpen}
                    autoHideDuration={4000}
                    onClose={this.snackbarClose}
                    message={<span id="message-id">{this.state.snackbarMsg}</span>}
                    action={[
                     <Button key="undo" color="secondary" size="small" >
                     <CloseIcon onClick={this.snackbarClose} />
                      </Button>
                    //   <IconButton
                    //     key="close"
                    //     aria-label="Close"
                    //     color="inherit"
                    //     onClick={this.handleClose}
                    //   >
                     
                    //   </IconButton>
                    ]}
                    /> 
                    
                       
            </div>
        );
    }
}
LoginComponent.propTypes={
    classes: PropTypes.object,
}
export default withRouter (LoginComponent)