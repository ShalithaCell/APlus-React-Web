import React, { useState, useEffect } from 'react';
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
import Navbar from './navbar';
import { GetSession } from '../services/sessionManagement';
import { decrypt } from '../services/EncryptionService';
import axios from 'axios';
import { ADD_REQUEST } from '../config';
import { useDispatch } from 'react-redux';
import { REMOVE_REQUEST_ENDPOINT } from '../config';

//
function Copyright() {
  return (
      <Typography variant="body2" color="textSecondary" align="center">
          {'Copyright © '}
          <Link color="inherit" href="https://material-ui.com/">
              Your Website
          </Link>{' '}
          {new Date().getFullYear()}
          {'.'}
      </Typography>
  );
}

const useStyles = makeStyles((theme) => ({
  paper : {
    marginTop     : theme.spacing(8),
    display       : 'flex',
    flexDirection : 'column',
    alignItems    : 'center'
  },
  avatar : {
    margin          : theme.spacing(1),
    backgroundColor : theme.palette.secondary.main
  },
  form : {
    width     : '100%', // Fix IE 11 issue.
    marginTop : theme.spacing(3)
  },
  submit : {
    margin : theme.spacing(3, 0, 2)
  }
}));

export default function UpdateRequest() {
  //const dispatch = useDispatch();
  //const classes = useStyles();
  //const [ update, setadd ] = useState( { firstName: '', lastName: '', email: '', password: '', Address: '', PhoneNumber: '',  Role: '' });
  //const onChangeAddRequest = (event) => {
    //event.persist();
    //setadd({ ...update, [ event.target.name ]: event.target.value });
     //};
  // const  onChangeupdateRequest = (requestData) => async (dispatch) => {

    //  const localData = JSON.parse(GetSession());
      //let token = localData.sessionData.token;
      //token = decrypt(token); //decrypt the token
   
/* async function UpdateRequests()
  {
      const localData = JSON.parse(GetSession());
      let token = localData.sessionData.token;
      token = decrypt(token);

      //console.log('ABC');
      let success = false;
      let resData;
    
      //API call
      await axios({
        method  : 'post',
        url     : UPDATE_REQUEST_ENDPOINT,
        headers : { Authorization: 'Bearer ' + token },
        data    : requestData
      })
        .then(function(response)
        {
          return true;
        })
        .catch(function(error)
        {
          if(error.response.status === 401){
            dispatch({
              type    : SET_SESSION_EXPIRED,
              payload : true
            });
    
          }
          throw error;
        });
    
    }*/
   // const dispatch = useDispatch();
  const classes = useStyles();
  /*const [ add, setadd ] = useState( { fname: '', lname: '', remail: '', rAddress: '', rPhonenumber: '', arole: '' } );
  const onChangeUpdateRequest = (event) => {
    event.persist();
    setadd({ ...add, [ event.target.name ]: event.target.value });
     };

  async function AddRequests()
  {
      const localData = JSON.parse(GetSession());
      let token = localData.sessionData.token;
      token = decrypt(token);

      //console.log('ABC');
      let success = false;
      let resData;

      console.log(token);

      const userObj = {
        fname   : add.fname,
        lname   : add.lname,
        email   : add.remail,
        address : add.rAddress,
        phoneno : add.rPhonenumber,
        role    : add.arole
      
      }

      //API call
      await axios({
        method  : 'post',
        url     : ADD_REQUEST,
        headers : { Authorization: 'Bearer ' + token },
        data    : userObj
    })
        .then(function(response)
        {
            console.log("ok");
        })
        .catch(function(error)
        {
            if(error.response.status === 401){
                dispatch({
                    type    : SET_SESSION_EXPIRED,
                    payload : true
                });

            }
            throw error;
        });
}*/
    
  return (
      <Container component="main" maxWidth="xs">
          <Navbar/>
          <CssBaseline />
          <div className={ classes.paper }>
              <Avatar className={ classes.avatar }>
                  <LockOutlinedIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                  New Employee
              </Typography>
              <form className={ classes.form } noValidate>
                  <Grid container spacing={ 2 }>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                autoComplete="fname"
                name="fname"
                variant="outlined"
                required
                fullWidth
                id="firstName"
                label="First Name"
                autoFocus
                //onChange={ onChangeAddRequest }
              />
                      </Grid>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="lastName"
                label="Last Name"
                name="lname"
                autoComplete="lname"
                //onChange={ onChangeupdateRequest }
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="email"
                label="Email Address"
                name="remail"
                autoComplete="email"
                //onChange={ onChangeupdateRequest }
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="rAddress"
                label="Address"
                type="Address"
                id="Address"
                autoComplete="current-password"
                //onChange={ onChangeupdateRequest }
              />
              
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="rPhonenumber"
                label="Phone Number"
                type="Phone Number"
                id="Phone Number"
                autoComplete="Phone Number"
                //onChange={ onChangeupdateRequest }
              />
              
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="arole"
                label="Role"
                type="Role"
                id="Role"
                autoComplete="Role"
                //onChange={ onChangeupdateRequest }
              />
                      </Grid>
                     
                  </Grid>
                  <Button
            type="submit"
            maxWidth="50sp"
            variant="contained"
            color="primary"
            className={ classes.submit }
           // onClick={ UpdateRequests }
          >
                      UPDATE
                  </Button>
                 
                  <Button
            type="submit"
          maxWidth="50sp"
            variant="contained"
            color="primary"
            className={ classes.submit }
            //onClick={ removeRequest }
          >
                      DELETE
                  </Button>
                 
              </form>
          </div>
          
      </Container>
  );
}
