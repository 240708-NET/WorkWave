import taskstyles from './BoardField.module.css'
import {useState} from 'react'


function BoardField({addBoard}){
    const [title, setTitle] = useState("")
    return (
       <div className={taskstyles.task}>
        <input type="text" placeholder="Add a new board" value={title} onChange={e => setTitle(e.target.value)}/>
        <button onClick={()=> {addBoard(title); setTitle("")}}>+</button>
       </div>


    )
}

export default BoardField;