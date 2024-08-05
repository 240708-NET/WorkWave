import taskstyles from './TaskField.module.css'
function TaskField (){

    return (
        <div className={taskstyles.taskField}>
           <input type="text" placeholder="Add a new card" />
           <button>+</button>
        </div>
    )
}

export default TaskField;