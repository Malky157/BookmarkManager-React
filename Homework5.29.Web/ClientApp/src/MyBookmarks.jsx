import React, { useState, useEffect } from "react";
import axios from "axios";
import { useAuth } from "./AuthContext";
import MyBookmarkRow from "./MyBookmarkRow";

const MyBookmarks = () => {
    const { user } = useAuth();
    const [userBookmarks, setUsersBookmarks] = useState([]);

    const loadUsersBookmarks = async () => {
        const { data } = await axios.get('/api/bookmark/getmybookmarks');
        setUsersBookmarks(data);
    }

    useEffect(() => {

        loadUsersBookmarks();
    }, [])

    return <>
        <div style={{ marginTop: 20 }}>
            <div className="row">
                <div className="col-md-12">
                    <h1>Welcome back {user.name}</h1>
                    <a className="btn btn-primary btn-block" href="/addbookmark">
                        Add Bookmark
                    </a>
                </div>
            </div>
            <div className="row" style={{ marginTop: 20 }}>
                <table className="table table-hover table-bordered">
                    <thead>
                        <tr>
                            <th>Title</th>
                            <th>Url</th>
                            <th>Edit/Delete</th>
                        </tr>
                    </thead>
                    <tbody>
                        {
                            userBookmarks.map(b => <MyBookmarkRow
                                key={b.id}
                                bookmark={b}
                                refreshTable={ loadUsersBookmarks}
                            />)
                        }
                    </tbody>
                </table>
            </div>
        </div>
    </>
}

export default MyBookmarks;