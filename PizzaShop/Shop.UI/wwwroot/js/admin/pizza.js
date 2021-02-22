var app = new Vue({
    el: '#app',
    data: {
        loading: false,
        pizzas: [],
        pizzaModel: {
            id: 0,
            pizzaName: "AVOCADO VEG",
            pizzaDescription: "",
            pizzaSmallImagePath: "",
            pizzaLargeImagePath: "",
            pizzaPrice: 15.55,
            pizzaEnergy: 4432,
        }
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
        createPizza() {
            axios.post('/Admin/pizza', this.pizzaModel)
                .then(res => {
                    console.log(res);
                    this.pizzas.push(res.data);
                })
                .catch(err => {
                    console.log(err);
                })
                .then(() => {
                    this.loading = false;
                });
        }
    }
})