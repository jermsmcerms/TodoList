<template>
    <div id="app">
        <h1>List</h1>
    </div>
    <ul>
        <li v-for="item of items" :key="item.itemId">
            {{ item.title }}
        </li>
    </ul>
</template>

<script lang="ts">
import axios from 'axios'
export default {
    name: "App",
    data() {
        return {
            items: [],
        };
    },
    async created() {
        try {
            const res = await axios.get(`http://localhost:5023/TodoItem`);
            this.items = res.data;
            console.log(this.items);
        } catch (error) {
            console.log(error);
        }
    },
};
</script>
