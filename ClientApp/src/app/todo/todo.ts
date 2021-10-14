import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { summaryFileName } from '@angular/compiler/src/aot/util';

@Component({
  selector: 'to-do-data',
  templateUrl: './todo.component.html'
})
export class ToDoComponent {
  public todos: ToDo[];

  private httpClient: HttpClient;
  @Inject('BASE_URL') baseUrlLink: string;

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.httpClient = http;
    this.baseUrlLink = baseUrl;

    http.get<ToDo[]>(baseUrl + 'todo').subscribe(result => {
      this.todos = result;
    }, error => console.error(error));
  }

  public addToDo() {
    let todo = { task : 'sdr', cost : 1.4, summary : 'sdsds'};
    this.httpClient.post<any>(this.baseUrlLink + 'todo', todo).subscribe(data => {
      this.todos = data;
    })

  
  }
}

interface ToDo {
  task: string;
  cost: number;
  summary: string;
}
