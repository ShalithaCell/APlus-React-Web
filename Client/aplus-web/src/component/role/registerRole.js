import React, { Component } from 'react';
import { makeStyles } from '@material-ui/core/styles';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Stepper from '@material-ui/core/Stepper';
import Step from '@material-ui/core/Step';
import StepLabel from '@material-ui/core/StepLabel';
import Button from '@material-ui/core/Button';
import Link from '@material-ui/core/Link';
import Typography from '@material-ui/core/Typography';
import RegisterRoleDetails from './registerRoleDetails';
import PermissionLevels from './permissionLevel';
import Navbar from '../navbar';
import withStyles from '@material-ui/core/styles/withStyles';
import PropTypes from 'prop-types';
import '../../resources/styles/common.css';
import { updateRoleDetails } from '../../redux/roleActions';
import { connect } from 'react-redux';

const useStyles  = (theme) =>  ({
	appBar : {
		position : 'relative'
	},
	layout : {
		width                                                : 'auto',
		marginLeft                                           : theme.spacing(2),
		marginRight                                          : theme.spacing(2),
		[ theme.breakpoints.up(600 + theme.spacing(2) * 2) ] : {
			width       : 600,
			marginLeft  : 'auto',
			marginRight : 'auto'
		}
	},
	paper : {
		marginTop                                            : theme.spacing(3),
		marginBottom                                         : theme.spacing(3),
		padding                                              : theme.spacing(2),
		[ theme.breakpoints.up(600 + theme.spacing(3) * 2) ] : {
			marginTop    : theme.spacing(6),
			marginBottom : theme.spacing(6),
			padding      : theme.spacing(3)
		}
	},
	stepper : {
		padding : theme.spacing(3, 0, 5)
	},
	buttons : {
		display        : 'flex',
		justifyContent : 'flex-end'
	},
	button : {
		marginTop  : theme.spacing(3),
		marginLeft : theme.spacing(1)
	}
});

class RegisterRole extends Component{

	constructor(props)
	{
		super(props);
		this.state = {
			activeStep         : 0,
			roleWarning        : '',
			role               : '',
			roleDisplay        : '',
			roleDisplayWarning : '',
			test               : ''
		}
	}

	componentDidMount()
	{
		this.props.updateRoleDetails('a');
	}

	onTextChange = (e) => {

		if (e.target.id === 'role'){
			e.target.value = e.target.value.replace(/[^a-zA-Z0-9]/g, '');
			this.setState({
				role : e.target.value
			});
		}
	}

	handleNext = () =>
	{
		this.setState({
			activeStep : this.state.activeStep + 1
		})
	};

	handleBack = () =>
	{
		this.setState({
			activeStep : this.state.activeStep - 1
		})
	};

render()
{
	const { classes } = this.props;
	const steps = [ 'Role information', 'Permission' ];
	return(
    <React.Fragment>
        <CssBaseline/>
        <Navbar/>
        <main className={ classes.layout + ' top-margin' }>
            <Paper className={ classes.paper }>
                <Typography component="h1" variant="h4" align="center">
					New Role
                </Typography>
                <Stepper activeStep={ this.state.activeStep } className={ classes.stepper }>
                    {steps.map((label) => (
                        <Step key={ label }>
                            <StepLabel>{ label }</StepLabel>
                        </Step>
					))}
                </Stepper>
                <React.Fragment>
                    {this.state.activeStep === steps.length ? (
                        <React.Fragment>
                            <Typography variant="h5" gutterBottom>
								Thank you for your order.
                            </Typography>
                            <Typography variant="subtitle1">
								Your order number is #2001539. We have emailed your order confirmation, and will
								send you an update when your order has shipped.
                            </Typography>
                        </React.Fragment>
					) : (
    <React.Fragment>
        {this.state.activeStep === 0 ? <RegisterRoleDetails onTextChange={ this.onTextChange } data={ this.state }/> : <PermissionLevels /> }
        <div className={ classes.buttons }>
            {this.state.activeStep !== 0 && (
            <Button onClick={ this.handleBack } className={ classes.button }>
										Back
            </Button>
								)}
            <Button
									variant="contained"
									color="primary"
									onClick={ this.handleNext }
									className={ classes.button }
								>
                {this.state.activeStep === steps.length - 1 ? 'Place order' : 'Next'}
            </Button>
        </div>
    </React.Fragment>
					)}
                </React.Fragment>
            </Paper>
            <Typography variant="body2" color="textSecondary" align="center">
                {'Copyright © '}
                <Link color="inherit" href="https://material-ui.com/">
					Your Website
                </Link>{' '}
                {new Date().getFullYear()}
                {'.'}
            </Typography>
        </main>
    </React.Fragment>
)
	;
}
}

RegisterRole.propTypes = {
	classes : PropTypes.object.isRequired
};

const mapStateToProps = (state) => ({
	roleList : state.role
})

export default connect(mapStateToProps, { updateRoleDetails })(withStyles(useStyles)(RegisterRole));