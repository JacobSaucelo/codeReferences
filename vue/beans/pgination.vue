<template>
  <div>
    <input type="text" v-model="searchQuery" placeholder="Search..." />
    <select v-model="selectedFilter">
      <option value="all">All</option>
      <option value="1">Filter 1</option>
      <option value="2">Filter 2</option>
      <!-- Add more filter options as needed -->
    </select>

    <ul>
      <li v-for="item in paginatedItems" :key="item.id">{{ item.title }}</li>
    </ul>

    <button @click="prevPage" :disabled="currentPage === 1">Previous</button>
    <span>Page {{ currentPage }}</span>
    <button @click="nextPage" :disabled="currentPage === totalPages">
      Next
    </button>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [], // Array to store fetched items
      currentPage: 1, // Current page
      itemsPerPage: 5, // Number of items per page
      searchQuery: "", // User input for search
      selectedFilter: "all", // Selected filter option
    };
  },
  computed: {
    filteredItems() {
      // Apply filters based on search query and selected filter
      return this.items.filter((item) => {
        // Filter by search query
        const matchesSearch = item.title
          .toLowerCase()
          .includes(this.searchQuery.toLowerCase());

        // Filter by selected filter
        const matchesFilter =
          this.selectedFilter === "all" || item.userId == this.selectedFilter;

        return matchesSearch && matchesFilter;
      });
    },
    totalPages() {
      // Calculate the total number of pages
      return Math.ceil(this.filteredItems.length / this.itemsPerPage);
    },
    paginatedItems() {
      // Calculate the start index of the current page
      const startIndex = (this.currentPage - 1) * this.itemsPerPage;
      // Return a slice of items based on the current page and items per page
      return this.filteredItems.slice(
        startIndex,
        startIndex + this.itemsPerPage
      );
    },
  },
  mounted() {
    // Fetch initial data when component is mounted
    this.fetchData();
  },
  methods: {
    fetchData() {
      // Fetch data from the JSONPlaceholder API
      fetch("https://jsonplaceholder.typicode.com/todos")
        .then((response) => response.json())
        .then((data) => {
          this.items = data.slice(0, 50); // Update the items array with fetched data (limited to 50 for simplicity)
        })
        .catch((error) => {
          console.error("Error fetching data:", error);
        });
    },
    nextPage() {
      // Move to the next page if not already on the last page
      if (this.currentPage < this.totalPages) {
        this.currentPage++;
      }
    },
    prevPage() {
      // Move to the previous page if not already on the first page
      if (this.currentPage > 1) {
        this.currentPage--;
      }
    },
  },
};
</script>
