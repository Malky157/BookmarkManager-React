import React, { useState, useEffect } from "react";
import axios from "axios";
import { Link } from "react-router-dom";

const Home = () => {
   
    const [bookmarks, setbookmarks] = useState([]);

    useEffect(() => {
        const load = async () => {
            const { data } = await axios.get('/api/bookmark/topfivebookmarks');
            setbookmarks(data)
        }
        load();
    }, [])

    return <>
        <div>
            <h1>Welcome to the React Bookmark Application.</h1>
            <h3>Top 5 most bookmarked links</h3>
            <table className="table table-hover table-bordered">
                <thead>
                    <tr>
                        <th>Url</th>
                        <th>Count</th>
                    </tr>
                </thead>
                <tbody>
                    {
                        bookmarks.map(b => {
                            return (
                                <tr key={b.url}>
                                    <td>
                                        <a href={b.url} target="_blank">
                                            {b.url}
                                        </a>
                                    </td>
                                    <td>{b.userCount}</td>
                                </tr>
                            )
                        })}
                </tbody>
            </table>
        </div>

    </>
}
export default Home;