import React from 'react';
import MaterialTable from 'material-table';
import Navbar from './navbar';
import Container from '@material-ui/core/Container';
import Typography from '@material-ui/core/Typography';

export default function UpdateInventory() {
	const [ state, setState ] = React.useState({
		columns : [
			{ title: 'Product Name', field: 'name' },
			{ title: 'Code', field: 'code' },
			{ title: 'Qty', field: 'qty', type: 'numeric' },
			{ title: 'Unit Price', field: 'unitprice', type: 'currency' },
			{ title: 'Email', field: 'email', type: 'email' },
			{ title: 'Supplire Name', field: 'sname' },
			{ title: 'Date', field: 'date', type: 'datetime' }
			
		]
	});

	return (
    <Container component="main" maxWidth="sx">
        <Navbar/>
        <Container  maxWidth="s">
            <Typography component="div" style={ {   height: '12vh' } } />
            <MaterialTable
			title="Inventory"
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
        </Container>
    </Container>
	);
}
