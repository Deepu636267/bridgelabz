import React, { Component } from 'react'
import {AppBar,Toolbar,IconButton,InputBase} from '@material-ui/core';
import CloseIcon from '@material-ui/icons/Close';
import DeleteIcon from '@material-ui/icons/Delete';
 class BulkTrashAppBarComponent extends Component {
     handleBulkTrash=()=>{
         this.props.handlePropsDelete(true)
     }
     handleBulkAppBarClose=()=>{
         this.props.handlePropsAppBarBulkClose(true)
     }
    render() {
        return (
            <div>
               <div>
                 <AppBar
            style={{ backgroundColor: "#fff", color: "inherit" }}
            position="fixed">
                <div className="bulkAppWhole">
                    <div className="closeIconSelected">
                <div className="closeBulk">
                  <CloseIcon onClick={this.handleBulkAppBarClose}/>
                  </div>
                 
                  <div className="bulkSelectedNotes">
                      {this.props.CountNumber} Selected
                  </div>
                  </div>
                  <div>
                      <DeleteIcon onClick={this.handleBulkTrash}/>
                 
                  </div>
            </div>
              </AppBar>           
              </div> 
            </div>
        )
    }
}
export default BulkTrashAppBarComponent
{/* <div className="main_menu_image_name">
                <div className="menuButton">
                  <IconButton
                    className="menuButton"
                    edge="start"
                    color="inherit"
                    aria-label="open drawer"
                    onClick={this.handleMenu}
                  >
                    <MenuIcon />
                  </IconButton>
                  <DrawerComponent menuSelect={this.state.menu} />
                </div>

                <div className="menu_image" aria-label="FundooNotes">
                  <img src={("https://www.gstatic.com/images/branding/product/1x/keep_48dp.png")} />
                </div>
                <div className="title">
                  <span>Fundoo</span>
                </div>
              </div>

              <div className="search">
                <div className="searchIcon">
                  <SearchIcon className="searchIcon" />
                </div>
                <InputBase placeholder="Search…" className="searchField" />
              </div>
              <div className="ref_Acc">
                <div className="refresh">
                  <RefreshIcon />
                </div>
                <div className="setting">
                  <SettingsIcon />
                </div>
                <div className="listView">
                  <ViewStreamIcon />
                </div>
                <div className="sectionDesktop">
                  <ProfilePicComponent />
                </div>
              </div>
            </div>

           <div>fhdg</div> */}