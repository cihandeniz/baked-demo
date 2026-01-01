import Aura from "@primeuix/themes/aura";

export default defineNuxtConfig({
  baked: {
    apiBaseURL: import.meta.env.API_BASE_URL,
    components: {
      Page: {
        title: "Demo"
      }
    },
    composables: {
      useDataFetcher: {
        retry: true
      }
    },
    primevue: {
      theme: Aura
    }
  },
  compatibilityDate: "2025-04-02",
  components: { dirs: ["~/components"] },
  modules: [ "@nuxt/eslint", "@mouseless/baked" ],
  router: { options: { strict: true } }
});
