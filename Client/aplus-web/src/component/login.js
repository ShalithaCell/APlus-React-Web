import React, { Component } from 'react';
import { connect } from 'react-redux';
import { doLogin } from '../redux/userActions';
import '../resources/styles/login.css'

class login extends Component
{

	constructor(props)
	{
		super(props);
		this.state = {
			username : '',
			password : ''
		}
	}
	render()
	{
		return (
    <div className="my-login-page">
        <section className="h-100">
            <div className="container h-100">
                <div className="row justify-content-md-center h-100">
                    <div className="card-wrapper">
                        <div className="brand">
                            <img src={ process.env.PUBLIC_URL + "/resources/img/logo.jpg" } alt="logo"/>
                        </div>
                        <div className="card fat">
                            <div className="card-body">
                                <h4 className="card-title">Login</h4>
                                <form className="my-login-validation">
                                    <div className="text-danger"></div>
                                    <div className="form-group">
                                        <label htmlFor="Email" className="left-c">Email</label>
                                        <input id="Email" type="text" className="form-control" required/>

                                    </div>
                                    <div className="form-group">
                                        <label htmlFor="Password" className="left-c">
														Password
                                            <a id="forgot-password" className="float-right" href="#">Forgot
															Password?</a>
                                        </label>
                                        <input type="Password" className="form-control" required />

                                    </div>
                                    <div className="form-group">
                                        <div className="custom-checkbox custom-control">
                                            <input type="checkbox" className="custom-control-input"/>
                                            <label htmlFor="RememberMe" className="custom-control-label left-c">
												RememberMe
                                            </label>
                                        </div>
                                    </div>
                                    <div className="form-group  m-0">
                                        <button type="submit" className="btn btn-primary btn-block">Log in</button>
                                    </div>
                                </form>
                            </div>
                        </div>
                        <div className="footer">
										Copyright &copy; {(new Date().getFullYear())} &mdash; <a href="#" target="_blank">NVIVID
										Technologies</a>
                        </div>
                    </div>
                </div>
            </div>
        </section>
    </div>
		)
	};
}

export default login;
