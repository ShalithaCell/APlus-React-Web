/* eslint-disable */
import React from 'react';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import UpdateIcon from '@material-ui/icons/Update';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';

// Generate Order Data
function createData(id, BranchName, Location, PhoneNo, NoofEmployees, Update,Delete) {
	return { id, BranchName, Location, PhoneNo, NoofEmployees, Update,Delete };
}

const rows = [
	createData(0, 'Branch1', 'L1', '0000', '9'),
	createData(1, 'Branch2', 'L2', '0000', '4'),
	createData(2, 'Branch3', 'L3', '0000', '3' ),
	createData(3, 'Branch4', 'L4', '0000', '5' ),
	createData(4, 'Branch5', 'L5', '0000', '6' )
];

function preventDefault(event) {
	event.preventDefault();
}

const useStyles = makeStyles((theme) => ({
	seeMore : {
		marginTop : theme.spacing(3)
	}
}));

export default function Branches() {
	const classes = useStyles();
	return (
		<React.Fragment>
			Branch Details
			<Table size="small">
				<TableHead>
					<TableRow>
						<TableCell>Branch ID</TableCell>
						<TableCell>Branch Name</TableCell>
						<TableCell>Location</TableCell>
						<TableCell>Phone</TableCell>
						<TableCell>No of Employees</TableCell>
						<TableCell>Update</TableCell>
						<TableCell>Delete</TableCell>

					</TableRow>
				</TableHead>
				<TableBody>

					{ rows.map((row) => (

						<TableRow key={ row.id }>
							<TableCell>{ row.id }</TableCell>
							<TableCell>{ row.BranchName }</TableCell>
							<TableCell>{ row.Location }</TableCell>
							<TableCell>{ row.PhoneNo }</TableCell>
							<TableCell>{ row.NoofEmployees }</TableCell>
							<TableCell>{ <Button
								variant="contained"
								color="primary"
								className={classes.button}
								startIcon={<UpdateIcon />}
							>
								Update
							</Button>
							}</TableCell>
							<TableCell>{ <Button
								variant="contained"
								color="secondary"
								className={classes.button}
								startIcon={<DeleteIcon />}
							>
								Delete
							</Button>
							}</TableCell>
						</TableRow>
					))
					}
				</TableBody>
			</Table>

		</React.Fragment>
	);
}
