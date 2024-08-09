import React, { useState, useContext, useEffect } from 'react';
import axios from 'axios';
import { UserContext } from './UserContext'; // Assuming UserContext is set up to store user data

const AddCardForm = ({ sectionId, onCardAdded }) => {
    const [cardTitle, setCardTitle] = useState('');
    const [cardDescription, setCardDescription] = useState('');
    const { user } = useContext(UserContext); // Get the logged-in user

    const handleSubmit = async (e) => {
        e.preventDefault();

        const cardData = {
            title: cardTitle,
            description: cardDescription,
            sectionId,
        };

        try {
            const response = await axios.post('http://localhost:5012/cards', cardData);

            if (response.status === 200 || response.status === 201) {
                onCardAdded(); // Notify parent component that a card has been added
                setCardTitle('');
                setCardDescription('');
            } else {
                console.error('Failed to create card');
            }
        } catch (error) {
            console.error('Error creating card:', error);
        }
    };

    return (
        <form onSubmit={handleSubmit}>
            <label>
                Title:
                <input
                    type="text"
                    value={cardTitle}
                    onChange={(e) => setCardTitle(e.target.value)}
                    required
                />
            </label>
            <label>
                Description:
                <textarea
                    value={cardDescription}
                    onChange={(e) => setCardDescription(e.target.value)}
                />
            </label>
            <button type="submit">Add Card</button>
        </form>
    );
};

export default AddCardForm;
