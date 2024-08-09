import React from 'react';

const Card = ({ card }) => {
    return (
        <div className="card">
            <h3>{card.title}</h3>
            {/* You can add functionality for moving cards here */}
        </div>
    );
};

export default Card;
