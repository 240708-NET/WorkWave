import React, { useState, useEffect } from 'react';
import axios from 'axios';

const MoveCardComponent = ({ cardId, currentSectionId, onCardMoved }) => {
    const [sections, setSections] = useState([]);
    const [selectedSectionId, setSelectedSectionId] = useState(currentSectionId);

    useEffect(() => {
        // Fetch all sections to allow moving the card
        const fetchSections = async () => {
            try {
                const response = await axios.get('http://localhost:5012/sections');
                setSections(response.data);
            } catch (error) {
                console.error('Error fetching sections:', error);
            }
        };

        fetchSections();
    }, []);

    const handleMoveCard = async () => {
        try {
            await axios.put(`http://localhost:5012/cards/${cardId}`, {
                sectionId: selectedSectionId,
            });
            onCardMoved(); // Notify parent component that the card has been moved
        } catch (error) {
            console.error('Error moving card:', error);
        }
    };

    return (
        <div>
            <select
                value={selectedSectionId}
                onChange={(e) => setSelectedSectionId(e.target.value)}
            >
                {sections.map((section) => (
                    <option key={section.id} value={section.id}>
                        {section.name}
                    </option>
                ))}
            </select>
            <button onClick={handleMoveCard}>Move Card</button>
        </div>
    );
};

export default MoveCardComponent;
