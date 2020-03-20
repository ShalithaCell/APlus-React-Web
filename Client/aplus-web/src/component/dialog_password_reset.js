import React, { Component } from 'react';
import { connect } from 'react-redux';
import Button from '@material-ui/core/Button';
import TextField from '@material-ui/core/TextField';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import { popupPasswordResetDialog } from '../redux/systemActions';

class PasswordResetDialog extends Component
{
	handleClose = () => {
		this.props.popupPasswordResetDialog(false);
	}

	render() {
		return (
    <div>

        <Dialog open={ this.props.forgotPwPop } onClose={ this.handleClose } aria-labelledby="form-dialog-title">
            <DialogTitle id="form-dialog-title">Subscribe</DialogTitle>
            <DialogContent>
                <DialogContentText>
					Please enter the email address for your account. A password reset link will be sent to you. Once you have received the password reset link.
					You will be able to choose a new password for your account.
                </DialogContentText>
                <TextField
							autoFocus
							margin="dense"
							id="name"
							label="Email Address"
							type="email"
							fullWidth
						/>
            </DialogContent>
            <DialogActions>
                <Button onClick={ this.handleClose } color="primary">
							Cancel
                </Button>
                <Button onClick={ this.handleClose } color="primary">
							Subscribe
                </Button>
            </DialogActions>
        </Dialog>
    </div>
		);
	}
}

const mapStateToProps = (state) => ({
	forgotPwPop : state.system.popupForgotpwDialog
})

export default connect(mapStateToProps, { popupPasswordResetDialog })(PasswordResetDialog);
