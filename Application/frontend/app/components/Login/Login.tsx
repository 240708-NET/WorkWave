import loginstyles from './Login.module.css'
import {useContext, useState, useEffect} from 'react'
import { UserContext } from '@/app/context/UserContext'
import axios from 'axios'



function Login ({login}) {
    const {user, username, password, setUsername, setPassword, setUser} = useContext(UserContext)
    

    useEffect(()=> {
        if(user != null){
            console.log('user found!')
            console.log(user)
          }
    }, [user])

    const handleLogin = async (e) => {
        e.preventDefault();
        console.log('Button clicked')
        try {
            const response = await axios.get(`http://localhost:5012/user`)
            console.log(response.data)
            const foundUser = response.data.find(x => x.email === username && x.password === password);
            
            if(foundUser){
               console.log("Successful login!")
                    login();


                console.log(foundUser)
            setUser(foundUser)
            

            } else {
                const response = await axios.post(`http://localhost:5012/user`, {
                    fullName: username,
                    email: username,
                    password,
                    boards: [
                        {
                            name: 'Test Board',
                            users: [username]
                        }
                    ]
                }).then( async () => {

                    const response = await axios.get(`http://localhost:5012/user`)
            console.log(response.data)
            const foundUser = response.data.find(x => x.email === username && x.password === password);
            
            if(foundUser){
               console.log("Successful login!")
                    login();


                console.log(foundUser)
            setUser(foundUser)
            }

                })

                   

            }
                
            

        } catch (err){
            console.log(err)

            
           

        }

        
       

    }
    return (
        <div className={loginstyles.login}>
            <h2>WorkWave</h2>
            <input onChange={e => setUsername(e.target.value)} type="text" placeholder="username"/>
            <input onChange={e => setPassword(e.target.value)} type="password" placeholder="password"/>
            <button onClick={handleLogin}>Login</button>

        </div>
    )
}

export default Login;