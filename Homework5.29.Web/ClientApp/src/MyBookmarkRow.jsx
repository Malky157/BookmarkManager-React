import axios from "axios";
import React, { useState } from "react";


const MyBookmarkRow = ({ bookmark, refreshTable }) => {

    const [editMode, setEditMode] = useState(false)
    const [title, setTitle] = useState(bookmark.title)
    
    const onTextChange = e => {
        setTitle(e.target.value)
    }
    const onCancelClick = () => {
        setEditMode(false)
        setTitle(bookmark.title)
    }

    const onUpdateClick = async () => {
        bookmark.title = title
        await axios.post('/api/bookmark/updatebookmarktitle', bookmark)
        setEditMode(false)
    }
    const onDeleteClick = async () => {
        const id = bookmark.id
        await axios.post('/api/bookmark/deletebookmark', { id })
        refreshTable()
    }
    return <>
        <tr>
            <td>
                {editMode ? <input type="text" className="form-control" placeholder="Title" name="title" value={title} onChange={onTextChange} /> : bookmark.title}
            </td>
            <td>
                <a href={bookmark.url} target="_blank">{bookmark.url}</a>
            </td>
            <td>
                {editMode ? <><button className="btn btn-warning" onClick={onUpdateClick}>Update</button>

                    <button className="btn btn-info" onClick={onCancelClick}>Cancel</button></> :

                    <button className="btn btn-success" onClick={() => setEditMode(true)}>Edit Title</button>}

                <button className="btn btn-danger" style={{ marginLeft: 10 }} onClick={onDeleteClick} >
                    Delete
                </button>
            </td>
        </tr>
    </>
}

export default MyBookmarkRow;