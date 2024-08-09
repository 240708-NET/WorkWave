import React, { useState, useContext } from 'react';
import axios from 'axios';
import { useHistory } from 'react-router-dom'; // For redirecting
import { UserContext } from './UserContext'; // Assuming UserContext is set up to store user data

const CreateBoardForm = () => {
    const [boardName, setBoardName] = useState('');
    const { user } = useContext(UserContext); // Get the logged-in user
    const history = useHistory(); // For redirecting after successful creation

    const handleSubmit = async (e) => {
        e.preventDefault();

        const boardData = {
            name: boardName,
            users: [user], // Add the current user to the list of users for the board
        };

        try {
            // Create the board
            const boardResponse = await axios.post('http://localhost:5012/board', boardData);
            
            if (boardResponse.status === 200 || boardResponse.status === 201) {
                const board = boardResponse.data; // Get the board object from the response
                await createSections(board); // Create default sections for the new board
                history.push('/dashboard'); // Redirect to the dashboard
            } else {
                console.error('Failed to create board');
            }
        } catch (error) {
            console.error('Error creating board:', error);
        }
    };

    const createSections = async (board) => {
        const sections = ['To Do', 'In Progress', 'Completed'];
        try {
            await Promise.all(
                sections.map(async (sectionName) => {
                    await axios.post('http://localhost:5012/section', {
                        name: sectionName,
                        board: board // Pass the entire board object
                    });
                })
            );
        } catch (error) {
            console.error('Error creating sections:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Board Name:
                <input
                    type="text"
                    value={boardName}
                    onChange={(e) => setBoardName(e.target.value)}
                    required
                />
            </label>
            <button type="submit">Create Board</button>
        </form>
    );
};

export default CreateBoardForm;
