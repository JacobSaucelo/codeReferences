<template>
  <div>
    <div v-for="item in items" :key="item.name + item.number">
      <button @click="addToCombo(item)">
        {{ item.name }}{{ item.number }}
      </button>
    </div>
    <div>Combo: {{ comboText }}</div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      items: [
        { name: "orange", number: "1" },
        { name: "orange", number: "2" },
        { name: "orange", number: "3" },
        { name: "apple", number: "1" },
        { name: "apple", number: "2" },
        { name: "apple", number: "3" },
        { name: "grape", number: "1" },
        { name: "grape", number: "2" },
        { name: "grape", number: "3" },
      ],
      selectedItems: [],
    };
  },
  computed: {
    comboText() {
      return this.selectedItems
        .map((item) => item.name + item.number)
        .join(" > ");
    },
  },
  methods: {
    addToCombo(item) {
      const lastSelectedItem =
        this.selectedItems[this.selectedItems.length - 1];

      if (
        !lastSelectedItem ||
        lastSelectedItem.name !== item.name ||
        lastSelectedItem.number < item.number
      ) {
        this.selectedItems.push(item);
      } else {
        console.log("Invalid selection");
      }
    },
  },
};
</script>
