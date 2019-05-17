window.onload = function () {
    this.cm = new CommentManager();
    cm.FetchData();
};

class CommentManager{
    constructor() {
        this.commentList = document.getElementById("comment-list");
    };
    
    Parse(name, date, text){
        let str = `
            <strong class="pull-left primary-font">` + name + `</strong>
            <small class="pull-right text-muted">
                <span class="glyphicon glyphicon-time"></span> ` + date + `
            </small>
            <br/>
            <div class="ui-state-default">` + text + `</div>
            <br/>
        `;
        let div = document.createElement('div');
        div.innerHTML = str;
        while (div.children.length > 0) {
            this.commentList.appendChild(div.children[0]);
        }
    }
    
    FetchData(){
        this.commentList.innerHTML = "";
        let id = window.location.href.split("=")[1];//todo: костыль, лень морочиться
        requestDB("/Post/Comments?id="+id, null, "GET", 
            (data)=>{
            data.forEach((elem) =>{
                let date = new Date(parseInt(elem.CreateDate.substr(6)));
                date = date.toLocaleDateString('en-GB');
                window.cm.Parse(elem.Author.Name, date, elem.Text);

            })
        })
    }
    
    AddComment(){
        var userComment = document.getElementById("userComment").value;
        let postId = window.location.href.split("=")[1];//todo: костыль, лень морочиться

        requestDB("/Post/AddComment", {"postId": postId, "text": userComment}, "POST",
            (data)=>{
                data.forEach((elem) =>{
                    let date = new Date(parseInt(elem.CreateDate.substr(6)));
                    date = date.toLocaleDateString('en-GB');
                    window.cm.Parse(elem.Author.Name, date, elem.Text);

                })
            });
        document.getElementById("userComment").value = "";
        cm.FetchData();//todo переделать потом
    }
}