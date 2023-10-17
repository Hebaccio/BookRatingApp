import { Component } from '@angular/core';

@Component({
  selector: 'app-data-book',
  templateUrl: './data-book.component.html',
  styleUrls: ['./data-book.component.css']
})
export class DataBookComponent {

  URL: string = "https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";

  onselectFile(input: HTMLInputElement) {
    if (input.value != '')
      this.URL = input.value;
    else {
      this.URL = "https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";
    }
  }
}
