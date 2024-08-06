"use client"
import {useState, useContext, useEffect} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"
import Login from "./components/Login/Login";
import {UserContext, UserProvider} from "./context/UserContext";

export default function Home() {
  const {username, password} = useContext(UserContext)
  const [showLogin, setShowLogin] = useState(false)
  const [loggedIn, setLoggedIn] = useState(false)

  const login = () => {
    console.log('login clicked')
    
      setShowLogin(false);
      setLoggedIn(true);
    
  }
  
  return (
    
    <UserProvider>
    <main className={styles.main}>
      <NavBar loggedIn={loggedIn} showLogin={showLogin} setShowLogin={setShowLogin} />
      <Board/>
      {showLogin && (<Login login={login} />)}
    </main>
    </UserProvider>
  );
 
}

