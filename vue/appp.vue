<template>
  <div id="app">
    <ProductList />
    <ProductForm />
  </div>
</template>

<script>
import ProductList from "./components/ProductList.vue";
import ProductForm from "./components/ProductForm.vue";

export default {
  components: {
    ProductList,
    ProductForm,
  },
};
</script>
