<template>
  <div>
    <h1>Pokémon List</h1>
    <ul>
      <li v-for="pokemon in pokemonList" :key="pokemon.id">
        {{ pokemon.name }}
      </li>
    </ul>
    <div>
      <button @click="fetchPreviousPage" :disabled="offset === 0">
        Previous Page
      </button>
      <button @click="fetchNextPage" :disabled="loading">Next Page</button>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      pokemonList: [],
      loading: false,
      offset: 0,
    };
  },
  methods: {
    fetchNextPage() {
      this.loading = true;
      fetch(`https://pokeapi.co/api/v2/pokemon?offset=${this.offset}&limit=10`)
        .then((response) => response.json())
        .then((data) => {
          this.pokemonList = data.results;
          this.loading = false;
          this.offset += 10;
          console.log("pokemonList: ", this.pokemonList);
        })
        .catch((error) => {
          console.error("Error fetching Pokémon:", error);
          this.loading = false;
        });
    },
    fetchPreviousPage() {
      if (this.offset >= 10) {
        this.loading = true;
        this.offset -= 10;
        fetch(
          `https://pokeapi.co/api/v2/pokemon?offset=${this.offset}&limit=10`
        )
          .then((response) => response.json())
          .then((data) => {
            this.pokemonList = data.results;
            this.loading = false;
          })
          .catch((error) => {
            console.error("Error fetching Pokémon:", error);
            this.loading = false;
          });
      }
    },
  },
  mounted() {
    this.fetchNextPage();
  },
};
</script>
