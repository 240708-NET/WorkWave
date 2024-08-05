import loginstyles from './Login.module.css'

function Login ({username, password} : {username: string, password: string}) {
    return (
        <div className={loginstyles.login}>
            <h2>WorkWave</h2>
            <input type="text" placeholder="username"/>
            <input type="text" placeholder="password"/>
        </div>
    )
}

export default Login;