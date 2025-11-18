<template>
  <InputText
    v-model="model"
    :name
    :placeholder
    class="w-32"
    size="small"
  />
</template>
<script setup>
import { InputText } from "primevue";

const { schema } = defineProps({
  schema: { type: null, required: true }
});
const model = defineModel({ type: null, required: true });

const { name, placeholder } = schema;
</script>
