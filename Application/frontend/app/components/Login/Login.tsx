import loginstyles from './Login.module.css'
import {useContext, useState} from 'react'
import { UserContext } from '@/app/context/UserContext'

function Login ({login}) {
    const {username, password, setUsername, setPassword} = useContext(UserContext)

    const handleLogin = () => {
        if(username && password){
            login();
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