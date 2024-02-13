<template>
  <div>
    <h2>Products</h2>
    <ul>
      <li v-for="product in products" :key="product.id">
        {{ product.name }} - ${{ product.price }}
      </li>
    </ul>
  </div>
</template>

<script>
import axios from "axios";

export default {
  data() {
    return {
      products: [],
    };
  },
  mounted() {
    axios
      .get("https:// linkbase /api/products")
      .then((response) => {
        this.products = response.data;
      })
      .catch((error) => {
        console.error("Error fetching products:", error);
      });
  },
};
</script>
