<template>
    <vue-final-modal v-model="localIsModalOpen" content-class="modal-content">
        <div class="modal-container">
            <button class="modal__close" @click="localIsModalOpen = false">
                X
            </button>
            <span class="modal__title">{{ props.selectedCardData && props.selectedCardData.nomeFantasia }}</span>
            <div class="modal-content">
                <h3 class="modal-content-title">REGISTRO</h3>
                <LegendedText title="Registro ANS: " :description=props.selectedCardData?.registroANS />
                <LegendedText title="Data de Registro ANS: " :description=props.selectedCardData?.dataRegistroANS />

                <h3 class="modal-content-title">SOBRE</h3>
                <LegendedText title="Razão Social: " :description=props.selectedCardData?.razaoSocial />
                <LegendedText title="CNPJ: " :description=props.selectedCardData?.cnpj />
                <LegendedText title="Nome Fantasia: " :description=props.selectedCardData?.nomeFantasia />
                <LegendedText title="Modalidade: " :description=props.selectedCardData?.modalidade />

                <h3 class="modal-content-title">ENDEREÇO</h3>
                <LegendedText title="Logradouro: " :description=props.selectedCardData?.logradouro />
                <LegendedText title="Número: " :description=props.selectedCardData?.numero />
                <LegendedText title="Complemento: " :description=props.selectedCardData?.complemento />
                <LegendedText title="Bairro: " :description=props.selectedCardData?.bairro />
                <LegendedText title="Cidade: " :description=props.selectedCardData?.cidade />
                <LegendedText title="UF: " :description=props.selectedCardData?.uf />
                <LegendedText title="CEP: " :description=props.selectedCardData?.cep />

                <h3 class="modal-content-title">SOBRE</h3>
                <LegendedText title="DDD: " :description=props.selectedCardData?.ddd />
                <LegendedText title="Telefone: " :description=props.selectedCardData?.telefone />
                <LegendedText title="Fax: " :description=props.selectedCardData?.fax />
                <LegendedText title="Endereço eletrônico: " :description=props.selectedCardData?.enderecoEletronico />

                <h3 class="modal-content-title">OUTROS</h3>
                <LegendedText title="Representante: " :description=props.selectedCardData?.representante />
                <LegendedText title="Cargo do representante: "
                    :description=props.selectedCardData?.cargoRepresentante />
                <LegendedText title="Número da região de comercialização: "
                    :description=props.selectedCardData?.regiaoComercializacao />
            </div>
        </div>
    </vue-final-modal>
</template>

<script lang="ts" setup>
import { ref, watch } from 'vue';
import { VueFinalModal } from 'vue-final-modal';
import LegendedText from './LegendedText.vue';

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
    isModalOpen: boolean;
    selectedCardData: Card | undefined;
}>();

const localIsModalOpen = ref(props.isModalOpen);

const emit = defineEmits<{
    (event: 'update:isModalOpen', value: boolean): void;
}>();

// Observa mudanças na prop e atualiza o estado local
watch(() => props.isModalOpen, (newVal) => {
    localIsModalOpen.value = newVal;
});

// Emite as mudanças de estado para o componente pai
watch(localIsModalOpen, (newVal) => {
    emit('update:isModalOpen', newVal);
});
</script>

<style scoped>
.modal-content-title {
    margin: 10px 0 5px 0;
    font-weight: bold;
    text-decoration: underline;
}

.modal-container {
    position: fixed;
    display: flex;
    justify-content: center;
    align-items: center;
    flex-direction: column;
    position: fixed;
    top: 0;
    left: 0;
    width: 100%;
    height: 100%;
    padding: 50px 0px;
    background-color: rgba(0, 0, 0, 0.589);
    background-image: blur(10px);
    z-index: 999;
}

.modal-content {
    display: flex;
    flex-direction: column;
    margin: 0 1rem;
    padding: 1.5rem;
    border-radius: 15px;
    background-color: rgb(29, 29, 29);
    max-width: 90%;
    max-height: 90vh;
    overflow-y: auto;
    /* Permite rolagem se o conteúdo for muito grande */
    position: relative;
    /* Para posicionar o botão de fechar corretamente */
    z-index: 1000;
}

.modal__title {
    font-size: 1.5rem;
    font-weight: 700;
    margin-bottom: 1rem;
}

.modal__close {
    position: absolute;
    top: 30px;
    right: 30px;
    background: transparent;
    color: rgb(2, 100, 156);
    border: none;
    cursor: pointer;
    font-size: 1.25rem;
    z-index: 1001;
}

.modal__content {
    display: flex;
    flex-direction: column;
    gap: 0.75rem;
    /* Espaçamento entre os itens de LegendedText */
}


.close-btn {
    position: absolute;
    top: 10px;
    right: 10px;
    background: none;
    border: none;
    font-size: 18px;
    cursor: pointer;
}
</style>