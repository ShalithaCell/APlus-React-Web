import React, { Component } from 'react';
import '../resources/styles/register.css';
import '../resources/fonts/material-icon/css/material-design-iconic-font.min.css';
import Navbar from './navbar';
import imgLogo from '../resources/images/signup-image.jpg'
import TextField from '@material-ui/core/TextField';
import InputLabel from '@material-ui/core/InputLabel';
import Select from '@material-ui/core/Select';
import MenuItem from '@material-ui/core/MenuItem';

export default class register extends Component{

	constructor(props)
	{
		super(props);

		this.state = {
			email           : '',
			emailWarning    : '',
			username        : '',
			usernameWarning : '',
			role            : ''
		}
	}

	onTextChange = (e) => {
		this.setState({
			[ e.target.id ] : e.target.value
		})
	}

	render()
	{
		return (
    <div>
        <Navbar/>
        <section className="signup">
            <div className="container">
                <div className="signup-content">
                    <div className="signup-form"><h2 className="form-title">Sign up</h2>
                        <form method="POST" className="register-form" id="register-form">
                            <div className="form-group">
                                <TextField id="email" label="E-mail" onChange={ this.onTextChange } helperText={ this.state.emailWarning }
										   error={ this.state.emailWarning.length !== 0 } required/>
                            </div>
                            <div className="form-group">
                                <TextField id="username" label="Username" onChange={ this.onTextChange } required/>
                            </div>
                            <div className="form-group">
                                <InputLabel className="combo-style" id="demo-simple-select-helper-label">Role</InputLabel>
                                <Select
									labelId="demo-simple-select-helper-label"
									className="combo-style"
									id="role"
									onChange={ this.onTextChange }>
                                    <MenuItem value="">
                                        <em>None</em>
                                    </MenuItem>
                                    <MenuItem value={ 10 }>Super Administrator</MenuItem>
                                    <MenuItem value={ 20 }>Administrator</MenuItem>
                                    <MenuItem value={ 30 }>Manager</MenuItem>
                                </Select>
                            </div>
                            <div className="form-group">
                                <TextField id="password" label="Password" onChange={ this.onTextChange } type="password" required/>
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
                        <a href="#" className="signup-image-link">I am already member</a></div>
                </div>
            </div>
        </section>
    </div>
		);
	}
}
