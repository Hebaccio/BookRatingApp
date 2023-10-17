import { Component } from '@angular/core';
import {environment} from "../../../environments/environment";
import { HttpClient } from "@angular/common/http";

@Component({
  selector: 'app-data-book',
  templateUrl: './data-book.component.html',
  styleUrls: ['./data-book.component.css']
})
export class DataBookComponent {

  url: string = "https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";
  Picture:string="";
  Title:string="";
  Date:string="";
  Status:string="";
  PageCount:number | null = null;
  Description:string="";
  Rating:number=0;

  constructor(private httpClient:HttpClient) {
  }

  onselectFile(input: HTMLInputElement) {
    if (input.value != '')
      this.url = input.value;
    else {
      this.url = "https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";
    }
  }

  TransformDate(){
    if (this.Date) {
      // Use the Date constructor to parse the string and create a Date object
      const dateObject = new Date(this.Date);
      return dateObject;
    }
    return null; // Handle the case when Date is not provided
  }

  AddBook() {
    let BookAddVM = {
      title:this.Title,
      picture:this.Picture,
      description:this.Description,
      statusName:this.Status,
      publishDate:this.TransformDate(),
      pageCount:this.PageCount,
      rating:this.Rating
    }

    this.httpClient.post(environment.apiBaseUrl+"Book/AddBook", BookAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });

  }
}
