import { useState } from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import FormControlLabel from '@material-ui/core/FormControlLabel';
import Checkbox from '@material-ui/core/Checkbox';
import Link from '@material-ui/core/Link';
import Grid from '@material-ui/core/Grid';
import Box from '@material-ui/core/Box';
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';

function Copyright() {
  return (
      <Typography variant="body2" color="textSecondary" align="center">
          {'Copyright © '}
          {new Date().getFullYear()}
          {'-'}
          <Link color="inherit" href="https://google.com/">
              NVIDID Techonologies
          </Link>{' '}
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

export default function customeradd() {
    // eslint-disable-next-line react-hooks/rules-of-hooks
  const classes = useStyles();
    // eslint-disable-next-line react-hooks/rules-of-hooks
  const [ add, setadd ] = useState({ cfname: '', clname: '', cemail: '', cidnumber: '', cphonenumber: '' })

          const onChangeCustomer = (e) => {
            e.presist();
            setadd({ ...add, [ e.target.name ]: e.target.value })
            console.log(e)
          }
  return (
    
      <Container component="main" maxWidth="xs">
          <CssBaseline />
          <div className={ classes.paper }>
              <Avatar className={ classes.avatar }>
                  <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                  Customer add
              </Typography>
              <form className={ classes.form } noValidate>
                  <Grid container spacing={ 2 }>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                             autoComplete="fname"
                             name="cfName"
                             variant="outlined"
                             required
                             fullWidth
                             id="firstName"
                             label="First Name"
                             value={ add.cfname }
                             autoFocus
                             ocChange={ onChangeCustomer }
                            />
                      </Grid>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                           variant="outlined"
                           required
                           fullWidth
                           id="lastName"
                           label="Last Name"
                           name="clName"
                           autoComplete="lname"
                           value={ add.clname }
                           onChange={ onChangeCustomer }
                           />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                            variant="outlined"
                            required
                            fullWidth
                            id="email"
                            label="Email Address"
                            name="cemail"
                            autoComplete="email"
                            value={ add.cemail }
                            onChange={ onChangeCustomer }
                            />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                            variant="outlined"
                            required
                            fullWidth
                            id="id_number"
                            label="ID Number"
                            name="cidnumber"
                            autoComplete="number"
                            value={ add.cidnumber }
                            onChange={ onChangeCustomer }
                            />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                            variant="outlined"
                            required
                            fullWidth
                            id="phone_number"
                            label="Phone number"
                            name="cphonenumber"
                            autoComplete="phone_number"
                            value={ add.cphonenumber }
                            onChange={ onChangeCustomer }
                            />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <FormControlLabel
                               control={ <Checkbox value="allowExtraEmails" color="primary" /> }
                               label="Enter the correct details"
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
                      Add Customer
                  </Button>
                  <Grid container justify="flex-end">
                  </Grid>
              </form>
          </div>
          <Box mt={ 5 }>
              <Copyright />
          </Box>
      </Container>
  );
}                     
