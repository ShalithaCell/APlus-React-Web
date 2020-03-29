import React from 'react';
import MaterialTable from 'material-table';
import { makeStyles } from '@material-ui/core/styles';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Paper from '@material-ui/core/Paper';
import Title from './title'
import AppBar from '@material-ui/core/AppBar';
import Toolbar from '@material-ui/core/Toolbar';
import Typography from '@material-ui/core/Typography';
import SearchIcon from '@material-ui/icons/Search';
import InputBase from '@material-ui/core/InputBase';
import { fade } from '@material-ui/core';

const useStyles =  makeStyles((theme) => ({
  table : {
    width     : '100%',
    marginTop : '2%',
    padding   : '5%' 
  },
  title : {
    align : 'left'
  },
  root : {
		flexGrow : 5
  },
  search : {
		position        : 'relative',
		borderRadius    : theme.shape.borderRadius,
		backgroundColor : fade(theme.palette.common.white, 0.15),
		'&:hover'       : {
			backgroundColor : fade(theme.palette.common.white, 0.25)
		},
		marginLeft                     : theme.spacing(5),
		width                          : '100%',
		[ theme.breakpoints.up('sm') ] : {
			marginLeft : theme.spacing(155),
			width      : 'auto'
		}
  },
  searchIcon : {
		padding        : theme.spacing( 2 ),
		height         : '100%',
		position       : 'absolute',
		pointerEvents  : 'none',
		display        : 'flex',
		alignItems     : 'center',
		justifyContent : 'center'
	},
	inputRoot : {
		color : 'inherit'
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

export default function MaterialTableDemo() {
  const [ state, setState ] = React.useState({
    columns : [
      { title: 'Full Name', field: 'name' },
      { title: 'EID', field: 'eid', type: 'numeric' },
      {
        title  : 'Designation',
        field  : 'designation',
        lookup : { 34: 'Manager', 63: 'Cleaner' }
       },
      { title: 'Basic  (Rs)', field: 'basic', type: 'numeric' },
      { title: 'Attendance', field: 'attendance', type: 'numeric' },
      { title: 'Month', field: 'month', type: 'numeric' },
      { title: 'Year', field: 'year', type: 'numeric' },
      { title: 'Bonus (Rs)', field: 'bonus', type: 'numeric' },
      { title: 'Total (Rs)', field: 'total', type: 'decimal' }

    ],
    data : [
        {
            name        : 'Mehmt dias',
            eid         : 100001,
            basic       : 15000.00,
            bonus       : 500.00,
            designation : 63,
            attendance  : 20,
            year        : 2020,
            month       : 3, 
            total       : 15500.00
          },
      {
        name        : 'Zerya Betül',
        eid         : 20002,
        basic       : 25000.00,
        bonus       : 2000.00,
        designation : 34,
        attendance  : 20,
        year        : 2020,
        month       : 3, 
        total       : 27000.00
      }
    ]
  });

  const classes = useStyles();
  
  return (
      <React.Fragment>

          <div className={ classes.root }>
              <AppBar position="relative">
                  <div>
                      <navbar/>
                  </div>
                  <Toolbar>
                      <Typography className={ classes.title } variant="h6" noWrap>
                      Salary Management Details
                      </Typography>
                  </Toolbar>
              </AppBar>
          </div>
          <MaterialTable color="primary"
      title="Employee Salary"
      columns={ state.columns }
      data={ state.data }
      editable={ {
        onRowAdd : (newData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              setState((prevState) => {
                const data = [ ...prevState.data ];
                data.push(newData);
                return { ...prevState, data };
              });
            }, 600);
          }),
        onRowUpdate : (newData, oldData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              if (oldData) {
                setState((prevState) => {
                  const data = [ ...prevState.data ];
                  data[ data.indexOf(oldData) ] = newData;
                  return { ...prevState, data };
                });
              }
            }, 600);
          }),
        onRowDelete : (oldData) =>
          new Promise((resolve) => {
            setTimeout(() => {
              resolve();
              setState((prevState) => {
                const data = [ ...prevState.data ];
                data.splice(data.indexOf(oldData), 1);
                return { ...prevState, data };
              });
            }, 600);
          })
      } }
    />
      </React.Fragment>

  );
}
