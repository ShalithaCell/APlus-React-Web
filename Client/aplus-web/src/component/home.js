import React, { Component } from 'react';
import { connect } from 'react-redux';
import { doLogin } from '../redux/userActions';
import Navbar from './navbar';
import { GetSession } from '../services/sessionManagement';
import  { decrypt } from '../services/EncryptionService';

class home extends Component {
	componentDidMount()
	{
		//this.props.doLogin('shalithax@gmail.com', 'Mvc@2018');
		let obj = JSON.parse(GetSession());
		console.log(decrypt(obj.token));
	}

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
	items : state.user.items
})

export default connect(mapStateToProps, null)(home);
