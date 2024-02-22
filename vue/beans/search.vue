<template>
  <div>
    <input type="text" v-model="searchQuery" placeholder="Search..." />
    <select v-model="selectedFilter">
      <option value="all">All</option>
      <option value="1">Filter 1</option>
      <option value="2">Filter 2</option>
    </select>

    <ul>
      <li v-for="item in filteredItems" :key="item.id">{{ item.title }}</li>
    </ul>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [],
      searchQuery: "",
      selectedFilter: "all",
    };
  },
  computed: {
    filteredItems() {
      return this.items.filter((item) => {
        const matchesSearch = item.title
          .toLowerCase()
          .includes(this.searchQuery.toLowerCase());

        const matchesFilter =
          this.selectedFilter === "all" || item.userId == this.selectedFilter;

        return matchesSearch && matchesFilter;
      });
    },
  },
  mounted() {
    this.fetchData();
  },
  methods: {
    fetchData() {
      fetch("https://jsonplaceholder.typicode.com/todos")
        .then((response) => response.json())
        .then((data) => {
          this.items = data.slice(0, 10);
        })
        .catch((error) => {
          console.error("Error fetching data:", error);
        });
    },
  },
};
</script>
