import React, { useEffect } from 'react';
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
import { connect } from 'react-redux';
import { REMOVE_REQUEST_ENDPOINT } from '../config';
import { removeRequest, getRequestInformation } from '../redux/requestActions';
import { ToastContainer } from './dialogs/ToastContainer';
import { TOAST_ERROR, TOAST_SUCCESS } from '../config';

const useStyles = makeStyles({
  table : {
    minWidth : 650
  }
});

function createData(name, lastName, email, Address, PhoneNumber, Role, Action) {
  return { name, lastName, email, Address, PhoneNumber, Role, Action };
}

const rows = [
  createData('Ron', 'wisly', 'rw@gmail.com', '116/5 1st Cross Street,Colombo', '0771230030', 'Sales Manager'),
  createData('Harry', 'Potter', 'hp@gmail.com', '116/5 1st Cross Street,Colombo', '0712835663', 'Inventory Manager')
 
];
 const EmployeeRequest = ( props ) => {
 const classes = useStyles();
  //const [ open, setOpen ] = React.useState(false);

  //const handleClickOpen = () => {
    //setOpen(true);
  //const handleClose = () => {
    //setOpen(false);
    const [ open, setOpen ] = React.useState(false);

	const handleCloseEmployeeRequest = () => {
		setOpen(false);
	};

	const handleClickOpenEmployeeRequest = () =>
	{
		setOpen(true);
	};
    const DeleteRequest = (id) => {
        console.log(id);
        props.removeRequest(id);
        props.getRequestInformation();
        handleCloseEmployeeRequest();
        ToastContainer(TOAST_SUCCESS, "Successfully Deleted")
    }
    useEffect( () => {
        console.log("DDDD");
        props.getRequestInformation();
     },  [] );
     /*if(!this.props.editable){
        const userObj = {
            Email       : this.state.email,
            Password    : this.state.password,
            RoleID      : this.state.role,
            UserName    : this.state.username,
            PhoneNumber : this.state.phone,
            OrgID       : this.props.currentUser.orgID,
            BaseUrl     : host
        };

        result = await this.props.createNewUser(userObj);
    }else{
        const userObj = {
            Email       : this.state.email,
            Password    : this.state.password,
            RoleID      : this.state.role,
            PhoneNumber : this.state.phone
        };*/
  
//
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
                            <TableCell >Last Name</TableCell>
                            <TableCell >Email</TableCell>
                            <TableCell >Address</TableCell>
                            <TableCell >Phone Number</TableCell>
                            <TableCell >Role</TableCell>
                            <TableCell ></TableCell>
                            <TableCell ></TableCell>
                            <TableCell ></TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {props.requestList.map((row) => (
                            <TableRow key={ row.id }>
                                
                                <TableCell >{row.firstName}</TableCell>
                                <TableCell >{row.lastName}</TableCell>
                                <TableCell >{row.email}</TableCell>
                                <TableCell >{row.address}</TableCell>
                                <TableCell >{row.phoneNumber}</TableCell>
                                <TableCell >{row.role} </TableCell>
                                <TableCell>{ <Button variant="contained" color="primary" size="small" >
                                    ADD
                                </Button>}</TableCell>

                                <TableCell>{<Button variant="contained" color="primary" size="small" onClick={ handleClickOpenEmployeeRequest } >
                                    DELETE
                                </Button>}</TableCell>
                                <Dialog
								open={ open }
								onClose={ handleCloseEmployeeRequest }
								aria-labelledby="alert-dialog-title"
								aria-describedby="alert-dialog-description"
							>
                                    <DialogTitle id="alert-dialog-title">{'Are you sure you want delete this order?'}</DialogTitle>
                                    <DialogContent>
                                        <DialogContentText id="alert-dialog-description">

                                        </DialogContentText>
                                    </DialogContent>
                                    <DialogActions>
                                        <Button onClick={ DeleteRequest.bind(null, row.id) } color="primary">
                                            Yes
                                        </Button>
                                        <Button onClick={ handleCloseEmployeeRequest } color="primary" autoFocus>
                                            No
                                        </Button>
                                    </DialogActions>
                                </Dialog>
                                <TableCell>{ <Button variant="contained" color="primary" size="small" href="http://localhost:3000/UpdateRequest"
>
                                    UPDATE
                                </Button>}</TableCell>
                            </TableRow>

          ))}
                    </TableBody>
                </Table>
            </TableContainer>
        </Container>
    </Container>
  );
//}
//};
                        }
const mapStateToProps = (state) => ({
    requestList : state.request.requestList
})

export default connect(mapStateToProps, { removeRequest, getRequestInformation }) (EmployeeRequest);
