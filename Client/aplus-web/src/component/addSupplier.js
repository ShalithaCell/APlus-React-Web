import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import PersonAddIcon from '@material-ui/icons/PersonAdd';

function Copyright() {
  return (
      <Typography variant ="body2" color ="textSecondary" align="center">
          {'Copyright © '}
          <Link color="inherit" href="">
              A Plus
          </Link>{' '}
          {new Date().getFullYear()}
          {'.'}
      </Typography>
  );
}

const useStyles = makeStyles((theme) => ({
  paper : { 
    marginTop : theme.spacing(8), 

    display : 'flex',

    flexDirection : 'column',

    alignItems : 'center'
  },
  avatar : {    
    margin : theme.spacing(1),

    backgroundColor : theme.palette.secondary.main
  },
  form : {
    width : '100%', // Fix IE 11 issue.

    marginTop : theme.spacing(3)
  },
  submit : {
    margin : theme.spacing(3, 0, 2)
  }
}));

export default function SignUp() {
  const classes = useStyles();

  return (
      <Container component="main" maxWidth="xs">
          <CssBaseline />
          <div className={ classes.paper }>
              <Avatar className={ classes.avatar }>
                  <PersonAddIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                  Add Supplier
              </Typography>
              <form className={ classes.form } noValidate>
                  <Grid container spacing={ 2 }>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                autoComplete="fname"
                name="firstName"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                autoFocus
              />
                      </Grid>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="Last Name"
                name="lastName"
                autoComplete="lname"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="email"
                autoComplete="email"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="category"
                label="category"
                type="category"
                id="category"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="Area"
                label="Area"
                type="Area"
                id="Area"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="Phone Number"
                label="Phone Number"
                type="Phone Number"
                id="Phone Number"
              />
                      </Grid>
                  </Grid>
                  <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            className={ classes.submit }
          >
                      Add
                  </Button>
                  <Grid container justify="flex-end">
                      <Grid item>
                      </Grid>
                  </Grid>
              </form>
          </div>
          <Box mt={ 5 }>
              <Copyright />
          </Box>
      </Container>
  );
}
