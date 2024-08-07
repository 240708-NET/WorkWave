import { useState } from "react";
import colstyles from "../Column/Column.module.css"
import Column from "../Column/Column";
import ColumnField from "../ColumnField/ColumnField";




function Board({title}) {
  /* const [columns, setColumns] = useState({
    TODO: ["Task 1", "Task 2"],
    DOING: ["Task 3"],
    DONE: ["Task 4"],
  }); */

  const [columns, setColumns] = useState({})

  const addTask = (col : string, newtask: string) => {
    
    setColumns({...columns, [col]: [...columns[col], newtask]})
   
  }

  const addColumn = (col : string) => {
    setColumns({...columns, [col]: []})
  }

  const handleDragStart = (event: React.DragEvent<HTMLDivElement>, task: string) => {
    event.dataTransfer.setData("text/plain", task);
  };

  const handleDrop = (event: React.DragEvent<HTMLDivElement>, columnName: string) => {
    const task = event.dataTransfer.getData("text");
    const updatedColumns = { ...columns };
    for (const key in updatedColumns) {
      const index = updatedColumns[key].indexOf(task);
      if (index > -1) {
        updatedColumns[key].splice(index, 1);
      }
    }
    updatedColumns[columnName].push(task);
    setColumns(updatedColumns);
  };

  const handleDragOver = (event: React.DragEvent<HTMLDivElement>) => {
    event.preventDefault();
  };

  return (
    <>
    <h2>{title}</h2>
    <div className={colstyles.container}>
      {Object.keys(columns).map((columnName) => (
        <Column
          key={columnName}
          name={columnName}
          tasks={columns[columnName]}
          onDrop={handleDrop}
          onDragOver={handleDragOver}
          onDragStart={handleDragStart}
          addTask={addTask}
        />
      ))}
       <ColumnField addColumn={addColumn}/>
    </div>
   
    </>
  );
}

export default Board;