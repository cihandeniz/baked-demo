import Aura from "@primeuix/themes/aura";
import { definePreset } from "@primeuix/themes";

const Mouseless = definePreset(Aura, {
  semantic: {
    primary: {
      50: "{red.50}",
      100: "{red.100}",
      200: "{red.200}",
      300: "{red.300}",
      400: "{red.400}",
      500: "{red.500}",
      600: "{red.600}",
      700: "{red.700}",
      800: "{red.800}",
      900: "{red.900}",
      950: "{red.950}"
    }
  }
});

export default defineNuxtConfig({
  baked: {
    components: {
      Page: {
        title: "Demo"
      }
    },
    composables: {
      useDataFetcher: {
        baseURL: import.meta.env.API_BASE_URL,
        retry: true
      }
    },
    primevue: {
      theme: Mouseless
    }
  },
  compatibilityDate: "2025-04-02",
  components: { dirs: ["~/components"] },
  css: [ "~/assets/styles.scss" ],
  modules: [ "@nuxt/eslint", "baked-recipe-admin" ],
  router: { options: { strict: true } }
});
