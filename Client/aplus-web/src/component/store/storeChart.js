import React from 'react';
import Button from '@material-ui/core/Button';
import DeleteIcon from '@material-ui/icons/Delete';
import EditIcon from '@material-ui/icons/Edit';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import SearchIcon from '@material-ui/icons/Search';
import Typography from '@material-ui/core/Typography';
import Link from '@material-ui/core/Link';
import Box from '@material-ui/core/Box';
import Toolbar from '@material-ui/core/Toolbar';
import AppBar from '@material-ui/core/AppBar';
import InputBase from '@material-ui/core/InputBase';
import { fade } from '@material-ui/core';
import MaterialTable from 'material-table';

// Generate Order Data
function createData(id, BranchName, Location, PhoneNo, NoofEmployees, Update, Delete) {
	return { id, BranchName, Location, PhoneNo, NoofEmployees, Update, Delete };
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

function Copyright() {
	return (
    <Typography variant="body2" color="textSecondary" align="center">
        {'Copyright © '}
        <Link color="inherit" href="https://material-ui.com/">
            A Plus Web
        </Link>{' '}
        {new Date().getFullYear()}
        {'.'}
    </Typography>
	);
}

const useStyles = makeStyles((theme) => ({
	seeMore : {
		marginTop : theme.spacing(3)
	},
	root : {
		flexGrow : 5

	},
	paper : {
		padding   : theme.spacing(2),
		textAlign : 'center',
		color     : '#95a5a6'
	},
	menuButton : {
		marginRight : theme.spacing(2)
	},
	title : {
		flexGrow                       : 1,
		display                        : 'none',
		[ theme.breakpoints.up('sm') ] : {
			display : 'block'
		}
	},
	search : {
		position        : 'relative',
		borderRadius    : theme.shape.borderRadius,
		backgroundColor : fade(theme.palette.common.white, 0.15),
		'&:hover'       : {
			backgroundColor : fade(theme.palette.common.white, 0.25)
		},
		marginLeft                     : 0,
		width                          : '100%',
		[ theme.breakpoints.up('sm') ] : {
			marginLeft : theme.spacing(1),
			width      : 'auto'
		}
	},
	searchIcon : {
		padding        : theme.spacing(0, 2),
		height         : '100%',
		position       : 'absolute',
		pointerEvents  : 'none',
		display        : 'flex',
		alignItems     : 'center',
		justifyContent : 'center'
	},
	inputRoot : {
		color : '#95a5a6'

	},

	inputInput : {
		padding                        : theme.spacing(1, 1, 1, 0),
		// vertical padding + font size from searchIcon
		paddingLeft                    : `calc(1em + ${ theme.spacing(4) }px)`,
		transition                     : theme.transitions.create('width'),
		width                          : '100%',
		[ theme.breakpoints.up('sm') ] : {
			width     : '12ch',
			'&:focus' : {
				width : '20ch'
			}
		}
	}

}));

export default function Branches() {
	const classes = useStyles();
	return (

    <React.Fragment>

        <div className={ classes.root }>
            <AppBar color="primary" position="relative">

                <Toolbar>

                    <Typography className={ classes.title } variant="h6" noWrap>
                        Branch Details

                    </Typography>
                    <div className={ classes.search }>
                        <div className={ classes.searchIcon }>

                            <SearchIcon />
                        </div>
                        <InputBase
								placeholder="Search…"
								classes={ {
									root  : classes.inputRoot,
									input : classes.inputInput
								} }
								inputProps={ { 'aria-label': 'search' } }
							/>
                    </div>
                </Toolbar>
            </AppBar>
        </div>
        <Table size="small">
            <TableHead>
                <TableRow>
                    <TableCell>Branch ID</TableCell>
                    <TableCell>Branch Name</TableCell>
                    <TableCell>Location</TableCell>
                    <TableCell>Phone</TableCell>
                    <TableCell>No of Employees</TableCell>
                    <TableCell>Edit</TableCell>
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
								className={ classes.button }
								startIcon={ <EditIcon /> }
							>

                        </Button>
							}</TableCell>
                        <TableCell>{ <Button
								variant="contained"
								color="secondary"
								className={ classes.button }
								startIcon={ <DeleteIcon /> }
							>

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
