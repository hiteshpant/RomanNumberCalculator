import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-counter-component',
  templateUrl: './counter.component.html'
})
export class CounterComponent {
  public currentCount = 0;
  public totalSum = 0;


  public incrementCounter() {
    this.currentCount++;
  }

  public calculate(input1: string, input2: string) {
    http.post<string>('https://reqres.in/api/posts', { title: 'Angular POST Request Example' }).subscribe(result => {
      this.totalSum = result;
    }, error => console.error(error));
}
