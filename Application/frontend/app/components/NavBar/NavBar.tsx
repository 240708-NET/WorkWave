import navstyles from "./NavBar.module.css"

function NavBar ({showLogin, setShowLogin} : {showLogin: Function, setShowLogin: Function}) {

    return (
        <div className={navstyles.navBar}>
      <h3>WorkWave</h3>
      <div>
        <p onClick={()=> {setShowLogin(true); console.log('clicked')}} id={navstyles.login}>Login</p>

        </div>

     </div>
    )
}

export default NavBar;