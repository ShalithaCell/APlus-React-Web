import React from 'react';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Title from './title';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import DialogTitle from '@material-ui/core/DialogTitle';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogActions from '@material-ui/core/DialogActions';
import Dialog from '@material-ui/core/Dialog';

function createData(date, SupplireName, Description, Qty, Tprice, Delete) {
	return { date, SupplireName, Description, Qty, Tprice, Delete };
}

const rows = [
	createData(3-2-2020, 'Peter', 'MilkPower', '2000', '30000'),
	createData(13-2-2020, 'John', 'Green Tea', '500', '45000')
	
];

function preventDefault(event) {
	event.preventDefault();
}

const useStyles = makeStyles((theme) => ({
	seeMore : {
		marginTop : theme.spacing(3)
	}
}));

export default function Orders()
{
	const classes = useStyles();
	const [ open, setOpen ] = React.useState(false);

	const handleClickOpen = () =>
	{
		setOpen(true);
	};

	const handleClose = () =>
	{
		setOpen(false);
	};

	return (
    <React.Fragment>
        <Title>Recently Received Orders</Title>
        <Table size="small">
            <TableHead>
                <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>Supplier Name</TableCell>
                    <TableCell>Description</TableCell>
                    <TableCell>Quantity</TableCell>
                    <TableCell>Total Price</TableCell>
                    <TableCell align="right">Delete</TableCell>
                </TableRow>
            </TableHead>
            <TableBody>

                {rows.map((row) => (

                    <TableRow key={ row.id }>
                        <TableCell>{row.date}</TableCell>
                        <TableCell>{row.SupplireName}</TableCell>
                        <TableCell>{row.Description}</TableCell>
                        <TableCell>{row.Qty}</TableCell>
                        <TableCell>{row.Tprice}</TableCell>
                        <TableCell align="right">{<Button
								onClick={ handleClickOpen }
								variant="contained"
								color="secondary"
								className={ classes.button }
								startIcon={ <DeleteIcon/> }
							>

                        </Button>
							}</TableCell>
                        <Dialog
								open={ open }
								onClose={ handleClose }
								aria-labelledby="alert-dialog-title"
								aria-describedby="alert-dialog-description"
							>
                            <DialogTitle id="alert-dialog-title">{'Are you sure you want delete this order?'}</DialogTitle>
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
					))
					}
            </TableBody>
        </Table>
    </React.Fragment>
	);
}