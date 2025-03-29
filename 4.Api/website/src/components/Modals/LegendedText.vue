<template>
    <div class="container">
        <span>{{ props.title }}</span>
        <p>{{ props.description }}</p>
    </div>
</template>

<script setup lang="ts">

const props = defineProps<{
    title: string;
    description: string | undefined | Date | number;
}>();
</script>

<style scoped>
.container {
    display: inline-flex;
    gap: 5px;
}

.container>span {
    font-weight: bold;
}
</style>