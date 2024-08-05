import colstyles from "./Column.module.css"
function Column(){

    const names = [
        {
            name: "TODO"
        },
        {
            name: "DOING"
        },
        {
            name: "DONE"
        }
    ]
    return (
        <div className={colstyles.container}>
        {names.map((item, key) => {
            return(
                <div key={key} className={colstyles.column}>
                    <h5>{item.name}</h5>
                </div>
            )
        })}
        </div>
    )
}

export default Column;