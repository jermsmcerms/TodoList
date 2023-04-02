import { createWebHistory, createRouter } from "vue-router";
import { RouteRecordRaw } from "vue-router";

const routes: Array<RouteRecordRaw> = [
    {
        path: "/",
        alias: "/TodoItem",
        name: "todo-item",
        component: () => import("./components/TodoItemList.vue"),
    },
    {
        path: "/TodoItem/:id",
        name: "todo-item-detail",
        component: () => import("./components/TodoItemDetail.vue"),
    },
    {
        path: "/add",
        name: "add",
        component: () => import("./components/AddTodoItem.vue"),
    },
];

const router = createRouter({
    history: createWebHistory(),
    routes,
});

export default router;

