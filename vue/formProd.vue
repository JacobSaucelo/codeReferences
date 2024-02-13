<template>
  <div>
    <h2>Add Product</h2>
    <form @submit.prevent="addProduct">
      <label>Name:</label>
      <input type="text" v-model="name" required />
      <label>Price:</label>
      <input type="number" v-model="price" required />
      <button type="submit">Add Product</button>
    </form>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      name: "",
      price: 0,
    };
  },
  methods: {
    addProduct() {
      axios
        .post("https://link base/api/products", {
          name: this.name,
          price: this.price,
        })
        .then((response) => {
          console.log("Product added:", response.data);
          this.name = "";
          this.price = 0;
        })
        .catch((error) => {
          console.error("Error adding product:", error);
        });
    },
  },
};
</script>
