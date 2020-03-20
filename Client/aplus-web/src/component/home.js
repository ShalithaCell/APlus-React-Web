import React, { Component } from 'react';
import { connect } from 'react-redux';
import { doLogin } from '../redux/userActions';

class home extends Component {
	componentDidMount()
	{
		this.props.doLogin('shalithax@gmail.com', 'Mvc@2018');
	}

	render(){
		return (
    <div>Shalitha</div>
		)

	};
}

const mapStateToProps = (state) => ({
	items : state.user.items
})

export default connect(mapStateToProps, { doLogin })(home);