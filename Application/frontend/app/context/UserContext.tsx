"use client"
import {createContext, useState} from 'react'

/* interface User = {
    id: number,
    fullName: string,
    email: string,
    password: string,
    boards: [],
    cards: []
} */


const UserContext = createContext({
  user: null,
    username: null,
    password: null,
    setUsername: () => {},
    setPassword: () => {},
    setUser: () => {},
  });

  const UserProvider = ({ children }) => {
    const [user, setUser] = useState({})
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
  
    return (
      <UserContext.Provider value={{ user, username, password, setUsername, setPassword, setUser }}>
        {children}
      </UserContext.Provider>
    );
  };
  
  export { UserProvider, UserContext };

