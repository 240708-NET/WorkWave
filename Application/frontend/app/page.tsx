"use client"
import {useState} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"
import Login from "@/app/components/Login/Login";
import axios from 'axios'

export default function Home() {
  const [showLogin, setShowLogin] = useState(false)


  const getBoard = async () => {
    const response = await axios.get('http://localhost:5012/Board');

    console.log(response)
  }

  getBoard();

  
  return (
    
    <main className={styles.main}>
      <NavBar showLogin={showLogin} setShowLogin={setShowLogin}/>
      {showLogin && <Login />}
      <Board/>
    </main>
  );
 
}

