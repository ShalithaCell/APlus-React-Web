import React, { Component } from 'react';
import { connect } from 'react-redux';
import { doLogin } from '../redux/userActions';
import Navbar from './navbar';
import { GetSession } from '../services/sessionManagement';

class home extends Component {

	render(){
		return (
    <div>
        <Navbar />
		Shalitha
    </div>
		)

	};
}

const mapStateToProps = (state) => ({
	items : state.user
})

export default connect(mapStateToProps, null)(home);
