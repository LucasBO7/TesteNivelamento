<template>
    <div class="line-card-container" v-for="(item, index) in cards" :key="index" @click="openModal(item)">
        <ul>
            <li>{{ truncateText(item.nomeFantasia) }}</li>
            <li>{{ truncateText(item.razaoSocial) }}</li>
            <li>{{ item.cnpj }}</li>
        </ul>
    </div>
</template>

<script setup lang="ts">
import { onMounted, onUnmounted, ref } from 'vue';

interface CardPrint {
    nomeFantasia: string;
    razaoSocial: string;
    cnpj: string;
}

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

defineProps<{
    cards: CardPrint[];
    openModal: (cardData: Card) => void;
}>();

const isMobile = ref(window.innerWidth <= 1200);

const handleResize = () => {
    isMobile.value = window.innerWidth <= 1200;
};

const truncateText = (text: string) => {
    const limit = isMobile.value ? 40 : 70;
    return text.length > limit ? text.slice(0, limit) + '...' : text;
};

onMounted(() => {
    window.addEventListener('resize', handleResize);
});

onUnmounted(() => {
    window.removeEventListener('resize', handleResize);
});
</script>

<style scoped>
.line-card-container {
    display: flex;
    justify-content: center;
    align-items: center;

    width: 100%;
    height: 100%;
    max-height: 75px;
    padding: 10 0px;
    margin-bottom: 15px;
    box-shadow: 0px 5px 10px 0px black;
    border-radius: 15px;
    border-left: 3px solid rgb(2, 100, 156);
    background-color: transparent;
}

ul {
    display: flex;
    justify-content: space-between;
    text-decoration: none;
    width: 100%;
    list-style: none;
    border-radius: 15px;
}

.line-card-container:hover {
    background-color: rgb(26, 26, 26);
    color: rgb(2, 100, 156);
    cursor: pointer;
    transition: 0.2s ease-out;
}

li {
    display: flex;
    justify-content: center;
    align-items: center;
    width: 33%;
    text-align: center;
    padding: 0 15px;
    font-size: 16px;
}

@media (max-width: 1201px) {
    li {
        font-size: 12px !important;
    }
}
</style>