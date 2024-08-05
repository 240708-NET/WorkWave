"use client"
import {useState} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"

export default function Home() {

  
  return (
    
    <main className={styles.main}>
      <NavBar/>
      <Board/>
    </main>
  );
 
}

