import React, { useEffect } from 'react';
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
import Toolbar from '@material-ui/core/Toolbar';
import AppBar from '@material-ui/core/AppBar';
import InputBase from '@material-ui/core/InputBase';
import { fade } from '@material-ui/core';
import Grid from '@material-ui/core/Grid';
import Paper from '@material-ui/core/Paper';
import Navbar from './navbar';
import Container from '@material-ui/core/Container';
import { connect } from 'react-redux';
import { removeAttendance, updateAttendance, getAttendanceInformation } from '../redux/AttendanceAction';
import DialogTitle from '@material-ui/core/DialogTitle';
import DialogContent from '@material-ui/core/DialogContent';
import DialogContentText from '@material-ui/core/DialogContentText';
import DialogActions from '@material-ui/core/DialogActions';
import Dialog from '@material-ui/core/Dialog';
import { TOAST_ERROR, TOAST_SUCCESS } from '../config';
import { ToastContainer } from './dialogs/ToastContainer';

function createData(FirstName, Date, ClockonTime, ClockoutTime, WorkingHours, Edit, Delete) {
	return { FirstName, Date, ClockonTime, ClockoutTime, WorkingHours, Edit, Delete };
}

const rows = [
	createData( 'Peter', '2020.05.10', '08:00', '08:00'),
	createData( 'John', '2020.05.10', '08:00', '08:00'),
	createData( 'Peter', '2020.05.10', '08:00', '08:00'),
	createData( 'John', '2020.05.10', '08:00', '08:00')
		
];

function preventDefault(event) {
	event.preventDefault();
}

const useStyles = makeStyles((theme) => ({
	seeMore : {
		marginTop : theme.spacing(3)
	},
	root : {
		flexGrow : 5

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
	paper : {
		padding       : theme.spacing(2),
		display       : 'flex',
		overflow      : 'auto',
		flexDirection : 'column'
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

const AttendanceList = ( props ) => {

	const classes = useStyles();

	const removeAttendance = (attendanceId) =>
	{
		console.log(attendanceId);
		props.removeAttendance(attendanceId);
		props.getAttendanceInformation();
		removeAttendance();
		ToastContainer(TOAST_SUCCESS, "Successfully Deleted")
	}

	useEffect(() => {
		console.log("getinfo");
		props.getAttendanceInformation();

	}, []);
	const [ open, setOpen ] = React.useState(false);

	const handleCloseAttendance = () => {
		setOpen(false);
	};

	const handleClickOpenAttendance = () =>
	{
		setOpen(true);
	};
	//const updateInventory = (inventoryData) =>
	//{
		//console.log(inventoryData);
		//props.updateInventory(inventoryData);
	//}

	return (
    <div>
        <Navbar/>
        <div className={ 'top-5pres' }>
            <Container fixed>
                <Grid item xs={ 12 }>
                    <Paper className={ classes.paper }>
                        <React.Fragment>
                            <div className={ classes.root }>
                                <AppBar color="primary" position="relative">
                                    <Toolbar>
                                        <Typography className={ classes.title } variant="h6" noWrap>
                                            Attendance Details
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
                                        <TableCell>First Name</TableCell>
                                        <TableCell>Role</TableCell>
                                        <TableCell>Clock on Time</TableCell>
                                        <TableCell>Clock out Time</TableCell>
                                        <TableCell>Working Hours</TableCell>
                                        <TableCell>Edit</TableCell>
                                        <TableCell>Delete</TableCell>
                                    </TableRow>
                                </TableHead>
                                <TableBody>

                                    { props.attendanceList.map((row) => (
                                        <TableRow key={ row.id }>
                                            <TableCell>{ row.firstName }</TableCell>
                                            <TableCell>{ row.role }</TableCell>
                                            <TableCell>{ row.clockOnTime }</TableCell>
                                            <TableCell>{ row.clockOutTime }</TableCell>
                                            <TableCell>{ row.hours }</TableCell>
                                            <TableCell>{ <Button href="http://localhost:3000/UpdateAttendance"
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
												onClick={ handleClickOpenAttendance } 
											>
                                            </Button>
											}</TableCell><Dialog
								open={ open }
								onClose={ handleCloseAttendance }
								aria-labelledby="alert-dialog-title"
								aria-describedby="alert-dialog-description"
							>
    <DialogTitle id="alert-dialog-title">{'Are you sure you want delete this order?'}</DialogTitle>
    <DialogContent>
        <DialogContentText id="alert-dialog-description">
        </DialogContentText>
    </DialogContent>
    <DialogActions>
        <Button onClick={ removeAttendance.bind(null, row.id) } color="primary">
            Yes
        </Button>
        <Button onClick={ handleCloseAttendance } color="primary" autoFocus>
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
                    </Paper>
                </Grid>
            </Container>
        </div>
    </div>
	);
}

const mapStateToProps = (state) => ({
	attendanceList : state.attendance.attendanceList
})

export default connect(mapStateToProps, { removeAttendance, updateAttendance, getAttendanceInformation })(AttendanceList);
