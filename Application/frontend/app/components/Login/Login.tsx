import loginstyles from './Login.module.css'
import {useContext, useState} from 'react'
import { UserContext } from '@/app/context/UserContext'

function Login ({login}) {
    const {username, password, setUsername, setPassword} = useContext(UserContext)
    return (
        <div className={loginstyles.login}>
            <h2>WorkWave</h2>
            <input onChange={e => setUsername(e.target.value)} type="text" placeholder="username"/>
            <input onChange={e => setPassword(e.target.value)} type="text" placeholder="password"/>
            <button onClick={login}>Login</button>
        </div>
    )
}

export default Login;