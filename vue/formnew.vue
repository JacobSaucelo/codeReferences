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
export default {
  data() {
    return {
      name: "",
      price: 0,
    };
  },
  methods: {
    addProduct() {
      fetch("https://linkk/api/products", {
        method: "POST",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify({
          name: this.name,
          price: this.price,
        }),
      })
        .then((response) => response.json())
        .then((data) => {
          console.log("Product added:", data);
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
