import taskstyles from './TaskField.module.css'
import {useState} from 'react'


function TaskField({name, addTask}){
    const [text, setText] = useState("")
    return (
       <div className={taskstyles.task}>
        <input type="text" placeholder="Add a new task" value={text} onChange={e => setText(e.target.value)}/>
        <button onClick={()=> {addTask(name, text ); setText("")}}>+</button>
       </div>


    )
}

export default TaskField;