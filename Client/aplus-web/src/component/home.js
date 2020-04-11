import React, { Component } from 'react';
import { connect } from 'react-redux';
import { doLogin } from '../redux/userActions';
import Navbar from './navbar';
import { GetSession } from '../services/sessionManagement';
import CssBaseline from '@material-ui/core/CssBaseline';
import Paper from '@material-ui/core/Paper';
import Grid from '@material-ui/core/Grid';
import { makeStyles } from '@material-ui/core/styles';
import Button from '@material-ui/core/Button';
import Card from '@material-ui/core/Card';
import CardActions from '@material-ui/core/CardActions';
import CardContent from '@material-ui/core/CardContent';
import CardMedia from '@material-ui/core/CardMedia';
import Typography from '@material-ui/core/Typography';
import Container from '@material-ui/core/Container';
import ButtonGroup from '@material-ui/core/ButtonGroup';
import Table from '@material-ui/core/Table';
import TableBody from '@material-ui/core/TableBody';
import TableCell from '@material-ui/core/TableCell';
import TableContainer from '@material-ui/core/TableContainer';
import TableHead from '@material-ui/core/TableHead';
import TableRow from '@material-ui/core/TableRow';
import Icon from '@material-ui/core/Icon';
import SaveIcon from '@material-ui/icons/Save';
import green from '@material-ui/core/colors/green';
import purple from '@material-ui/core/colors/purple';
import red from '@material-ui/core/colors/red';

const useStyles = makeStyles((theme) => ({
	root : {
		height : '100vh'

	},
	paper : {
		margin : theme.spacing(2, 2),

		display : 'flex',

		flexDirection : 'column',

		alignItems : 'center',

		'& > *' : {
			margin : theme.spacing(1)
		}
	},
	cardGrid : {
		paddingTop : theme.spacing(8),

		paddingBottom : theme.spacing(8)
	},
	card : {
		height : '10' +
			'0%',

		display : 'flex',

		flexDirection : 'column'
	},
	cardMedia : {
		paddingTop : '56.25%' // 16:9
	},
	cardContent : {
		flexGrow : 1
	},
	table : {
		minWidth : 500
	}
}));
function ccyFormat(num) {
	return `${ num.toFixed(2) }`;
}

function priceRow(qty, unit) {
	return qty * unit;
}

function createRow(desc, qty, unit) {
	const price = priceRow(qty, unit);
	return { desc, qty, unit, price };
}

function subtotal(items) {
	return items.map(({ price }) => price).reduce((sum, i) => sum + i, 0);
}

const primary = red[ 500 ]; // #F44336
const accent = purple[ 'A200' ]; // #E040FB
const accent2 = purple.A200;

const TAX_RATE = 0.07;

const rows = [
	createRow('Paperclips (Box)', 100, 1.15),
	createRow('Paper (Case)', 10, 45.99),
	createRow('Waste Basket', 2, 17.99)
];

const invoiceSubtotal = subtotal(rows);
const invoiceTaxes = TAX_RATE * invoiceSubtotal;
const invoiceTotal = invoiceTaxes + invoiceSubtotal;

const cards = [ 1, 2, 3, 4, 5, 6 ];

export default function SignInSide() {
	const classes = useStyles();

	return (
		
    <Grid container component="main" className={ classes.root }>
        <Navbar />
        <CssBaseline />
        <Grid item xs={ false } sm={ 4 } md={ 7 }>
            <div className={ classes.paper }>
                <Container className={ classes.cardGrid } maxWidth="md">
                    {/* End hero unit */}
                    <Grid container spacing={ 4 }>
                        { cards.map((card) => (
                            <Grid item key={ card } xs={ 12 } sm={ 6 } md={ 4 }>
                                <Card className={ classes.card }>
                                    <CardMedia
										className={ classes.cardMedia }
										image="https://source.unsplash.com/random"
										title="Image title"
									/>
                                    <CardContent className={ classes.cardContent }>
                                        <Typography gutterBottom variant="h5" component="h2">
                                            Coca cola
                                        </Typography>
                                        <Typography>
                                            This is a Coca cola
                                        </Typography>
                                    </CardContent>
                                    <CardActions>
                                        <Button variant="contained" size="small" color="secondary">
                                            Buy
                                        </Button>
                                    </CardActions>
                                </Card>
                            </Grid>
						))}
                    </Grid>
                </Container>
            </div>
        </Grid>

        <Grid item xs={ 12 } sm={ 8 } md={ 5 } component={ Paper } elevation={ 6 } square>
            <TableContainer component={ Paper }>
                <Table className={ classes.table } aria-label="spanning table">
                    <TableHead>
                        <TableRow>
                            <TableCell align="center" colSpan={ 3 }>
                                Details
                            </TableCell>
                            <TableCell align="right">Price</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Desc</TableCell>
                            <TableCell align="right">Qty.</TableCell>
                            <TableCell align="right">Unit</TableCell>
                            <TableCell align="right">Sum</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {rows.map((row) => (
                            <TableRow key={ row.desc }>
                                <TableCell>{row.desc}</TableCell>
                                <TableCell align="right">{row.qty}</TableCell>
                                <TableCell align="right">{row.unit}</TableCell>
                                <TableCell align="right">{ccyFormat(row.price)}</TableCell>
                            </TableRow>
						))}

                        <TableRow>
                            <TableCell rowSpan={ 3 } />
                            <TableCell colSpan={ 2 }>Subtotal</TableCell>
                            <TableCell align="right">{ccyFormat(invoiceSubtotal)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell>Tax</TableCell>
                            <TableCell align="right">{`${ (TAX_RATE * 100).toFixed(0) } %`}</TableCell>
                            <TableCell align="right">{ccyFormat(invoiceTaxes)}</TableCell>
                        </TableRow>
                        <TableRow>
                            <TableCell colSpan={ 2 }>Total</TableCell>
                            <TableCell align="right">{ccyFormat(invoiceTotal)}</TableCell>
                        </TableRow>
                    </TableBody>
                </Table>
            </TableContainer>
            <Grid item xs={ false } sm={ 4 } md={ 7 }>

                <CssBaseline />
                <Grid item xs={ 12 } sm={ 8 } md={ 5 } component={ Paper } elevation={ 6 } square>
                    <ButtonGroup variant="contained" orientation="horizontal" color="primary" aria-label="horizontal contained primary button group">
                        <Button size="large" variant="contained">1</Button>
                        <Button>2</Button>
                        <Button>3</Button>
                        <Button>Qty</Button>
                        <Button>Sec1</Button>
                        <Button>Employee</Button>
                        <Button  size="medium" color="primary" >Loyalty</Button>
                        <Button variant="contained" color="secondary"  size="large">Review</Button>
                    </ButtonGroup>
                    <ButtonGroup variant="contained" orientation="horizontal" size="large" color="primary" aria-label="horizontal contained primary button group">
                        <Button>4</Button>
                        <Button>5</Button>
                        <Button>6</Button>
                        <Button>Disc</Button>
                        <Button>Pannel</Button>
                        <Button>Info</Button>
                        <Button variant="contained" color="secondary"  startIcon={ <SaveIcon /> } size="large">PayBills</Button>
                    </ButtonGroup>
                    <ButtonGroup variant="contained" orientation="horizontal" size="large" color="primary" aria-label="horizontal contained primary button group">
                        <Button>7</Button>
                        <Button>8</Button>
                        <Button>9</Button>
                        <Button>Price</Button>
                        <Button>Sales</Button>
                        <Button>Attend</Button>
                        <Button variant="contained" color="secondary"  size="large">Discount</Button>
                    </ButtonGroup>
                    <ButtonGroup variant="contained" orientation="horizontal" size="large" color="primary" aria-label="horizontal contained primary button group">
                        <Button>+</Button>
                        <Button>0</Button>
                        <Button >-</Button>
                        <Button>Del</Button>
                        <Button>%</Button>
                        <Button>*</Button>
                        <Button>Chec</Button>
                        <Button variant="contained" color="accent" endIcon={ <Icon>send</Icon> } size="large">Payment</Button>
                    </ButtonGroup>
                </Grid>
            </Grid>
           
        </Grid>
    </Grid>
);
 }
