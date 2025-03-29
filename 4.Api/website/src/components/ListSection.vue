<template>
    <div class="list-section">
        <p class="not-found-message" v-if="sortedCards.length === 0">Nenhum dado encontrado.</p>
        <ListCard v-else :cards="sortedCards" :open-modal="openModal" />

        <CardModal :is-modal-open="isModalOpen" @update:is-modal-open="isModalOpen = $event"
            :selected-card-data="selectedCardData" />
    </div>
</template>

<script setup lang="ts">
import { computed, ref } from 'vue';
import CardModal from './Modals/CardModal.vue';
import ListCard from './ListCard.vue';

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

const props = defineProps<{
    cardsData: Card[];
}>();

const isModalOpen = ref<boolean>(false);

const selectedCardData = ref<Card>();

const sortedCards = computed(() => {
    // Cria uma cópia para não modificar os props originais
    return [...props.cardsData].sort((a, b) => {
        const valorA = a.nomeFantasia;
        const valorB = b.nomeFantasia;

        if (valorA === "" && valorB !== "") return 1;
        if (valorA !== "" && valorB === "") return -1;
        return 0;
    });
});

const openModal = (cardData: Card) => {
    isModalOpen.value = true;
    selectedCardData.value = cardData;
}
</script>

<style scoped>
.list-section {
    width: 100%;
    height: 55vh;
    overflow-y: auto;
}

.not-found-message {
    text-align: center;
}
</style>