var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        pizzas: [],
        pizzaModel: {
            id: 0,
            pizzaName: "AVOCADO VEG",
            pizzaDescription: "",
            pizzaPrice: 15.55,
            pizzaEnergy: 4432,
            pizzaSmallImagePath: ""
        },
       
    },
    mounted() {
        this.getAllPizzas();
    },
    methods: {
        getAllPizzas() {
            this.loading = true;
            axios.get('/Admin/pizza')
                .then(res => {
                    console.log(res);
                    this.pizzas = res.data;
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        },
        
        
    }
})