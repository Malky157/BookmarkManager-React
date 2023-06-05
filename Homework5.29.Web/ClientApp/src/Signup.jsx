import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import axios from "axios";

const Signup = () => {

    const navigate = useNavigate();

    const [formData, setFormData] = useState({
        name: '',
        email: '',
        password: ''
    });
    const onTextChange = e => {
        const copy = { ...formData }
        copy[e.target.name] = e.target.value
        setFormData(copy)
    }
    const onFormSubmit = async e => {
        e.preventDefault();
        await axios.post('/api/user/adduser', formData, formData.password);
        navigate('/login')
    }
    return <>
        <div
            className="row"
            style={{ minHeight: "80vh", display: "flex", alignItems: "center" }}
        >
            <div className="col-md-6 offset-md-3 bg-light p-4 rounded shadow">
                <h3>Sign up for a new account</h3>
                <form onSubmit={onFormSubmit}>
                    <input type="text" name="name" placeholder="Name" className="form-control" defaultValue="" onChange={onTextChange} />
                    <br />
                    <input type="text" name="email" placeholder="Email" className="form-control" defaultValue="" onChange={onTextChange} />
                    <br />
                    <input type="password" name="password" placeholder="Password" className="form-control" defaultValue="" onChange={onTextChange} />
                    <br />
                    <button className="btn btn-primary">Signup</button>
                </form>
            </div>
        </div>
    </>
}
export default Signup;