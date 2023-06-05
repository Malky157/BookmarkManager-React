import React from 'react';
import 'bootstrap/dist/css/bootstrap.min.css';
import { Route, Routes } from 'react-router';
import { AuthContextComponent } from './AuthContext';
import Layout from './Layout';
import Signup from './Signup';
import Home from './Home';
import Login from './Login';
import Addbookmark from './AddBookmark';
import MyBookmarks from './MyBookmarks';
import PrivateRoute from './PrivateRoute';
import Logout from './Logout';
import MyBookmarkRow from './MyBookmarkRow';


const App = () => {
    return (
        <AuthContextComponent>
            <Layout>
                <Routes>
                    <Route exact path='/' element={<Home />} />
                    <Route exact path='/signup' element={<Signup />} />
                    <Route exact path='/login' element={<Login />} />

                    <Route exact path='/addbookmark' element={
                        <PrivateRoute>
                            <Addbookmark />
                        </PrivateRoute>} />

                    <Route exact path='/mybookmarks' element={
                        <PrivateRoute>
                            <MyBookmarks />
                        </PrivateRoute>} />

                        <Route exact path='/mybookmarks' element={
                        <PrivateRoute>
                            <MyBookmarkRow />
                        </PrivateRoute>} />
                        
                    <Route exact path='/logout' element={
                        <PrivateRoute>
                            <Logout />
                        </PrivateRoute>} />
                </Routes>
            </Layout>
        </AuthContextComponent>
    )
}

export default App;