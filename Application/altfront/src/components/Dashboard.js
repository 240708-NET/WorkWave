import React, { useContext } from 'react';
import { UserContext } from '../context/UserContext';
import { getBoards } from '../services/apiService';

const Dashboard = () => {
    const { user } = useContext(UserContext); // Access the user object from context
    const navigate = useNavigate();

    const handleLogout = () => {
        setUser(null); // Clear the user from context
        navigate('/login'); // Redirect to the login/register page
    };

    const userBoards = user?.boards || [];

    return (
        <div>
            <h1>Welcome to your dashboard, {user?.fullName}!</h1>
            <p>Email: {user?.email}</p>


            <Boards boards={userBoards} />
            <button onClick={handleLogout}>Logout</button>
        </div>
    );
};

export default Dashboard;
