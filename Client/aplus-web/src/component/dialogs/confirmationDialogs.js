import React, { Component } from 'react';
import { connect } from 'react-redux';
import withStyles from '@material-ui/core/styles/withStyles';
import Container from '@material-ui/core/Container';
import Card from '@material-ui/core/Card';
import CardHeader from '@material-ui/core/CardHeader';
import Button from '@material-ui/core/Button';
import { AddCircle } from '@material-ui/icons';
import CardContent from '@material-ui/core/CardContent';
import MaterialTable from 'material-table';
import PropTypes from 'prop-types';
import { Redirect } from 'react-router';
import Typography from '@material-ui/core/Typography';
import { confirmUserEmail } from '../../redux/userActions';

const useStyles  = (theme) =>  ({
	root : {
		minWidth : 275
	},
	bullet : {
		display   : 'inline-block',
		margin    : '0 2px',
		transform : 'scale(0.8)'
	},
	title : {
		fontSize : 14
	},
	pos : {
		marginBottom : 12
	}
});

class ConfirmationDialogs extends Component{
	constructor(props)
	{
		super(props);
		this.state = {
			accountConfirmDialog  : false,
			passwordConfirmDialog : false,
			userID                : null,
			token                 : null,
			redirect              : false,
			notFound              : false,
			success               : false
		}
	}

	componentDidMount()
	{
		//fetch query strings
		const qs = window.location.toString().split('?')[ 1 ];
		if(qs === undefined){
			this.setState({
				redirect : true
			});
			return;
		}

		const parts = qs.split('&');

		if(parts === undefined){
			this.setState({
				redirect : true
			});
			return;
		}

		//for account verification
		const userID = parts[ 0 ] ? parts[ 0 ].split('=')[ 0 ] === 'userId' ? parts[ 0 ].split('=')[ 1 ] : null : null;
		const token = parts[ 1 ] ? parts[ 1 ].split('=')[ 0 ] === 'code' ? parts[ 1 ].split('=')[ 1 ] : null : null;
		console.log(userID);
		console.log(token);

		if(userID !== null && token !== null){
			this.setState({
				...this.state,
				accountConfirmDialog : true,
				userID               : userID,
				token                : token
			});

			this.EmailConfirmation(userID, token);

		}else{
			this.setState({
				redirect : true
			});
		}
	}

	async EmailConfirmation(userID, token)
	{
		const result = await this.props.confirmUserEmail(userID, token);

		if(result === 4){
			this.setState({
				notFound : true,
				success  : false
			});
		}else if(result.res){
			this.setState({
				notFound : false,
				success  : true
			});
		}else {
			this.setState({
				notFound : false,
				success  : false
			});
		}
	}

	render()
	{
		const { classes  } = this.props;
		if (this.state.redirect) {
			return <Redirect push to="/login" />;
		}else if ( this.state.accountConfirmDialog ){
			return (
    <div>
        <div className={ 'top-5pres' }>
            <Container fixed>
                <Card className={ classes.root }>
                    <CardHeader
									title={ this.state.success ? 'Membership registration confirmed !' : 'Membership registration' }
									className={ 'text-center' }

								/>
                    <CardContent>
                        <Typography gutterBottom variant="h5" component="h2">
                            {this.state.success ?
											'You have successfully verified your email and completed your account set-up.'
											:
											'Seems like Your Token is not valid or has expired.'
										}
                        </Typography>
                        <Button id={ this.state.success ? 'btnLogIn' : 'btnResend' } variant="contained" color="primary">
                            { this.state.success ? 'LOG IN' : 'RE-SEND' }
                        </Button>
                    </CardContent>

                </Card>
            </Container>
        </div>
    </div>
			);
		}
		else {
			return <div></div>
		}
		
	}
}

ConfirmationDialogs.propTypes = {
	classes : PropTypes.object.isRequired
};

export default connect(null, { confirmUserEmail } )(withStyles(useStyles)(ConfirmationDialogs));
