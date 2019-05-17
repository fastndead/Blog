window.onload = function () {
    this.sm = new SubscriptionManager();
};

class SubscriptionManager{
    constructor() {
        this.subButton = document.querySelector('.subscribe-button');
        this.subbedClass = 'subbed';
        this.subButton.addEventListener('click', function(e) {
            window.sm.toggleSubscribe();
            e.preventDefault();
        });
        this.id = window.location.href.split("=")[1];//todo: костыль, лень морочиться
        requestDB("/User/CheckSubscription?id="+this.id, null, "GET",
            (data)=>{
               this.fetch(data);
            })
    }
    
    fetch(subbed){
        var text;
        if (subbed == "True"){
            if (!this.subButton.classList.contains(this.subbedClass)) {
                this.subButton.classList.add(this.subbedClass);
                text = 'Subscribed';
                this.subButton.querySelector('.subscribe-text').innerHTML = text;
            }
        }else{
            if (this.subButton.classList.contains(this.subbedClass)) {
                this.subButton.classList.remove(this.subbedClass);
                text = 'Subscribe';
                this.subButton.querySelector('.subscribe-text').innerHTML = text;
            }
        }
    }
    toggleSubscribe(){
        var text;


        if (this.subButton.classList.contains(this.subbedClass)) {
            requestDB("/User/ToggleSubscription?id="+this.id, null, "GET",
                (data)=>{
                    this.fetch(data);
                })
        } else {
            requestDB("/User/ToggleSubscription?id="+this.id, null, "GET",
                (data)=>{
                    this.fetch(data);
                })
        }
        
    }
}