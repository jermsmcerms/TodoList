<template>
  <h2>Add Item</h2>
  <form @submit.prevent="">
    <div class="container">
      <div class="row">
        <label class="col-lg-1">Title</label>
        <input class="col-lg-2" type="text" v-model="item.title"
               placeholder="title" required>
        <span v-if="checkMaxLength(item.title, titleMaxLength)">
          Max characters reached {{ titleMaxLength }}
        </span>     
      </div>
      <div class="row">
        <label class="col-lg-1">Note</label>
        <input class="col-lg-2" type="text" v-model="item.note"
               placeholder="note" :max="noteMaxLength"/>
        <span v-if="checkMaxLength(item.note, noteMaxLength)">
          Max characters reached {{ noteMaxLength }}
        </span>
      </div>
      <div class="row">
        <label class="col-lg-1">Due Date</label>
        <input class="col-lg-2" type="date" v-model="item.dueDate"/>
      </div>
      <div class="row">
        <label class="col-lg-1">Complete?&nbsp</label>
        <input class="col-lg-2" type="checkbox" v-model="item.isCompleted" />  
      </div>
      <div>
        <button class="btn btn-primary" @click="addItem()" >Add Item</button> 
      </div>
    </div>
  </form>
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
      titleMaxLength: 100,
      noteMaxLength : 500,
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
    checkMaxLength(str: String, maxLength: number) {
        if(str === undefined) {
            return false;
        }
        return str.length >= maxLength;
    },
  },
  mounted() {
    this.item = {} as TodoItem;
  },
});
</script>

