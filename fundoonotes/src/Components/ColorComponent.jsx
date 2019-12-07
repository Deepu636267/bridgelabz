import React, { Component } from 'react'
import { IconButton, Tooltip, } from '@material-ui/core';
import { Popper, Paper, ClickAwayListener,Fade } from '@material-ui/core';
import PopupState, { bindToggle, bindPopper } from 'material-ui-popup-state';
import ColorLensIcon from '@material-ui/icons/ColorLens';
const hexdaDecimalCodeColorName = [
    { name: "Gray", color: "#808080" },
    { color: "#d7aefb" },
    { color: "#fdcfe8" },
    { color: "#e6c9a8" },
    { color: "#e8eaed" },
    { color: "#ccff90" },
    { color: "#a7ffeb" },
    { color: "#cbf0f8" },
    { color: "#aecbfa" },
    { color: "#f28b82" },
    { color: "#fbbc04" },
    { color: "#fff475" },
    { name: "Red", color: "#ef9a9a" },
{ name: "Cyan", color: "#80deea" },
{ name: "Blue", color: "#2196f3" },
{ name: "Indigo", color: "#9fa8da" },
{ name: "LightBlue", color: "#90caf9" },
{ name: "Purple", color: "#b39ddb" },
{ name: "Yellow", color: "#c5e1a5" },
{ name: "Lime", color: "#e6ee9c" },
{ name: "Pink", color: "#f48fb1" },
{ name: "gray", color: "#eeeeee" },
{ name: "Brown", color: "#bcaaa4" },
{color: "#bcdaa6"},
]
export default class ColorComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            anchorEl: null,
            open: false,
            placement: null,
         
        }
    }
  
    handleClickAwayListener = () => {
        this.setState({
            open: false
        })
    }
    handleColor = (event) => {
        try {
            this.props.propsToColorPallate(event.target.value, this.props.notesId)
        } catch (err) {
            console.log("Error occur while heatting back-end", err);
        }
    }
    handleClickAway = () => {
        this.setState({
            open: false
        })
    }
    handleToggle  = placement => event => {
        const { currentTarget } = event;
        this.setState(state => ({
          anchorEl: currentTarget,
          open: state.placement !== placement || !state.open,
          placement,
        }));
      };
    render() {
        const changeColor = hexdaDecimalCodeColorName.map((colorKey) =>
            <Tooltip  className="Color" >
                <ClickAwayListener onClickAway={this.handleClickAwayListener}>
                    <div className="Button_color">
                        <div className="button2">
                    <IconButton style={{ backgroundColor: colorKey.color, "margin": "2px" }}
                        value={colorKey.color}
                        onClick={this.handleColor}
                        className="colorpallete"
                    >
                    </IconButton>
                    </div>
                    </div>
                </ClickAwayListener>
            </Tooltip>
        );
        return (
           
            <ClickAwayListener onClickAway={this.handleClickAway}>
            <div>
                <div>                      
                <ColorLensIcon
                                    onClick={this.handleToggle('bottom')}
                                />
                     {this.state.open?(
                     <Popper open={this.state.open} anchorEl={this.state.anchorEl} placement={this.state.placement} transition>
                         {({ TransitionProps }) => (
                         <Fade {...TransitionProps} timeout={350}>
                            <Paper className='Paper_color'>
                                <div className='color_div'>
                            {changeColor}
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


