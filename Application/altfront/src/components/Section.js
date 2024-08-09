import React, { useState } from 'react';
import axios from 'axios';
import Card from './Card'; // Assuming you have a Card component

const Section = ({ sectionName, boardId }) => {
    const [cards, setCards] = useState([]);
    const [cardTitle, setCardTitle] = useState('');

    const addCard = async () => {
        const newCard = { title: cardTitle, boardId, sectionName };

        try {
            const response = await axios.post('/api/cards', newCard);
            if (response.status === 200 || response.status === 201) {
                setCards([...cards, response.data]);
                setCardTitle('');
            } else {
                console.error('Failed to create card');
            }
        } catch (error) {
            console.error('Error creating card:', error);
        }
    };

    return (
        <div className="section">
            <h2>{sectionName}</h2>
            <input 
                type="text" 
                value={cardTitle} 
                onChange={(e) => setCardTitle(e.target.value)} 
                placeholder="Enter card title" 
            />
            <button onClick={addCard}>Add Card</button>
            <div className="cards">
                {cards.map((card) => (
                    <Card key={card.id} card={card} />
                ))}
            </div>
        </div>
    );
};

export default Section;
