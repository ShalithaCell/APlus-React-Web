import React from 'react';
import Avatar from '@material-ui/core/Avatar';
import Button from '@material-ui/core/Button';
import CssBaseline from '@material-ui/core/CssBaseline';
import TextField from '@material-ui/core/TextField';
import Grid from '@material-ui/core/Grid';
import Typography from '@material-ui/core/Typography';
import { makeStyles } from '@material-ui/core/styles';
import Container from '@material-ui/core/Container';
import DvrIcon from '@material-ui/icons/Dvr';
import Navbar from './navbar';

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
    width     : '100%', 
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
          <Navbar/>
          <CssBaseline />
          <div className={ classes.paper } >
              <Avatar className={ classes.avatar }>
                  <DvrIcon />
              </Avatar>
              <Typography component="h1" variant="h5">
                    Add Inventory
              </Typography>
              <form className={ classes.form } noValidate>
                  <Grid container spacing={ 2 }>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                autoComplete="pname"
                name="productName"
                variant="outlined"
                required
                fullWidth
                id="productName"
                label="Product Name"
                autoFocus
              />
                      </Grid>
                      <Grid item xs={ 12 } sm={ 6 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="productCode"
                label="Product Code"
                name="productCode"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                id="qty"
                label="Quantity"
                name="qty"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="uprice"
                label="Unit Price"
                type="uprice"
                id="uprice"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="date"
                label="Date"
                type="date"
                id="date"
               />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="sname"
                label="Supplire Name"
                type="sname"
                id="sname"
                autoComplete="current-sname"
              />
                      </Grid>
                      <Grid item xs={ 12 }>
                          <TextField
                variant="outlined"
                required
                fullWidth
                name="semail"
                label="Supplire Email"
                type="semail"
                id="semail"
                autoComplete="current-email"
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
            Submit
                  </Button>
                  <Grid container justify="flex-end">
                  </Grid>
              </form>
          </div>
      </Container>
  );
}
