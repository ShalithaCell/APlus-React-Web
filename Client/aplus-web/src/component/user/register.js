import React, { Component } from 'react';
import '../../resources/styles/register.css';
import '../../resources/fonts/material-icon/css/material-design-iconic-font.min.css';
import imgLogo from '../../resources/images/signup-image.jpg'
import TextField from '@material-ui/core/TextField';
import InputLabel from '@material-ui/core/InputLabel';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';
import { Link, NavLink } from 'react-router-dom';
import { connect } from 'react-redux';
import { updateRoleDetails } from '../../redux/roleActions';
import { updateUsernameList } from '../../redux/systemActions';

class Register extends Component{

	constructor(props)
	{
		super(props);

		this.state = {
			email           : '',
			emailWarning    : '',
			username        : '',
			usernameWarning : '',
			role            : '0'
		}
	}

	componentDidMount()
	{
		this.props.updateRoleDetails(); //sync roles
		this.props.updateUsernameList(); //sync user's names
	}

	onTextChange = (e) => {

		this.setState({
			[ e.target.id ] : e.target.value
		});

		if(e.target.id === 'email'){

			if(e.target.value === ''){
				this.setState({
					emailWarning : 'email address is required  !'
				});
			}
			else if (/^[a-zA-Z0-9]+@(?:[a-zA-Z0-9]+\.)+[A-Za-z]+$/.test(e.target.value))
			{
				this.setState({
					emailWarning : ''
				});
			}else{
				this.setState({
					emailWarning : 'email address is invalid !'
				});
			}
		}

		if(e.target.id === 'username'){
			if(e.target.value === ''){
				this.setState({
					usernameWarning : 'Username is required !'
				});
			}
			else if(this.props.usernames.includes(e.target.value)){
				this.setState({
					usernameWarning : 'username is already taken'
				});
			}else{
				this.setState({
					usernameWarning : ''
				});
			}
		}

	}

	onSelectChange = (e) => {
		this.setState({
			...this.state,
			role : e.target.value
		});
	}

	render()
	{
		return (
    <div>
        <section className="signup">
            <div className="container">
                <div className="signup-content">
                    <div className="signup-form"><h2 className="form-title">Sign up</h2>
                        <form method="POST" className="register-form" id="register-form">
                            <div className="form-group">
                                <TextField id="email" label="E-mail" onChange={ this.onTextChange } value={ this.state.email } helperText={ this.state.emailWarning }
										   error={ this.state.emailWarning.length !== 0 } required/>
                            </div>
                            <div className="form-group">
                                <TextField id="username" label="Username" value={ this.state.username } onChange={ this.onTextChange }
										   error={ this.state.usernameWarning.length !== 0 }
										   helperText={ this.state.usernameWarning }
										   required/>
                            </div>
                            <div className="form-group">
                                <InputLabel className="combo-style" id="demo-simple-select-helper-label">Role</InputLabel>
                                <Select
									labelId="demo-simple-select-helper-label"
									className="combo-style"
									id="role"
									value={ this.state.role }
									onChange={ this.onSelectChange }>
                                    <MenuItem value="0">
                                        <em>Select role</em>
                                    </MenuItem>
                                    {
                                    	//check the current user role and filter the roles that he can select
										this.props.roles.roleList.map((item) => {

											if ( item.id >= this.props.currentUser.roleID ){
												return <MenuItem key={ item.id } value={ item.id }>{ item.roleDisplayName }</MenuItem>
											}

										})
									}

                                </Select>
                            </div>
                            <div className="form-group">
                                <TextField id="password" value={ this.state.password } label="Password" onChange={ this.onTextChange } type="password" required/>
                            </div>
                            <div className="form-group">
                                <TextField id="passwordConfirm" value={ this.state.passwordConfirm } label="Re-Enter Password" onChange={ this.onTextChange } type="password" required/>
                            </div>

                            <div className="form-group"><input type="checkbox" name="agree-term" id="agree-term"
																   className="agree-term"/> <label htmlFor="agree-term"
																								   className="label-agree-term"><span><span/></span>I
    agree all statements in <a href="#" className="term-service">Terms of
        service</a></label></div>
                            <div className="form-group form-button"><input type="submit" name="signup" id="signup"
																			   className="form-submit"
																			   value="Register"/></div>
                        </form>
                    </div>
                    <div className="signup-image">
                        <figure><img src={ imgLogo } alt="sing up image"/></figure>
                        <NavLink tag={ Link } className="signup-image-link" to="/counter">I am already member</NavLink>
                    </div>
                </div>
            </div>
        </section>
    </div>
		);
	}
}
const mapStateToProps = (state) => ({
	roles       : state.role,
	currentUser : state.user,
	usernames   : state.system.userNameList
})

export default connect(mapStateToProps, { updateRoleDetails, updateUsernameList } )(Register);
