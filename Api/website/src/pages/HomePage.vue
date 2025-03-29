<script setup lang="ts">
import ListSection from '@/components/ListSection.vue';

// const openReadmeInEditor = () => fetch('/__open-in-editor?file=README.md')
</script>

<template>
  <h1 class="title">Lista</h1>

  <div id="search-section">
    <input class="input-style" type="text" placeholder="Pesquise algum dado...">
    <!-- <button>Pesquisar</button> -->
  </div>

  <div class="header-line-card-container">
    <ul>
      <li>Nome Fantasia</li>
      <li>Razão Social</li>
      <li>CNPJ</li>
    </ul>
  </div>

  <ListSection />
</template>

<style scoped>
#home-section {
  display: flex;
  align-items: center;
  justify-content: center;
  height: 90vw;
  width: 100%;
  background-color: red;
}

#search-section {
  display: flex;
  align-items: center;
  justify-content: space-between;
  width: 80vw;
  margin-bottom: 45px;
}

.input-style {
  width: 100%;
  height: 30px;
  padding: 0 10px;
  font-size: medium;
  background-color: transparent;
  border: none;
  border-bottom: 1px solid #b8b8b8;
  color: #e7e7e7;
  outline: none;
}

.title {
  margin-bottom: 60px;

}

/* HEADER CARDS LIST */
ul {
  display: flex;
  justify-content: space-between;
  text-decoration: none;
  width: 100%;
  height: 100%;
  list-style: none;
}

li {
  display: flex;
  justify-content: center;
  align-items: center;
  width: 33%;
  text-align: center;
}

.header-line-card-container {
  padding: 20px 0;
  padding-right: 15px;
  margin-bottom: 25px;
  background-color: rgb(2, 100, 156);
  border-radius: 15px;
  box-shadow: 0px 3px 10px 0px rgba(0, 0, 0, 0.521);
}

.header-line-card-container>* {
  color: #e7e7e7;
}
</style>