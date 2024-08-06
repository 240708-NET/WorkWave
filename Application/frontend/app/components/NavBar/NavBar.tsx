import navstyles from "./NavBar.module.css"
import { UserContext } from "@/app/context/UserContext";
import {useContext, useState} from 'react'

function NavBar ({loggedIn, showLogin, setShowLogin}) {
  const {username} = useContext(UserContext)

  let date = new Date();


function NavBar ({showLogin, setShowLogin} : {showLogin: Function, setShowLogin: Function}) {


    return (
        <div className={navstyles.navBar}>
      <h3>WorkWave</h3>
      <div>

        {(username  && loggedIn)? (
          <div className={navstyles.user}>
          <p>{date.getHours() > 19 ? "Good evening, " : date.getHours() < 12 ? "Good morning, " : "Good afternoon, "}{username}</p>
          <p id={navstyles.logout} onClick={()=>{window.location.href = '/'}}>Logout</p>

          </div>
        ):(
          <p onClick={()=>{setShowLogin(true)}}>Login</p>
        )}


        </div>

     </div>
    )
}

export default NavBar;