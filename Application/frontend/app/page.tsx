"use client"
import {useState} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"
import LoginContext from "./context/UserContext";

export default function Home() {
  const [username, setUsername] = useState("")
  const [password, setPassword] = useState("")
  
  return (
    
    <LoginContext.Provider value={{username, setUsername, password, setPassword}}>
    <main className={styles.main}>
      <NavBar/>
      <Board/>
    </main>
    </LoginContext.Provider>
  );
 
}

