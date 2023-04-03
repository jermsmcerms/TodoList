<template>
    <h2>Add Item</h2>
    <div class="container">
        <div class="row">
            <label class="col-lg-1">Title</label>
            <input 
            class="col-lg-2" 
            type="text" 
            v-model="item.title"
            placeholder="title"/>
        </div>
        <div class="row">
            <label class="col-lg-1">Note</label>
            <input
            class="col-lg-2"
            type="text" 
            v-model="item.note"
            placeholder="note"/><br />
        </div>
        <div class="row">
            <label class="col-lg-1">Due Date</label>
            <input class="col-lg-2" type="date" v-model="item.dueDate"/>
        </div>
        <div class="row">
            <label class="col-lg-1">Complete?&nbsp</label>
            <input 
                class="col-lg-2" 
                type="checkbox" 
                v-model="item.isCompleted" />  
        </div> 
        <div>
            <button 
                class="btn btn-primary" 
                @click="addItem()" >Add Item</button> 
        </div>
        <div>
            <p>{{ message }}</p>
        </div>
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

