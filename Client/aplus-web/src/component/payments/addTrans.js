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
import LockOutlinedIcon from '@material-ui/icons/LockOutlined';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import Navbar from '../navbar';
import { useState, useEffect } from 'react';
import { addTrans } from '../../redux/transactionActions'
import { useDispatch } from 'react-redux'
import { GetSession } from '../../services/sessionManagement';
import { decrypt } from '../../services/EncryptionService';
import axios from 'axios';
import { ADD_TRANSACTION_ENDPOINT } from '../../config';
import { SET_SESSION_EXPIRED } from '../../redux/actionTypes';
import { connect } from 'react-redux';
import { transactionReducer } from '../../redux/reducers/transactionReducer';
import withStyles from '@material-ui/core/styles/withStyles';

function Copyright() {
  return (
      <Typography variant="body2" color="textSecondary" align="center">
          {'Copyright © '}
          <Link color="inherit" href="https://material-ui.com/">
              Aplus 
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
  form : {
    width     : '100%', // Fix IE 11 issue.
    marginTop : theme.spacing(3)
  },
  submit : {
    margin : theme.spacing(1, 0, 1)
  },
  table : {
    width      : '100%',
    paddingTop : '2%',
    padding    : '5%' 
  }
}));

///////////////////////////////////////

const initialValues ={
  description : '',
  userid      : '',
  qty         : '', 
  unit        : '',
  total       : ''
}

const AddTransaction = ({ ...props }) => {
  const dispatch = useDispatch();
  const classes = useStyles();

  const [ values, setvalues ] = useState (initialValues) 
  const transObj = {
    Description : values.description,
    User_ID     : values.userid,
    Quantity    : values.qty,
    Unit_price  : values.unit,
    Total       : values.total
  }

  ///

  // const [ errors, seterrors ] = useState ({}) 
  //  const validate = () => {
  //    const temt = {}
  //    temp.description = values.description ? '' : 'This field is required.'
  //    temp.userid = values.userid ? '' : 'This field is required.'
  //    temp.date = values.date ? '' : 'This field is required.'
  //    temp.time = values.time ? '' : 'This field is required.'
  //    temp.qty = values.qty ? '' : 'This field is required.'
  //    temp.unit = values.unit ? '' : 'This field is required.'
  //    temp.total = values.total ? '' : 'This field is required.'
  //     seterrors({
  //       ...temp
  //     })
  //    return object.values(temp).every( (x) => x == '')
  //  }

   ///

  const OnChange = (e) => {
    e.persist();
		setvalues({ ...values, [ e.target.name ]: e.target.value })
  }
 //addTrans(userObj);

  const handleClick = (e) => {
    e.preventDefault()
    // props.addTrans(userObj);
    props.addTrans(values);
    console.log(values) ;

    // if(validate()){
    //   window.alert('validation succeeded')
    // } 
  }

  ////////////////////////////
  //    const localData = JSON.parse(GetSession());
  //    let token = localData.sessionData.token;
  //    token = decrypt(token);

  //    const success = false;
  //    let resData;

  //   console.log(token);

  //   const userObj = {
  //     Transaction_ID : values.transid,
  //     Description    : values.description,
  //     User_ID        : values.userid,
  //     Date           : values.date,
  //     Time           : values.time,
  //     Quantity       : values.qty,
  //     Unit_price     : values.unit,
  //     Total          : values.total
  //   }

  //   //API call
  //   await axios({
  //     method  : 'POST',
  //     url     : ADD_TRANSACTION_ENDPOINT,
  //     headers : { Authorization: 'Bearer ' + token  },
  //     data    : userObj
  //   })

  //        .then(function( response ){
  //          console.log(response);
  //        })
  //       .catch(function(error){
  //         console.log(error);
  //          if(error.response.status === 401){
  //           dispatch({
  //              type    : SET_SESSION_EXPIRED,
  //              payload : true
  //            })
  //          }
  //            throw error;
  //       });

  return (
      <Container component="main" maxWidth="xs">
          <Navbar/>
          <Container maxWidth="xs" >
              // eslint-disable-next-line react/jsx-indent
              <Typography component="div" className={ classes.table } />
              <Container component="main" maxWidth="xs">
                  <CssBaseline />
                  <div className={ classes.paper }>
                      <Typography component="h1" variant="h5">
                          Add Transaction
                      </Typography>
                      <div className={ classes.form } noValidate onSubmit={ handleClick }>
                          <Grid container spacing={ 2 }>
                             
                              <Grid container spacing={ 2 }>
                                  { <Grid item xs={ 12 } sm={ 6 }>
                                      { <TextField
                variant="outlined"
                required
                fullWidth
                id="description"
                label="Description"
                name="description"
                autoComplete="description"
                value = { values.description }
                onChange = { OnChange }
              /> }
                                  </Grid> }
                                  <Grid item xs={ 12 } sm={ 6 }>
                                      <TextField
                variant="userid"
                required
                fullWidth
                id="userid"
                variant="outlined"
                label="User ID"
                name="userid"
                autoComplete="userid"
                value = { values.userid }
                onChange = { OnChange }
              />
                                  </Grid>
                                  
                                  <Grid item xs={ 12 } sm={ 6 }>
                                      <TextField
                variant="outlined"
                required
                fullWidth
                id="qty"
                label=" Quantity"
                name="qty"
                autoComplete="Quantity"
                value = { values.qty }
                onChange = { OnChange }
              />
                                  </Grid>
                                  <Grid item xs={ 12 } sm={ 6 }>
                                      <TextField
                variant="outlined"
                required
                fullWidth
                id="unit"
                label="Unit Price"
                name="unit"
                autoComplete="unit"
                value = { values.unit }
                onChange = { OnChange }
              />
                                  </Grid>
                                  <Grid item xs={ 12 }>    
                                      <TextField
                variant="outlined"
                required
                fullWidth
                id="total"
                label="Total"
                name="total"
                autoComplete="total"
                value = { values.total }
                onChange = { OnChange }
              />
                                  </Grid>
                              </Grid>
                              <Button
            type="submit"
            fullWidth
            variant="contained"
            color="primary"
            onClick={ handleClick }
            //onSubmit={ handleSubmit }
            className={ classes.submit }
          >
                                  Add
                              </Button>
                              <Grid container justify="flex-end">
                              </Grid>
                          </Grid>
                      </div>
                  </div>
                  <Box mt={ 5 }>
                      <Copyright />
                  </Box>
              </Container>
          </Container>
      </Container> 
  );
}

export default connect(null, { addTrans })(withStyles(useStyles)(AddTransaction));