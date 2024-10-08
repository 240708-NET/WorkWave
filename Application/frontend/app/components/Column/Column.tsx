import colstyles from "./Column.module.css"
import Card from "@/app/components/Card/Card";
import TaskField from "@/app/components/TaskField/TaskField"



interface ColumnProps {
    name: string;
    tasks: string[];
    onDrop: (event: React.DragEvent<HTMLDivElement>, columnName: string) => void;
    onDragOver: (event: React.DragEvent<HTMLDivElement>) => void;
  }


interface ColumnProps {
  name: string;
  tasks: string[];
  onDrop: (event: React.DragEvent<HTMLDivElement>, columnName: string) => void;
  onDragOver: (event: React.DragEvent<HTMLDivElement>) => void;
}

interface ColumnProps {
    name: string;
    tasks: string[];
    onDrop: (event: React.DragEvent<HTMLDivElement>, columnName: string) => void;
    onDragOver: (event: React.DragEvent<HTMLDivElement>) => void;
    onDragStart: (event: React.DragEvent<HTMLDivElement>, task: string) => void;
  }
  
  function Column({ addTask, name, tasks, onDrop, onDragOver, onDragStart }: ColumnProps) {

    
    return (
      <div
        className={colstyles.column}
        onDrop={(event) => onDrop(event, name)}
        onDragOver={(event) => onDragOver(event)}
      >
        <h5>{name}</h5>
        {tasks.map((task, index) => (
          <Card key={index} task={task} onDragStart={onDragStart} />
        ))}

        <TaskField name={name} addTask={addTask} />

      </div>

    );
  }

export default Column;