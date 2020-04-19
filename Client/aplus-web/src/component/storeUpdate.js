import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Paper from '@material-ui/core/Paper';
import Box from '@material-ui/core/Box';
import Grid from '@material-ui/core/Grid';
import HouseTwoToneIcon from '@material-ui/icons/HouseTwoTone';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Link from '@material-ui/core/Link';
import Navbar from './navbar';
import Container from '@material-ui/core/Container';

function Copyright() {
	return (
    <Typography variant="body2" color="textSecondary" align="center">
        {'Copyright © '}
        <Link color="inherit" href="http://localhost:3000/storeDashboard">
            Aplus Web
        </Link>{' '}
        {new Date().getFullYear()}
        {'.'}
    </Typography>
	);
}

const useStyles = makeStyles((theme) => ({
	root : {
		height : '100vh'
	},
	image : {
		backgroundImage  : 'url(https://cdn2.vectorstock.com/i/1000x1000/42/56/business-people-meeting-team-discussion-vector-26464256.jpg)',
		backgroundRepeat : 'no-repeat',
		backgroundColor  :
			theme.palette.type === 'light' ? theme.palette.grey[ 50 ] : theme.palette.grey[ 900 ],
		backgroundSize     : 'cover',
		backgroundPosition : 'center'
	},
	paper : {
		margin        : theme.spacing(8, 4),
		display       : 'flex',
		flexDirection : 'column',
		alignItems    : 'center'
	},
	avatar : {
		margin          : theme.spacing(1),
		backgroundColor : theme.palette.info.main
	},
	form : {
		width     : '100%', // Fix IE 11 issue.
		marginTop : theme.spacing(5)
	},
	submit : {
		margin : theme.spacing(6, 0, 2)
	}
}));

export default function StoreUpdate() {
	const classes = useStyles();

	return (
    <div>
        <Navbar/>
        <div className={ 'top-5pres' }>
            <Container fixed>
                <Grid container component="main" className={ classes.root }>
                    <CssBaseline />
                    <Grid item xs={ false } sm={ 10 } md={ 7 } className={ classes.image } />
                    <Grid item xs={ 12 } sm={ 10 } md={ 5 } component={ Paper } elevation={ 20 } square>
                        <div className={ classes.paper }>
                            <Avatar className={ classes.avatar }>
                                <HouseTwoToneIcon />
                            </Avatar>
                            <Typography component="h1" variant="h5">
                                Update Existing Branch
                            </Typography>
                            <form className={ classes.form } Validate>

                                <TextField
							variant="outlined"
							margin="normal"
							required
							fullWidth
							id="bName"
							label="Branch Name"
							name="bName"
							autoComplete="bName"

						/>
                                <TextField
							variant="outlined"
							margin="normal"
							required
							fullWidth
							name="location"
							label="Location"
							type="location"
							id="location"

						/>
                                <TextField
							variant="outlined"
							margin="normal"
							required
							fullWidth
							name="tpNo"
							label="Phone No"
							type="tpNo"
							id="tpNo"
						/>

                                <TextField
							variant="outlined"
							margin="normal"
							fullWidth
							name="noofEmployees"
							label="No of Employees"
							type="noofEmployees"
							id="noofEmployees"
						/>

                                <Button
							type="submit"
							variant="contained"
							color="primary"
							className={ classes.submit }
						>
                                    Update Branch
                                </Button>

                                <Box mt={ 8 }>
                                    <Copyright />
                                </Box>
                            </form>
                        </div>
                    </Grid>
                </Grid>
            </Container>
        </div>
    </div>
	);
}
