import React from 'react';
import Section from './Section';

const Board = ({ board }) => {
    return (
        <div className="board">
            <h1>{board.name}</h1>
            <div className="sections">
                <Section sectionName="To Do" boardId={board.id} />
                <Section sectionName="In Progress" boardId={board.id} />
                <Section sectionName="Completed" boardId={board.id} />
            </div>
        </div>
    );
};

export default Board;
