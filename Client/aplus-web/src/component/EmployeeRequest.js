import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import { Button } from '@material-ui/core';
import CssBaseline from '@material-ui/core/CssBaseline';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import Dialog from '@material-ui/core/Dialog';
import DialogActions from '@material-ui/core/DialogActions';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogTitle from '@material-ui/core/DialogTitle';
import Navbar from './navbar';

const useStyles = makeStyles({
  table : {
    minWidth : 650
  }
});

function createData(name, lastName, email, Address, PhoneNumber, Role, Action) {
  return { name, lastName, email, Address, PhoneNumber, Role, Action };
}

const rows = [
  createData('Ron', "wisly", "rw@gmail.com", "116/5 1st Cross Street,Colombo", "0771230030", "Sales Manager"),
  createData('Harry', "Potter", "hp@gmail.com", "116/5 1st Cross Street,Colombo", "0712835663", "Inventory Manager")
 
];

export default function SimpleTable() {
  const classes = useStyles();
  const [ open, setOpen ] = React.useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
      <Container component="main" maxWidth="sx">
          <Navbar/> 
    
          <Container maxWidth="s">
              <Typography component="div" style={ {  height: '15vh' } } />
              <TableContainer component={ Paper } style={ {  height: '50vh' } }>
       
                  <Table className={ classes.table } aria-label="simple table">
                      <TableHead>
                          <TableRow>
                              <TableCell>First Name</TableCell>
                              <TableCell align="right">Last Name</TableCell>
                              <TableCell align="right">Email</TableCell>
                              <TableCell align="right">Address</TableCell>
                              <TableCell align="right">Phone Number</TableCell>
                              <TableCell align="center">Role</TableCell>
                              <TableCell align="center">Action</TableCell>
                          </TableRow>
                      </TableHead>
                      <TableBody>
                          {rows.map((row) => (
                              <TableRow key={ row.name }>
                                  <TableCell component="th" scope="row">
                                      {row.name}
                                  </TableCell>
                                  <TableCell align="right">{row.lastName}</TableCell>
                                  <TableCell align="right">{row.email}</TableCell>
                                  <TableCell align="right">{row.Address}</TableCell>
                                  <TableCell align="right">{row.PhoneNumber}</TableCell>
                                  <TableCell align="right">{row.Role} </TableCell>
                                  <Button variant="contained" color="primary" size="small" >
 ADD
                                  </Button>
                                  <Button variant="contained" color="primary" size="small" onClick={ handleClickOpen } >
 DELETE
                                  </Button>
                                  <Dialog
        open={ open }
        onClose={ handleClose }
        aria-labelledby="alert-dialog-title"
        aria-describedby="alert-dialog-description"
      >
                                      <DialogTitle id="alert-dialog-title">{"DO YOU WANT TO DELETE THIS?"}</DialogTitle>
                                      <DialogContent>
                                          <DialogContentText id="alert-dialog-description">
           
                                          </DialogContentText>
                                      </DialogContent>
                                      <DialogActions>
                                          <Button onClick={ handleClose } color="primary">
           Yes
                                          </Button>
                                          <Button onClick={ handleClose } color="primary" autoFocus>
           No
                                          </Button>
                                      </DialogActions>
                                  </Dialog>
                              </TableRow>
          ))}
                      </TableBody>
                  </Table>
              </TableContainer>
          </Container>
      </Container>
  );
}