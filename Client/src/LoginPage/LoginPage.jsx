import React from 'react';
import { Link } from 'react-router-dom';
import { connect } from 'react-redux';
import { userActions } from '../_actions';
import '../../public/styles/login.css';

class LoginPage extends React.Component {
    constructor(props) {
        super(props);

        // reset login status
        this.props.dispatch(userActions.logout());

        this.state = {
            username: '',
            password: '',
            submitted: false
        };

        this.handleChange = this.handleChange.bind(this);
        this.handleSubmit = this.handleSubmit.bind(this);
    }


    handleChange(e) {
        const { name, value } = e.target;
        this.setState({ [name]: value });
    }

    handleSubmit(e) {
        e.preventDefault();

        this.setState({ submitted: true });
        const { username, password } = this.state;
        const { dispatch } = this.props;
        if (username && password) {
            dispatch(userActions.login(username, password));
        }
    }

    render() {
        const { loggingIn } = this.props;
        const { username, password, submitted } = this.state;
        return (
            <div className="bdy">
            <div className="my-login-page">
                <section className="h-100">
                    <div className="container h-100">
                        <div className="row justify-content-md-center h-100">
                            <div className="card-wrapper">
                                <div className="brand">
                                    <img src="../../public/images/logo.jpg" alt="logo" />
                                </div>
                                <div className="card fat">
                                    <div className="card-body">
                                        <h4 className="card-title">Login</h4>
                                        <form id="account" onSubmit={this.handleSubmit}>
                                            <div className="text-danger"></div>
                                            <div className={'form-group' + (submitted && !username ? ' has-error' : '')}>
                                                <label htmlFor="username">Email</label>
                                                <input type="text" className="form-control" name="username" value={username} onChange={this.handleChange}/>
                                                {submitted && !username &&
                                                <div className="help-block">Username is required</div>
                                                }
                                            </div>
                                            <div className={'form-group' + (submitted && !password ? ' has-error' : '')}>
                                                <label htmlFor="password">
                                                    Password
                                                    <a id="forgot-password" className="float-right"
                                                       href={'#'}>Forgot Password?</a>
                                                </label>
                                                <input type="password" className="form-control" name="password" value={password} onChange={this.handleChange}/>
                                                {submitted && !password &&
                                                <div className="help-block">Password is required</div>
                                                }
                                            </div>
                                            <div className="form-group">
                                                <div className="custom-checkbox custom-control">
                                                    <input type="checkbox" className="custom-control-input"/>
                                                    <label htmlFor="RememberMe" className="custom-control-label">RememberMe
                                                    </label>
                                                </div>
                                            </div>
                                            <div className="form-group  m-0">
                                                <button type="submit" className="btn btn-primary btn-block">Log in</button>
                                                {loggingIn &&
                                                <img src="data:image/gif;base64,R0lGODlhEAAQAPIAAP///wAAAMLCwkJCQgAAAGJiYoKCgpKSkiH/C05FVFNDQVBFMi4wAwEAAAAh/hpDcmVhdGVkIHdpdGggYWpheGxvYWQuaW5mbwAh+QQJCgAAACwAAAAAEAAQAAADMwi63P4wyklrE2MIOggZnAdOmGYJRbExwroUmcG2LmDEwnHQLVsYOd2mBzkYDAdKa+dIAAAh+QQJCgAAACwAAAAAEAAQAAADNAi63P5OjCEgG4QMu7DmikRxQlFUYDEZIGBMRVsaqHwctXXf7WEYB4Ag1xjihkMZsiUkKhIAIfkECQoAAAAsAAAAABAAEAAAAzYIujIjK8pByJDMlFYvBoVjHA70GU7xSUJhmKtwHPAKzLO9HMaoKwJZ7Rf8AYPDDzKpZBqfvwQAIfkECQoAAAAsAAAAABAAEAAAAzMIumIlK8oyhpHsnFZfhYumCYUhDAQxRIdhHBGqRoKw0R8DYlJd8z0fMDgsGo/IpHI5TAAAIfkECQoAAAAsAAAAABAAEAAAAzIIunInK0rnZBTwGPNMgQwmdsNgXGJUlIWEuR5oWUIpz8pAEAMe6TwfwyYsGo/IpFKSAAAh+QQJCgAAACwAAAAAEAAQAAADMwi6IMKQORfjdOe82p4wGccc4CEuQradylesojEMBgsUc2G7sDX3lQGBMLAJibufbSlKAAAh+QQJCgAAACwAAAAAEAAQAAADMgi63P7wCRHZnFVdmgHu2nFwlWCI3WGc3TSWhUFGxTAUkGCbtgENBMJAEJsxgMLWzpEAACH5BAkKAAAALAAAAAAQABAAAAMyCLrc/jDKSatlQtScKdceCAjDII7HcQ4EMTCpyrCuUBjCYRgHVtqlAiB1YhiCnlsRkAAAOwAAAAAAAAAAAA==" />
                                                }
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
            </div>
        );
    }
}

function mapStateToProps(state) {
    const { loggingIn } = state.authentication;
    return {
        loggingIn
    };
}

const connectedLoginPage = connect(mapStateToProps)(LoginPage);
export { connectedLoginPage as LoginPage }; 
