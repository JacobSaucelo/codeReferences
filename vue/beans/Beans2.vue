<template>
  <div>
    <h2>Step-by-Step List</h2>
    <div v-for="step in filteredSteps" :key="step">
      <button @click="addStep(step)">{{ step }}</button>
    </div>
    <div v-if="selectedSteps.length > 0">
      <p>Selected Steps: {{ selectedSteps.join(" > ") }}</p>
    </div>
  </div>
</template>

<script>
export default {
  data() {
    return {
      steps: ["a1", "a2", "a3", "b1", "b2", "b3", "c1", "c2", "c3", "c4"],
      selectedSteps: [],
    };
  },
  computed: {
    filteredSteps() {
      return this.steps.filter((step) => !this.selectedSteps.includes(step));
    },
  },
  methods: {
    addStep(step) {
      if (this.selectedSteps.length > 0) {
        const lastSelectedStep =
          this.selectedSteps[this.selectedSteps.length - 1];
        if (this.steps.indexOf(step) <= this.steps.indexOf(lastSelectedStep)) {
          return; // Do not add the step if it violates the constraint
        }
      }
      this.selectedSteps.push(step);
    },
  },
};
</script>

<style>
/* Add your CSS styles here */
</style>
