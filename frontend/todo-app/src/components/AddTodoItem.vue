<template>
    <h2>Add Item</h2>
    <input 
        type="text" 
        v-model="item.title"
        placeholder="title"/>  
    <input 
        type="text" 
        v-model="item.note"
        placeholder="note"/><br />
    <input type="date" v-model="item.dueDate"/>
    <div>
        <label>Complete?&nbsp</label>
        <input type="checkbox" v-model="item.isCompleted" />  
    </div> 
    <div>
        <button @click="addItem()" >Add Item</button> 
    </div>
    <div>
        <p>{{ message }}</p>
    </div>
</template>

<script lang="ts">
import { defineComponent } from "vue";
import TodoItemDataServic from "@/services/TodoListDataService";
import TodoItem from "@/types/TodoItem";
import ResponseData from "@/types/ResponseData";

export default defineComponent ({
    name: "todoitem-list",
    data() {
        return {
            item: {} as TodoItem,
            message: "",
        };
    },
    methods: {
        addItem() {
            TodoItemDataServic.addItem(this.item)
                .then((resp: ResponseData) => {
                    this.message = "Todo item added!";
                })
                .catch((e: Error) => {
                    this.message = "Unable to add item";
                });
        },
    },
    mounted() {
        this.item = {} as TodoItem;
        this.message = "";
    },
});
</script>

