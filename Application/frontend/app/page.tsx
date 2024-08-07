"use client"
import {useState, useContext, useEffect} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"
import BoardField from "@/app/components/BoardField/BoardField";
import Login from "./components/Login/Login";
import {UserContext, UserProvider} from "./context/UserContext";

export default function Home() {
  const {username, password} = useContext(UserContext)
  const [showLogin, setShowLogin] = useState(false)
  const [loggedIn, setLoggedIn] = useState(false)
  const [selectedBoard, setSelectedBoard] = useState()
  const [title, setTitle] = useState("")


  const login = () => {
    console.log('login clicked')
    
      setShowLogin(false);
      setLoggedIn(true);
  
  }

  const addBoard = (name: string) => {
    setTitle(name)
    setSelectedBoard({title: name})
  }

  const boardList = [
    {title: 'Frontend'},
    {title: 'Backend'},
    {title: 'API'},

  ]
  
  return (
    
    <UserProvider>
    <main className={styles.main}>

      <NavBar loggedIn={loggedIn} showLogin={showLogin} setShowLogin={setShowLogin} />

      {!loggedIn ? (

        <h3 className={styles.loginMessage}>Please Login.</h3>

      ) : (
        <>

        {selectedBoard ? (
          <Board title={selectedBoard.title} />
         ) : (
          <div className={styles.boardSelect}>
            {boardList.map((item, key) => {
              return (
                <div 
                onClick={()=> {setSelectedBoard(item)}}
                key={key} className={styles.boardcard}>{item.title}</div>
              )
            })}
          <BoardField addBoard={addBoard} />
    </div>
         )} 
         </>

      )}
    
      {showLogin && (<Login login={login} />)}
    </main>
    </UserProvider>
  );
 
}

