import React, { Component } from 'react'
import { withRouter } from 'react-router-dom'
import { Paper, Popper, ClickAwayListener, InputBase, Button, List, Checkbox } from '@material-ui/core';
import {  getLabel,CreateLabel } from '../Service/LabelServices';
import SearchIcon from '@material-ui/icons/SearchOutlined';
class LabelComponent extends Component {
    constructor(props) {
        super(props);
        this.state = {
            anchorEl: null,
            check: false,
            labelData: '',
            open: false,
            placement:null,
            allLabels: []
        }
    }
    componentDidMount() {
        this.getLabel()
    }
   
    getLabel = () => {
        getLabel().then(async (res) => {
            console.log("RES_AFTER_GET_LABEL", res);

            await this.setState({
                allLabels: res.data.result
            })
            console.log("response coming from get all labels Api", this.state.allLabels);

        }).catch((err) => {
            console.log("Error occur while heatting get Label back-end Api", err);
        })
    }
  
    handleAddLabel = placement => event => {
        const { currentTarget } = event;
        this.setState(state => ({
          anchorEl: currentTarget,
          open: state.placement !== placement || !state.open,
          placement,
        }));
      };
    
    handleClose = () => {
        this.setState({
            anchorEl: false
        })
    }
    CheckedNotes = (label) => {
        this.setState({
            check: !this.state.check,
            anchorEl: false
        })
        console.log("state of check notes ", this.props.notesIdToLabel)
        var data = {
            "label": label,
            "noteId": this.props.notesIdToLabel
        }
        console.log("data in create label component", data);
        CreateLabel(data).then((res) => {
            console.log("response coming from note label back-end aApi", res);
            this.setState({
                anchorEl:false
            })
            this.props.createlabelPropsToMore(true)
        }).catch((err) => {
            console.log("Error occur while heatting note Label back-end Api ", err);
        })
    }
    handleChangeCreateLabel = async (e) => {
        console.log("even data", e.target.value);
        await this.setState({
            labelData: e.target.value
        })
    }
    handleCreateLabel=()=>{
        var data={
            "label": this.state.labelData,
            "noteId": this.props.notesIdToLabel
        }
        CreateLabel(data).then((res) => {
            console.log("response coming from note label back-end aApi", res);
            this.setState({
                anchorEl:false
            })
            this.props.createlabelPropsToMore(true)
            
        }).catch((err) => {
            console.log("Error occur while heatting note Label back-end Api ", err);
        })
    }
    render() {
        var allLabelData = this.state.allLabels.map((key) => {
            return (
                <div>
                    <List>
                        <Checkbox
                            value={key.label}
                            onClick={() => this.CheckedNotes(key.label)}>
                        </Checkbox>
                        {key.label}
                    </List>
                </div>
            )
        }
        )
        return (
            <div>
                <ClickAwayListener onClickAway={this.handleClose}>
                    <div onClick={this.handleAddLabel('bottom')} className="MoreItem">Add Label</div>
                </ClickAwayListener>
                <Popper open={this.state.anchorEl} anchorEl={this.state.anchorEl} placement={this.state.placement} transition  style={{ zIndex: "9999" }}>
                    <Paper>
                        <div>{"Label note ?"}</div>
                        <div>
                            <InputBase
                                placeholder="Enter Label name"
                                multiline
                                spellCheck={true}
                                value={this.state.labelData}
                                onChange={this.handleChangeCreateLabel}
                            />
                            <SearchIcon />
                        </div>
                        {allLabelData}
                        <div >
                            <Button onClick={this.handleCreateLabel}><span>+Create :"{this.state.labelData}"</span></Button>
                        </div>
                    </Paper>
                </Popper>
            </div>
        )
    }
}
export default withRouter(LabelComponent)