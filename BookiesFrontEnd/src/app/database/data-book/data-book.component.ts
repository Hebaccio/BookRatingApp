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
  url2: string = "https://i1.sndcdn.com/avatars-PkAmzSOLCdxklQgS-AokumA-t500x500.jpg";
  url3:string = "https://cdn.vectorstock.com/i/preview-1x/73/69/anonymous-male-profile-picture-emotion-avatar-vector-15887369.jpg";

  Picture:string="";
  Title:string="";
  Date:string="";
  Status:string="";
  PageCount:number | null = null;
  Description:string="";
  Rating:number=0;

  Picture2:string="";
  Name:string="";
  About:string="";
  Age:number | null = null;
  Picture3: string ="";
  PersonName:string="";
  Bio:string="";
  Birthday:string="";
  PersonWebsite:string="";

  constructor(private httpClient:HttpClient) {
  }

  onselectFile(input: HTMLInputElement) {
    if (input.value != '')
      this.url = input.value;
    else {
      this.url = "https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";
    }
  }
  onselectFile2(input: HTMLInputElement) {
    if (input.value != '')
      this.url2 = input.value;
    else {
      this.url2 = "https://i1.sndcdn.com/avatars-PkAmzSOLCdxklQgS-AokumA-t500x500.jpg";
    }
  }
  onselectFile3(input: HTMLInputElement) {
    if (input.value != '')
      this.url3 = input.value;
    else {
      this.url3 = "https://cdn.vectorstock.com/i/preview-1x/73/69/anonymous-male-profile-picture-emotion-avatar-vector-15887369.jpg";
    }
  }

  TransformDate1(){
    if (this.Date) {
      // Use the Date constructor to parse the string and create a Date object
      const dateObject = new Date(this.Date);
      return dateObject;
    }
    return null; // Handle the case when Date is not provided
  }
  TransformDate2(){
    if (this.Birthday) {
      // Use the Date constructor to parse the string and create a Date object
      const dateObject = new Date(this.Birthday);
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
      publishDate:this.TransformDate1(),
      pageCount:this.PageCount,
      rating:this.Rating
    }

    this.httpClient.post(environment.apiBaseUrl+"Book/AddBook", BookAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          alert(this.Name + "succesfully added to the database!");
          this.Title="";
          this.url="https://media.istockphoto.com/id/182732882/tr/foto%C4%9Fraf/book-cover.jpg?s=612x612&w=0&k=20&c=Y4JfJF_E2i2rO7sHdt4ZjKh_p3oNk05SSge8Sd5CTco=";
          this.Picture="";
          this.Description="";
          this.Status="";
          this.Date="";
          this.PageCount = null;
          this.Rating=0;
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });

  }
  AddCharacter() {
    let CharacterAddVM = {
      name:this.Name,
      picture:this.Picture2,
      about:this.About,
      age:this.Age !== null ? this.Age : null
    };

    this.httpClient.post(environment.apiBaseUrl+"Character/AddCharacter", CharacterAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          alert(this.Name + "succesfully added to the database!");
          this.Name = "";
          this.Picture2 = "";
          this.url2="https://i1.sndcdn.com/avatars-PkAmzSOLCdxklQgS-AokumA-t500x500.jpg";
          this.About = "";
          this.Age = null;
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  AddPerson() {
    let PersonAddVM = {
      name:this.PersonName,
      picture:this.Picture3 !== null ? this.Picture3 : null,
      bio:this.Bio,
      birthday:this.Birthday !== null ? this.TransformDate2() : null,
      website:this.PersonWebsite!== null ? this.PersonWebsite : null
    };

    this.httpClient.post(environment.apiBaseUrl+"Person/AddPerson", PersonAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          alert(this.PersonName + "succesfully added to the database!");
          this.PersonName = "";
          this.url3="https://cdn.vectorstock.com/i/preview-1x/73/69/anonymous-male-profile-picture-emotion-avatar-vector-15887369.jpg"
          this.Picture3 = "";
          this.Bio = "";
          this.Birthday = "";
          this.PersonWebsite="";
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });

  }
}
