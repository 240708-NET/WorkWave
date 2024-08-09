"use client"
import {useState, useContext, useEffect} from "react"
import styles from "./page.module.css";
import NavBar from "@/app/components/NavBar/NavBar"
import Column from "@/app/components/Column/Column"
import Board from "@/app/components/Board/Board"
import BoardField from "@/app/components/BoardField/BoardField";
import Login from "./components/Login/Login";
import {UserContext, UserProvider} from "./context/UserContext";
import axios from 'axios'

export default function Home() {
  const {user, username, password} = useContext(UserContext)
  const [showLogin, setShowLogin] = useState(false)
  const [loggedIn, setLoggedIn] = useState(false)
  const [selectedBoard, setSelectedBoard] = useState()
  const [boardList, setBoardList] = useState()
  const [title, setTitle] = useState("")






  const login = () => {
   
    console.log('login clicked')
    
      setShowLogin(false);
      setLoggedIn(true);
  
  }

  const addBoard = async (name: string) => {

    console.log(user.id)

    try {

     /*  const response = await axios.post(`http://localhost:5012/Board`, 
        {
          name,   
        users: [
          {
            id: user.id,
            fullName: user.email,
            email: user.email,
            password: user.password,
            boards: user.boards ? [...user.boards] : []
          }
        ]
        }
      ) */

        const response = await axios.put(`http://localhost:5012/user`, {
         
         id: user.id,
          fullName: user.email,
          email: user.email,
          password: user.password,
          boards: user.boards ? [...user.boards] : []
          
        })
      .then(async () => {
        const boardResponse = await axios.get(
          `http://localhost:5012/user/${user.id}`
        );
  
        console.log(boardResponse.data.boards);
        
        setBoardList(boardResponse.data.boards)
       
      })
    } catch (err){
      console.log(err)
    }

   
   

    
  }

  /* const boardList = [
    {title: 'Frontend'},
    {title: 'Backend'},
    {title: 'API'},

  ] */

    useEffect(() => {
      if (loggedIn) {
        console.log(user)
        console.log('get user called')
        const getUser = async () => {
          const response = await axios.get("http://localhost:5012/user");
  
          const foundUser = response.data.find(
            (x) => x.email === username && x.password === password
          );
  
          if (foundUser) {
            const boardResponse = await axios.get(
              `http://localhost:5012/user/${foundUser.id}`
            );
  
            console.log(boardResponse.data.boards);
            
            setBoardList(boardResponse.data.boards)
           
          }
        };
        getUser();
      }
    }, [loggedIn]);
  

    
  
  return (
    
   
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
            {boardList && boardList.map((item, key) => {
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
    
  );
 
}

