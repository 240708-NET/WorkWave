"use client"
import {useState} from "react"
import styles from "./page.module.css";
import colstyles from "@/app/components/Column/Column.module.css"
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"

export default function Home() {

  const [columns, setColumns] = useState({
    TODO: ["Task 1", "Task 2"],
    DOING: ["Task 3"],
    DONE: ["Task 4"],
  });

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
    
    <main className={styles.main}>
      <NavBar/>
    <div className={colstyles.container}>
      {Object.keys(columns).map((columnName) => (
        <Column
          key={columnName}
          name={columnName}
          tasks={columns[columnName]}
          onDrop={handleDrop}
          onDragOver={handleDragOver}
          onDragStart={handleDragStart}
        />
      ))}
    </div>
    </main>
  );
 
}

