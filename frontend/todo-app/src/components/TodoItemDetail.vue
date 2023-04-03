<template>
    <h2>Edit Todo</h2>
    <div class="container">
        <div v-if="currentItem.itemId" class="edit-form">
            <div class="row">
                <label class="col-lg-1">
                    Title
                </label>
                <input 
                    class="col-lg-2" 
                    type="text" 
                    :placeholder="currentItem.title"
                    v-model="currentItem.title" />
            </div>
            <div class="row">
                <label class="col-lg-1">Note</label>
                <input 
                    class="col-lg-2" 
                    type="text" 
                    :placeholder="currentItem.note"
                    v-model="currentItem.note">
            </div> 
            <div class="row">
                <label class="col-lg-1">Due Date</label>
                <input
                    class="col-lg-2" 
                    type="date"
                    v-bind:data-id="currentItem.id"
                    v-model="currentItem.dueDate">
            </div>
            <div class="row">
                <label class="col-lg-1">Complete</label>
                <input 
                    class="col-lg-2" 
                    type="checkbox" 
                    v-bind:id="currentItem.id" 
                    v-model="currentItem.isComplete" />
            </div>
        </div>
        <button @click="updateItem()">Update</button>
    </div>
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
