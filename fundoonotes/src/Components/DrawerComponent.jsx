import React, { Component } from 'react'
import Drawer from '@material-ui/core/Drawer'
// import { withRouter } from 'react-router-dom';
import { MenuItem, MuiThemeProvider, createMuiTheme } from '@material-ui/core';
import EmojiObjectsOutlineIcon from '@material-ui/icons/EmojiObjectsOutlined';
import AddAlertOutlineIcon from '@material-ui/icons/AddAlertOutlined';
//import LabeloutlineIcon from '@material-ui/icons/LabelOutlined';
import ArchiveOutlineIcon from '@material-ui/icons/ArchiveOutlined';
import DeleteOutlineIcon from '@material-ui/icons/DeleteOutline';
import EditOutlineIcon from '@material-ui/icons/EditOutlined';
// import { getArchiveNotes } from '../services/notesServices';
var theme = createMuiTheme({
    overrides: {
        MuiDrawer: {
            paper: {
                top: "65px",
                width: " 220px",
                height: "100vh"
            },
            paperAnchorLeft:{
                top: "68px"
            },
            paperAnchorDockedLeft: {
                borderRight:"0px"
            }
        },
       
    }
})

export class DrawerComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            open: false,
            labelArr: []
        }
    }
  
    handledrawer = () => {
        this.setState({
            open: true
        })
    }
    handleDrawerClose = () => {
        this.setState({
            open: !this.state.open
        })
    }
    handleDraweropen = () => {
        this.setState({
            open: !this.state.open
        })
    }
    
    render() {
        console.log("open ", this.state.open);
        return (
            <div>
                {/* <Button onClick={this.handleDraweropen}>Menu</Button> */}
                <MuiThemeProvider theme={theme}>
                    <div>
                        <Drawer
                            variant="persistent"
                            anchor="left"
                            open={this.props.menuSelect}
                            onClose={this.handleDrawerClose}
                            drawerwidth={5}
                        >

                            <div className="mainDrawerIcon">
                                <div >
                                    <ul type="none" style={{ borderBottom: "1px solid #ddd" ,  margin: 0,padding: 0,borderBlockStart:"1px solid #ddd" }} >
                                        <li className="DrawerIcons"> <MenuItem style={{backgroundColor:"transparent"}}><EmojiObjectsOutlineIcon  className="Icon"/><div className="iconName">Notes</div></MenuItem></li>
                                        <li className="DrawerIcons"><MenuItem style={{backgroundColor:"transparent"}}><AddAlertOutlineIcon className="Icon"/><div className="iconName">Reminder</div></MenuItem></li>
                                    </ul>

                                    <ul type="none" style={{ borderBottom: "1px solid #ddd",margin: 0,padding: 0}}>
                                        <div className="Label">LABELS</div>
                                        <li className="DrawerIcons"> <MenuItem style={{backgroundColor:"transparent"}}><EditOutlineIcon className="Icon"/><div className="iconName">Edit Label</div></MenuItem></li>
                                    </ul>
                                    <ul type="none" style={{margin: 0,padding: 0 }}>
                                    <li className="DrawerIcons"> <MenuItem style={{backgroundColor:"transparent"}}><ArchiveOutlineIcon className="Icon"/><div className="iconName">Archive</div></MenuItem></li>
                                        <li className="DrawerIcons"><MenuItem style={{backgroundColor:"transparent"}}><DeleteOutlineIcon className="Icon"/><div className="iconName">Trash</div></MenuItem></li>
                                    </ul>
                                </div>
                            </div>
                        </Drawer>

                    </div>
                </MuiThemeProvider>
            </div >
        )
    }
}

export default DrawerComponent
