import taskstyles from './ColumnField.module.css'
import {useState} from 'react'


function ColumnField({addColumn}){
    const [title, setTitle] = useState("")
    return (
       <div className={taskstyles.task}>
        <input type="text" placeholder="Add a new column" value={title} onChange={e => setTitle(e.target.value)}/>
        <button onClick={()=> {addColumn(title); setTitle("")}}>+</button>
       </div>


    )
}

export default ColumnField;