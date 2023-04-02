import http from "@/http-common";
import TodoItem from "@/types/TodoItem";

class TodoListDataService {
    addItem(item: TodoItem): Promise<any> {
        return http.post("/TodoItem", item);
    }

    getAll(): Promise<any> {
        return http.get("/TodoItem");
    }

    get(id: number): Promise<any> {
        return http.get(`/TodoItem/${id}`);
    }

    update(item: TodoItem): Promise<any> {
        return http.put(`/TodoItem/${item.id}`, item);
    }

    delete(id: number): Promise<any> {
        return http.delete(`/TodoItem/${id}`);
    }
}

export default new TodoListDataService();

