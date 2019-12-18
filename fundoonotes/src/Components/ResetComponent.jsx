import React, { Component } from 'react'
import {TextField,Button,Card, Link} from '@material-ui/core'
import CloseIcon from '@material-ui/icons/Close';
import Snackbar from '@material-ui/core/Snackbar'
import {withRouter} from 'react-router-dom' 
import { reset } from '../Service/UserService';

 class ResetComponent extends Component {
        constructor(props){
            super(props)
            this.state={
               password:"",
               confirmPassword:"", 
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

    handlePasswordChange=(e)=>{
        console.log("passowrd",e.target.value);
        this.setState({
            password:e.target.value
        })
    }

    handleConfirmPasswordChange=(e)=>{
        const confirmPassword=e.target.value
        this.setState({
            confirmPassword:confirmPassword
        })
    }

    handleSubmitReset=()=>{
        if (this.state.password === "") {
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "Password cann't be empty..!!"
            })
        } else if (this.state.password.length < 6) {
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "password must be of atleast 6 characters..!!"
            })
        }else if(this.state.password!==this.state.confirmPassword){
            this.setState({
                snackbarOpen: true,
                snackbarMsg: "password must be same characters..!!"
            })

        } 
        else {
            console.log("Reset ture");
            let data = {
                'NewPassword': this.state.password
            }
            console.log("data to passsing to backend--------", data);

            reset(data).then((res) => {
                console.log("response after reset", res);
                // this.props.history.push('/login');
                this.props.history.push('/dashboard')
                this.setState({ snackbarOpen: true, snackbarMsg: "Reset Passowrd successfully!!" })
            }).catch(err => {
                console.log("err in login component ", err);
            })
        } 
    }

    render() {
        return (
            <div className='reset_Container'>
                <Card className='reset_Card'>
                    <div className='reset_title'>
                        <div style={{display:"flex", justifyContent:"center"}}>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>F</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>u</span>
                            <span style={{ color: 'orange', fontFamily: 'TimesNewRoman', fontSize: 25 }}>n</span>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>d</span>
                            <span style={{ color: 'green', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                        </div>
                        <div style={{display:"flex", justifyContent:"center",marginTop:17, color: 'black', fontFamily: 'TimesNewRoman', fontSize: 25 }}>Reset Password</div>
                        <div style={{display:"flex", justifyContent:"center",marginTop:17, color: 'black', fontFamily: 'TimesNewRoman', fontSize: 25 }}>Enter New Password</div>
                    </div>
                    <div className='reset_Password'>
                        <TextField
                        id="password"
                        value={this.state.password}
                        onChange={this.handlePasswordChange}
                        label="NewPassword" 
                        required  
                        fullWidth />  
                    </div>
                    <div className='reset_Confirm'>                         
                        <TextField
                        id="confirmPassword"
                        value={this.state.confirmPassword}
                        onChange={this.handleConfirmPasswordChange}
                        label="ConfirmPassword"
                        fullWidth
                        required  />
                    </div>
                    <div className='reset_button'>
                        <Button
                        onClick={this.handleSubmitReset}
                        color='primary' style={{fontSize:18,fontFamily:'TimesNewRoman'}} variant="outlined">Finish</Button>
                    </div>
                    <div className='reset_back'>
                        <Link href='' color='primary'>Back</Link>
                    </div>
                </Card>  
                <Snackbar
                    anchorOrigin={{
                        vertical: 'bottom',
                        horizontal: 'center',
                    }}
                    open={this.state.snackbarOpen}
                    autoHideDuration={3000}
                    onClose={this.snackbarClose}
                    message={<span id="message-id">{this.state.snackbarMsg}</span>}
                    action={[
                        <Button key="undo" color="secondary" size="small" >
                     <CloseIcon onClick={this.snackbarClose} />
                      </Button>
                    ]} />     
             </div>
        )
    }
}
export default withRouter (ResetComponent)