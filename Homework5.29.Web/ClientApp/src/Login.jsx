import React, { useState } from "react";
import axios from "axios";
import { useNavigate } from "react-router-dom";
import { useAuth } from "./AuthContext";


const Login = () => {
    const navigate = useNavigate();
    const [formData, setFormData] = useState({
        email: '',
        password: ''
    });
    const [isValidLogin, setIsValidLogin] = useState(true);
    const { setUser } = useAuth();

    const onTextChange = e => {
        const copy = { ...formData }
        copy[e.target.name] = e.target.value
        setFormData(copy)
    }

    const onFormSubmit = async e => {
        e.preventDefault();
        const { data } = await axios.post('/api/user/login', formData);
        const isValid = !!data
        setIsValidLogin(isValid)
        if (isValid) {
            setUser(data)
            navigate('/mybookmarks')           
        }

    }
    return <>
        <div className="row" style={{ minHeight: "80vh", display: "flex", alignItems: "center" }}>
            <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                <h3>Log in to your account</h3>
                <form onSubmit={onFormSubmit}>
                    {!isValidLogin && <span className="text-danger">Invalid username/password. Please try again.</span>}
                    <input type="text" name="email" placeholder="Email" className="form-control" defaultValue="" onChange={onTextChange} />
                    <br />
                    <input type="password" name="password" placeholder="Password" className="form-control" defaultValue="" onChange={onTextChange} />
                    <br />
                    <button className="btn btn-primary">Login</button>
                </form>
                <a href="/signup">Sign up for a new account</a>
            </div>
        </div>

    </>
}
export default Login;