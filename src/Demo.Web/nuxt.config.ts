import Aura from "@primeuix/themes/aura";

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
      theme: Aura
    }
  },
  compatibilityDate: "2025-04-02",
  components: { dirs: ["~/components"] },
  modules: [ "@nuxt/eslint", "@mouseless/baked" ],
  router: { options: { strict: true } },
  vite: { optimizeDeps: { noDiscovery: true } }
});
