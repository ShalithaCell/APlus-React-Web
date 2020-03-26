import React, { Component } from 'react';
import { connect } from 'react-redux';
import Navbar from '../navbar';
import MaterialTable from 'material-table';
import Container from '@material-ui/core/Container';
import PropTypes from 'prop-types';
import { updateRoleDetails } from '../../redux/roleActions';
import withStyles from '@material-ui/core/styles/withStyles';
import Card from '@material-ui/core/Card';
import CardContent from '@material-ui/core/CardContent';
import CardHeader from '@material-ui/core/CardHeader';
import Button from '@material-ui/core/Button';
import { AddCircle } from '@material-ui/icons';

const useStyles  = (theme) =>  ({
	root : {
		minWidth : 275
	},
	bullet : {
		display   : 'inline-block',
		margin    : '0 2px',
		transform : 'scale(0.8)'
	},
	title : {
		fontSize : 14
	},
	pos : {
		marginBottom : 12
	}
});

class ListOfRoles extends Component
{

	componentDidMount()
	{
		this.props.updateRoleDetails();
	}

	render()
	{
		const { classes } = this.props;
		
		return (
    <div>
        <Navbar/>
        <div className={ 'top-5pres' }>
            <Container fixed>
                <Card className={ classes.root }>
                    <CardHeader
			title="List of Roles"
			className={ 'text-left' }
			action={
    <Button variant="outlined" color="primary" startIcon={ <AddCircle /> }>
					Add Role
    </Button>
			}
			/>
                    <CardContent>

                        <MaterialTable
							title=""
							columns={ [
								{ title: 'Role name', field: 'roleName' },
								{ title: 'Display name', field: 'roleDisplayName' }
							] }
							data={ this.props.roleList.roleList  }
							actions={ [
								{
									icon    : 'save',
									tooltip : 'Save User',
									onClick : (event, rowData) => alert('You saved ' + rowData.name)
								},
								(rowData) => ({
									icon     : 'delete',
									tooltip  : 'Delete User',
									onClick  : (event, rowData) => confirm('You want to delete ' + rowData.name),
									disabled : rowData.birthYear < 2000
								})
							] }
							options={ {
								actionsColumnIndex : -1,
								search             : true
							} }
						/>

                    </CardContent>
			
                </Card>
            </Container>
        </div>
    </div>
		)
	}
}

ListOfRoles.propTypes = {
	classes : PropTypes.object.isRequired
};

const mapStateToProps = (state) => ({
	roleList : state.role
})

export default connect(mapStateToProps, { updateRoleDetails })(withStyles(useStyles)(ListOfRoles));
