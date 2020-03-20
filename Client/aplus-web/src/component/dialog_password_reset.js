import React, { Component } from 'react';
import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';
import Dialog from '@material-ui/core/Dialog';
import DialogContent from '@material-ui/core/DialogContent';
import DialogTitle from '@material-ui/core/DialogTitle';

class PasswordResetDialog extends Component
{
	state = {
		open : false
	};
	openDialog() {
		this.setState({ open: true });
	}

	render() {
		return (
    <div className="App">
        <Button onClick={ this.openDialog.bind(this) }>Open dialog</Button>
        <Dialog open={ this.state.open } onEnter={ console.log('Hey.') }>
            <DialogTitle>Hello CodeSandbox</DialogTitle>
            <DialogContent>Start editing to see some magic happen!</DialogContent>
        </Dialog>
    </div>
		);
	}
}
