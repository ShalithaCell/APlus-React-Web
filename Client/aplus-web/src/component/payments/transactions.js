import React from 'react';
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
import { fade, Container } from '@material-ui/core';
import Navbar from '../navbar';
import Button from '@material-ui/core/Button';
import EditIcon from '@material-ui/icons/EditTwoTone';
import DeleteIcon from '@material-ui/icons/DeleteTwoTone';
import purple from '@material-ui/core/colors/purple';

const TAX_RATE = 0.07;

const useStyles =  makeStyles((theme) => ({
  table : {
    width      : '100%',
    paddingTop : '2%',
    padding    : '5%' 
  },
  title : {
    align : 'left',
    width : theme.spacing ( 35 )
  },
  root : {
        flexGrow  : 5,
        marginTop : theme.spacing ( -5 )

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
    },
    button : {
        marginTop : theme.spacing(1)
    }
}));

const steps = [ 'Edit', 'Delete' ];

function getStepContent(step) {
    <editTrans/>
}

function ccyFormat(num) {
  return `${ num.toFixed(2) }`;
}

function priceRow(qty, unit) {
  return qty * unit;
}

function createRow(transid, desc, userid, date, time, qty, unit) {
  const price = priceRow(qty, unit);
  return { transid, desc, userid, date, time, qty, unit, price };
}

function subtotal(items) {
  return items.map(({ price }) => price).reduce((sum, i) => sum + i, 0);
}

const rows = [
  createRow(1, 'Paperclips (Box)', 1001, '2020/3/22', '10.30', 100, 1.15),
  createRow(2, 'Paper (Case)', 1002,  '2020/3/22', '13.55', 10, 45.99),
  createRow(3, 'Waste Basket', 3002, '2020/3/22', '15.33', 2, 17.99)
];

const invoiceSubtotal = subtotal(rows);
const invoiceTaxes = TAX_RATE * invoiceSubtotal;
const invoiceTotal = invoiceTaxes + invoiceSubtotal;

export default function SpanningTable() {
  const classes = useStyles();
  const [ activeStep, setActiveStep ] = React.useState(0);

    const handleNext = () => {
        setActiveStep(activeStep + 1);
    };

    const handleBack = () => {
        setActiveStep(activeStep - 1);
    };

  return (
            
      <Container component="main" maxWidth="sx">
          <Navbar/>
          <Container maxWidth="$" >
              // eslint-disable-next-line react/jsx-indent
              <Typography component="div" className={ classes.table } />
              <React.Fragment>
                  <div className={ classes.root }>
                      <AppBar position="relative">
                          <div>
                              <navbar/>             
                          </div>
                          <Toolbar>
                              <Typography className={ classes.title } variant="h7" noWrap>
                                  Transaction Details
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
                  <TableContainer component={ Paper }>
                      <Table className={ classes.table } aria-label="spanning table">
                          <TableHead>
                              <TableRow>
                                  <TableCell align="center" colSpan={ 5 }>
                                      Details
                                  </TableCell>
                                  <TableCell align="right" colSpan={ 5 }>Price</TableCell>
                              </TableRow>
                              <TableRow >
                                  <TableCell>Edit / Delete</TableCell>
                                  <TableCell>Trans_ID</TableCell>
                                  <TableCell>Des</TableCell>
                                  <TableCell>User ID</TableCell>
                                  <TableCell>Date</TableCell>
                                  <TableCell>Time</TableCell>
                                  <TableCell align="right">Qty.</TableCell>
                                  <TableCell align="right">Unit</TableCell>
                                  <TableCell align="right">Sum</TableCell>
                              </TableRow>
                          </TableHead>
                          <TableBody>
                              {rows.map((row) => (
                      // eslint-disable-next-line camelcase
                                  <TableRow key={ row.transid }>
                                      <TableCell>
                                          <React.Fragment>
                                              {getStepContent(activeStep)}
                                              <div className={ classes.buttons }>
                                                  
                                                  <Button
                                                    variant="contained"
                                                    color="purple"
                                                    onClick={ handleBack }
                                                    className={ classes.button }>
                                                      <EditIcon/>
                                                  </Button>
                                                
                                                  <Button
                                                    variant="contained"
                                                    color="secondary"
                                                    onClick={ handleNext }
                                                    className={ classes.button }>
                                                      <DeleteIcon/>
                                                  </Button>
                                              </div>
                                          </React.Fragment>
                                      </TableCell>
                                      <TableCell>{row.transid}</TableCell>
                                      <TableCell>{row.desc}</TableCell>
                                      <TableCell>{row.userid}</TableCell>
                                      <TableCell>{row.date}</TableCell>
                                      <TableCell>{row.time}</TableCell>
                                      <TableCell align="right">{row.qty}</TableCell>
                                      <TableCell align="right">{row.unit}</TableCell>
                                      <TableCell align="right">{ccyFormat(row.price)}</TableCell>
                                  </TableRow>
          ))}

                              <TableRow align="right">
                                  <TableCell rowSpan={ 3 } />
                                  <TableCell colSpan={ 6 } align="right">Subtotal</TableCell>
                                  <TableCell colSpan={ 5 } align="right">{ccyFormat(invoiceSubtotal)}</TableCell>
                              </TableRow>
                              <TableRow align="right">
                                  <TableCell colSpan={ 6 } align="right">Tax</TableCell>
                                  <TableCell colSpan={ 1 } align="right">{ `${ (TAX_RATE * 100).toFixed(0) } %` }</TableCell>
                                  <TableCell colSpan={ 3 } align="right">{ccyFormat(invoiceTaxes)}</TableCell>
                              </TableRow>
                              <TableRow align="right">
                                  <TableCell colSpan={ 6 } align="right">Total</TableCell>
                                  <TableCell colSpan={ 5 } align="right" >{ ccyFormat(invoiceTotal) }</TableCell>
                              </TableRow>
                          </TableBody>
                      </Table>
                  </TableContainer>
              </React.Fragment>
          </Container>
      </Container> 
  );
}
