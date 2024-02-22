<template>
  <div>
    <h2>Step-by-Step List</h2>
    <div v-for="category in categories" :key="category">
      <h3>{{ category }}</h3>
      <div>
        <button
          v-for="step in filteredSteps(category)"
          :key="step"
          @click="addStep(category, step)"
        >
          {{ step }}
        </button>
      </div>
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
      categories: ["a", "b", "c"],
      steps: {
        a: ["a1", "a2", "a3"],
        b: ["b1", "b2", "b3"],
        c: ["c1", "c2", "c3"],
      },
      selectedSteps: [],
    };
  },
  methods: {
    filteredSteps(category) {
      let availableSteps = this.steps[category];

      if (this.selectedSteps.length > 0) {
        const lastSelectedStepIndex = this.steps[category].indexOf(
          this.selectedSteps[this.selectedSteps.length - 1][1]
        );
        availableSteps = this.steps[category].slice(lastSelectedStepIndex + 1);
      }

      return availableSteps;
    },
    addStep(category, step) {
      if (
        this.selectedSteps.some(
          (selectedStep) =>
            selectedStep[0] === category && selectedStep[1] === step
        )
      ) {
        return;
      }

      const lastSelectedStepIndex = this.selectedSteps.findIndex(
        (s) => s[0] === category
      );
      if (lastSelectedStepIndex !== -1) {
        const lastSelectedStep = this.selectedSteps[lastSelectedStepIndex][1];
        if (
          this.steps[category].indexOf(step) <=
          this.steps[category].indexOf(lastSelectedStep)
        ) {
          return;
        }
      }

      this.selectedSteps.push([category, step]);
    },
  },
};
</script>

<style>
/* Add your CSS styles here */
</style>
