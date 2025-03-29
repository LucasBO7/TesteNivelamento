<template>
    <div class="list-section">
        <ListLine :cards="cardData" />
    </div>
</template>

<script setup lang="ts">
import axios from 'axios';
import ListLine from './ListCard.vue';
import { onMounted, ref } from 'vue';

interface Card {
    nomeFantasia: string;
    razaoSocial: string;
    cnpj: string;
}

const cardData = ref<Card[]>([]);
const searchText = ref('');

// const cardData = ref<Card[]>([
//     { nomeFantasia: 'Card 1', razaoSocial: 'Descrição do Card 1', cnpj: '12345678901234' },
//     { nomeFantasia: 'Card 2', razaoSocial: 'Descrição do Card 2', cnpj: '12345678901234' },
//     { nomeFantasia: 'Card 3', razaoSocial: 'Descrição do Card 3', cnpj: '12345678901234' }
// ]);

const fetchData = async () => {
    const formData = new FormData();

    // formData.append("")

    await axios.postForm("",)
        .then(response => console.log("RESPOSTA => ", response))
        .catch(error => console.error('Houve um erro ao carregar os dados: ', error))
}

onMounted(fetchData);
</script>

<style scoped>
.list-section {
    height: 55vh;
    overflow-y: auto;
}
</style>