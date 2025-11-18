<template>
  <Skeleton
    v-if="loading"
    height="1.5rem"
  />
  <span
    v-else-if="data"
  >{{ data[prop] }}</span>
  <span v-else>-</span>
</template>
<script setup>
import { Skeleton } from "primevue";
import { useContext } from "#imports";

const context = useContext();

const { schema, data } = defineProps({
  schema: { type: null, required: true },
  data: { type: null, required: true }
});

const { prop } = schema;

const loading = context.injectLoading();
</script>
