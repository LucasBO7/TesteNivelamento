<template>
    <div class="line-card-container" v-for="(item, index) in cards" :key="index">
        <ul>
            <li>{{ item.nomeFantasia }}</li>
            <li>{{ item.razaoSocial }}</li>
            <li>{{ item.cnpj }}</li>
        </ul>
    </div>
</template>

<script setup lang="ts">
interface Card {
    nomeFantasia: string;
    razaoSocial: string;
    cnpj: string;
}

defineProps<{
    cards: Card[];
}>();
</script>

<style scoped>
.line-card-container {
    display: flex;
    justify-content: center;
    align-items: center;

    width: 100%;
    height: 55px;
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
    height: 100%;
    list-style: none;
    border-radius: 15px;
}

ul:hover {
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
}
</style>