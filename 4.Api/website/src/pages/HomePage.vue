<script setup lang="ts">
import ListSection from '@/components/ListSection.vue';
import api from '@/services/service';
import { onMounted, ref, watch } from 'vue';

interface Card {
  registroANS: string;
  cnpj: string;
  razaoSocial: string;
  nomeFantasia: string;
  modalidade: string;
  logradouro: string;
  numero: string;
  complemento: string;
  bairro: string;
  cidade: string;
  uf: string;
  cep: string;
  ddd: string;
  telefone: string;
  fax: string;
  enderecoEletronico: string;
  representante: string;
  cargoRepresentante: string;
  regiaoComercializacao: number;
  dataRegistroANS: Date;
}

const cardData = ref<Card[]>([]);
const searchText = ref('');

const submitForm = async () => {
  const formData = new FormData();
  formData.append('SearchText', searchText.value);

  await api.post("api/RegisteredOperations/SearchAll", formData, {
    headers: {
      'Content-Type': 'multipart/form-data',
    }
  }).then(response => {
    cardData.value = response.data;
  })
    .catch(error => console.error('Houve um erro ao carregar os dados: ', error))
}

onMounted(submitForm);

watch(searchText, (_newValue, _oldValue) => {
  submitForm()
});
</script>

<template>
  <div id="home-section">
    <div id="search-section">
      <h1>Operadoras de Saúde Ativas</h1>
      <input v-model="searchText" class="input-style" type="text" placeholder="Pesquise por algum dado...">
    </div>

    <div class="header-line-card-container">
      <ul>
        <li>Nome Fantasia</li>
        <li>Razão Social</li>
        <li>CNPJ</li>
      </ul>
    </div>

    <ListSection :cardsData="cardData" />
  </div>
</template>

<style scoped>
#home-section {
  display: flex;
  align-items: center;
  justify-content: center;
  flex-direction: column;
  height: 100%;
  width: 100%;
}

#search-section {
  display: flex;
  align-items: start;
  justify-content: center;
  flex-direction: column;
  width: 100%;
  height: fit-content;
  margin: 20px 0px;
  gap: 30px;
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
  width: 100%;
  padding: 20px 0;
  padding-right: 15px;
  margin-bottom: 25px;
  background-color: rgb(2, 100, 156);
  border-radius: 15px;
  box-shadow: 0px 3px 10px 0px rgba(0, 0, 0, 0.521);
  color: #e7e7e7;

}

/* .header-line-card-container>* {
  color: #e7e7e7;
} */
</style>