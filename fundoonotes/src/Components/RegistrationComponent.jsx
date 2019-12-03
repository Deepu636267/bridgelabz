import React, { Component } from 'react'
import { TextField, Card, Button } from '@material-ui/core'
import CloseIcon from '@material-ui/icons/Close';
import Snackbar from '@material-ui/core/Snackbar'
import { registration } from '../Service/UserService'
import {withRouter} from 'react-router-dom';
import ServiceCardComponent from './ServiceCardComponent'
 class RegistrationComponent extends Component {
    constructor(props) {
        super(props)
        this.state = {
        open :false,
        firstName: "",
        lastName: "",
        emailId:"",
        password:"",
        confirmPassword:"",
        snackbarOpen : false,
        snackbarMsg:'',
        service:"",
       
        }
    }

    handleServiceChange=(e)=>{
        console.log("service",e.target.value)
           this.setState({
        service:e.target.value
    })
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
    handleFirstNameChange=(e)=>{
            console.log("firstName",e.target.value);
            this.setState({
               firstName:e.target.value
            })
        
        }
        
        handleLastNameChange=(e)=>{
            console.log("lastName",e.target.value);
            this.setState({
                lastName:e.target.value
            })
        }
        handleEmailIdChange=(e)=>{
            const emailId=e.target.value
            console.log("emailId",this.state.emailId);
            this.setState({
                emailId:emailId
            })
        }
        handlePasswordChange=(e)=>{
            console.log("passowrd",e.target.value);
            this.setState({
                password:e.target.value
            })
        }
        handleConfirmPasswordChange=(e)=>{
            // console.log("confirmPassword",e.target.value);
            const confirmPassword=e.target.value
            this.setState({
                confirmPassword:confirmPassword
            })
        }
        handleSubmit = () => {
            if (this.state.firstName === "") {
                this.setState({
                    snackbarOpen: true,
                    snackbarMsg: "first Name cann't be Empty..!"
                })
            }else if(!/^[A-Za-z]+$/.test(this.state.firstName)){
            this.setState({
                snackbarOpen:true,
                snackbarMsg:"first name required"
            })
            }else if (this.state.lastName === "") {
                this.setState({
                    snackbarOpen: true,
                    snackbarMsg: "Last Name cann't be Empty..!"
                })
            } else if (this.state.emailId === "") {
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
            }else if(this.state.password!==this.state.confirmPassword){
                this.setState({
                    snackbarOpen: true,
                    snackbarMsg: "password must be same characters..!!"
                })
            }
            else {
                console.log("Registration ture");
                let data = {
                    "FirstName": this.state.firstName,
                    "LastName": this.state.lastName,
                    'CardType':  this.props.location.state.card,
                    'Email': this.state.emailId,
                    'Password': this.state.password
                }
                console.log("data to passsing to backend--------", data);
    
                registration(data).then((res) => {
                    console.log("response after registation", res);
                    // this.props.history.push('/login');
                    this.props.history.push('/login')
                    this.setState({ snackbarOpen: true, snackbarMsg: "Registration done  successfully!!" })
                }).catch(err => {
                    console.log("err in login component ", err);
                })
            }
        }
    render() {
        var card="",color="",status=""
        if (this.props.location.state !== undefined) {
        card= this.props.location.state.card
        color=this.props.location.state.color
        status=this.props.location.state.status
        localStorage.setItem("ServiceCard",card)
        localStorage.setItem("ServiceCardColor",color)
        localStorage.setItem("ServiceCardStatus",status)
        }
        return (
            <div className='registrationContainer'>
                <Card className="reg_card">
                    <div className="Reg_Title">
                      <div style={{display:"flex", justifyContent:"center"}}>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>F</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>u</span>
                            <span style={{ color: 'orange', fontFamily: 'TimesNewRoman', fontSize: 25 }}>n</span>
                            <span style={{ color: 'blue', fontFamily: 'TimesNewRoman', fontSize: 25 }}>d</span>
                            <span style={{ color: 'green', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                            <span style={{ color: 'red', fontFamily: 'TimesNewRoman', fontSize: 25 }}>o</span>
                        </div>
                        <div style={{display:"flex", justifyContent:"center",marginTop:17, color: 'black', fontFamily: 'TimesNewRoman', fontSize: 25 }}>Create Your Fundoo Account</div>
                    </div>
                        <div className='registartionField'>
                            <div className="First_Last_Name_Reg">
                            <TextField
                                id="firstName"
                                value={this.state.firstName}
                                onChange={this.handleFirstNameChange}
                                label="FirstName" 
                                // color="secondary" 
                                required
                                                                             
                            />
                            <TextField
                                id="lastName"
                                value={this.state.lastName}
                                onChange={this.handleLastNameChange}
                                label="LastName" 
                                required                               
                            />
                            </div>
                            <div className='registrationEmail'>
                                <TextField
                                    id="emailId"
                                    value={this.state.emailId}
                                    onChange={this.handleEmailIdChange}
                                    label="EmailId"    
                                    fullWidth 
                                    required     
                                />
                            </div>
                             <div className='registartionPassword'>
                                <TextField
                                    id="password"
                                    value={this.state.password}
                                    onChange={this.handlePasswordChange}
                                    label="Password" 
                                    required 
                                                                                     
                                />                           
                                <TextField
                                    id="confirmPassword"
                                    value={this.state.confirmPassword}
                                    onChange={this.handleConfirmPasswordChange}
                                    label="ConfirmPassword"
                                    required
                                                                        
                                />
                                
                            </div>
                            <div className="serviceCard">
                             <ServiceCardComponent
                             cartProps={true}
                             color={color}
                             status={status}
                             card={card}
                             />
                             </div> 
                            <div className='resgistrationButton'>
                                <Button color="primary" variant="outlined" style={{fontSize:18,fontFamily:'TimesNewRoman'}} href='http://localhost:3000/login' ><b>Sign In</b></Button>
                                <Button 
                                onClick={this.handleSubmit}
                                color="secondary" variant="outlined" style={{fontSize:18,fontFamily:'TimesNewRoman'}} ><b>Sign Up</b></Button>
                            </div>
                         </div>   
                                      
                </Card> 
                <div> 
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
                    ]}
                /> 
                </div>  
            </div>
        )
    }
}
export default withRouter (RegistrationComponent)