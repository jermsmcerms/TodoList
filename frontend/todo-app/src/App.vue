<template>
  <div id="app">
    <nav class="navbar navbar-expand navbar-dark bg-dark">
      <router-link to="/" class="navbar-brand">Todo Items</router-link>            
      <router-link to="/add" class="navbar-brand">Create</router-link>
    </nav>
    <div class="container mt-3">
      <router-view />
    </div>
  </div>
</template>

<script lang="ts">
  import { defineComponent } from "vue";
import TodoListDataService from "@/services/TodoListDataService";

export default defineComponent({
    name: "App",
});
</script>

