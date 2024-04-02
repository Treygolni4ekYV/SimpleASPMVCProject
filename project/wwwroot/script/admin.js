async function deletePost(){
    let a = document.getElementById("postId").value;

    const resp = await fetch(
        `DeletePost?id=${a}`,{
            method: "DELETE"
        }
    )

    if(!resp.ok){
        console.log("Ошибка с переданным индексом")
    }
}