<template>
    <div v-if="currentItem.itemId" class="edit-form">
       <input 
            type="text" 
            :placeholder="currentItem.title"
            v-model="currentItem.title" />
       <input 
            type="text" 
            :placeholder="currentItem.note"
            v-model="currentItem.note">
       <input 
            type="checkbox" 
            v-bind:id="currentItem.id" 
            v-model="currentItem.isComplete" />
       <input
            type="date"
            v-bind:data-id="currentItem.id"
            v-model="currentItem.dueDate">
    </div>
    <button @click="updateItem()">Update</button>
</template>

<script lang="ts">
import { defineComponent } from "vue"
import TodoItemDataService from "@/services/TodoListDataService"
import TodoItem from "@/types/TodoItem"
import ResponseData from "@/types/ResponseData"

export default defineComponent({
    name: "todoitem-list",
    data() {
        return {
            currentItem: {} as TodoItem,
        };
    },
    methods: {
        getItem(id: number) {
            TodoItemDataService.get(id)
                .then((res: ResponseData) => {
                    this.currentItem = res.data;
                })
                .catch((e: Error) => {
                    console.log(e);
                });
        },
        updateItem() {
            console.log("updating date: " + this.currentItem.dueDate);
            TodoItemDataService.update(this.currentItem)
                .then((res: ResponseData) => {
                })
                .catch((e: Error) => {
                    console.log(e);
                });
        },
    },
    mounted() {
        var idStr = this.$route.params.id;
        var idNum: number = +idStr;
        this.getItem(idNum);
    },
});
</script>
