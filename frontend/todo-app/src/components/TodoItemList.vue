<template>
  <div class="col-md-12">
    <h4>TodoItems List</h4>
    <table class="table">
      <thead>
        <tr scope="row">
          <th scope="col">Title</th>
          <th scope="col">Note</th>
          <th scope="col">Is Complete</th>
          <th scope="col">Due Date</th>
        </tr>
      </thead>
      <tbody 
        :class="{ active: index == currentIndex }"
        v-for="(item, index) in items"
        :key="index">
        <tr> 
          <th scope="col">{{ item.title }}</th>
          <th scope="col">{{ item.note }}</th>
          <th scope="col">{{ item.isComplete }}</th>
          <th scope="col">{{ item.dueDate }}</th>
          <th scope="col">
            <router-link :to="'TodoItem/' + item.itemId"
              class="btn btn-primary">
              Edit
            </router-link>                            
            <button @click="removeItem(item)"
              class="btn btn-danger">Delete</button>
          </th>
        </tr>
      </tbody> 
    </table>
  </div>
</template>

<script lang="ts">
  import { defineComponent } from "vue";
import TodoItemDataService from "@/services/TodoListDataService";
import TodoItem from "@/types/TodoItem";
import ResponseData from "@/types/ResponseData";

export default defineComponent({
  name: "todoitem-list",
  data() {
    return {
      items: [] as TodoItem[],
      currentIndex: -1,
      title: "",
    };
  },
  methods: {     
    retrieveItems() {
      TodoItemDataService.getAll()
        .then((response: ResponseData) => {
          this.items = response.data;
        })
        .catch((e: Error) => {
          console.log(e);
        });
      },
      removeItem(item: TodoItem) {
        TodoItemDataService.delete(item.itemId)
          .then((response: ResponseData) => {
            this.items = this.items.filter((t) => t !== item);
          })
          .catch((e: Error) => {
            console.log(e);
          });
      },
  },
  mounted() {
    this.retrieveItems();
  },
});
</script>

