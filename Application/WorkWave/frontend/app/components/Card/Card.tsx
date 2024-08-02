import cardstyles from "./Card.module.css"

export interface CardProps {
  task: string;
  onDragStart: (event: React.DragEvent<HTMLDivElement>, task: string) => void;
}

function Card({ task, onDragStart }: CardProps) {
  return (
    <div
      className={cardstyles.card}
      draggable
      onDragStart={(event) => onDragStart(event, task)}
    >
      {task}
    </div>
  );
}

export default Card;