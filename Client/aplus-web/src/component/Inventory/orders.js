import React from 'react';
import Link from '@material-ui/core/Link';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Title from './title';

function preventDefault(event) {
	event.preventDefault();
}

const useStyles = makeStyles((theme) => ({
	seeMore : {
		marginTop : theme.spacing(3)
	}
}));

export default function Orders() {
	const classes = useStyles();
	return (
    <React.Fragment>
        <Title>Recently Received Orders</Title>
        <Table size="small">
            <TableHead>
                <TableRow>
                    <TableCell>Date</TableCell>
                    <TableCell>Supplier Name</TableCell>
                    <TableCell>Description</TableCell>
                    <TableCell>Payment Method</TableCell>
                    <TableCell align="right">Total</TableCell>
                </TableRow>
            </TableHead>
        </Table>
    </React.Fragment>
	);
}