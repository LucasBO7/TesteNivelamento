<script setup lang="ts">
import HomePage from './pages/HomePage.vue'
</script>

<template>
  <main>
    <HomePage />
  </main>
</template>

<style scoped>
main {
  /* width: 100%; */
  width: 75rem;
  height: 100%;
  margin: 0 auto;
  padding: 0;
}

header {
  line-height: 1.5;
}

.logo {
  display: block;
  margin: 0 auto 2rem;
}

/* Telas grandes (entre 1201px e 1440px) */
@media (min-width: 1201px) and (max-width: 1440px) {
  main {
    width: 1200px;
  }
}

/* Telas médias-grandes (entre 992px e 1200px) */
@media (min-width: 992px) and (max-width: 1200px) {
  main {
    width: 950px;
  }
}

/* Tablets e notebooks pequenos (entre 768px e 991px) */
@media (min-width: 768px) and (max-width: 991px) {
  main {
    width: 720px;
  }
}

/* Tablets pequenos (entre 576px e 767px) */
@media (min-width: 576px) and (max-width: 767px) {
  main {
    width: 540px;
  }
}
</style>
