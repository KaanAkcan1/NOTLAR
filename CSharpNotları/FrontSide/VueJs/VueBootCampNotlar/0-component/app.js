const app = Vue.createApp({
    data(){
        return{};
    },
});


app.component("counter-item", {
    data(){
        return{
            counter:0,
        };
    },
    template : `
        <div class="container-sm">
            <h3>{{counter}}</h3>
            <button class="red" @click="counter--"></button>
            <button class="green" @click="counter++"></button>

        </div>
    `
});
app.mount("app"); 