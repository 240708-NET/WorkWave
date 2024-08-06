import {createContext, useState} from 'react'

const UserContext = createContext({
    username: '',
    password: '',
    setUsername: () => {},
    setPassword: () => {},
  });

  const UserProvider = ({ children }) => {
    const [username, setUsername] = useState('');
    const [password, setPassword] = useState('');
  
    return (
      <UserContext.Provider value={{ username, password, setUsername, setPassword }}>
        {children}
      </UserContext.Provider>
    );
  };
  
  export { UserProvider, UserContext };

