/* eslint-disable */
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
import { Copyright } from '@material-ui/icons';

const useStyles = makeStyles((theme) => ({
	root : {
		height : '100vh'
	},
	image : {
		backgroundImage  : 'url(https://media-assets-05.thedrum.com/cache/images/thedrum-prod/s3-news-tmp-139705-531322819639--2x1--940.jpg)',
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

export default function SignInSide() {
	const classes = useStyles();

	return (
    <Grid container component="main" className={ classes.root }>
        <CssBaseline />
        <Grid item xs={ false } sm={ 10 } md={ 7 } className={ classes.image } />
        <Grid item xs={ 15 } sm={ 10 } md={ 5} component={ Paper } elevation={ 20 } square>
            <div className={ classes.paper }>
                <Avatar className={ classes.avatar }>
                    <HouseTwoToneIcon />
                </Avatar>
                <Typography component="h1" variant="h5">
						Add a New Branch
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
							Add Branch
                    </Button>

                    <Box mt={ 8 }>
                        <Copyright />
                    </Box>
                </form>
            </div>
        </Grid>
    </Grid>
	);
}