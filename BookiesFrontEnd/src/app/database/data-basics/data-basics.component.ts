import { Component, OnInit } from '@angular/core';
import { BookiesService } from "../../services/bookies.service";
import {SocialMedia} from "../../models/social media model";
import { HttpClient } from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-data-basics',
  templateUrl: './data-basics.component.html',
  styleUrls: ['./data-basics.component.css']
})

export class DataBasicsComponent implements OnInit{
  socialMedia!:SocialMedia[];

  constructor(private bookiesService:BookiesService, private httpClient:HttpClient){}
  ngOnInit(): void {
      this.getSocialMedia();
  }
  SocialMediaName:string="";
  Picture:string = "";

  AddSocialMedia() {

    let SocialMediaAddVM = {
      SocialMediaName:this.SocialMediaName,
      Picture:this.Picture
    };

    this.httpClient.post(environment.apiBaseUrl+"SocialMedia/Add", SocialMediaAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){}
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }

  getSocialMedia() {
    fetch(environment.apiBaseUrl+"SocialMedia/GetAll")
      .then(r=>{
        if(r.status!==200){
          alert("Greska"+r.status); return;
        }
        r.json().then(x=>{
          this.socialMedia=x;
        });
      }
      )
      .catch(err=>{
        alert('Greska'+err);
      }
      )
  }

  url : string = "https://www.freeiconspng.com/thumbs/no-image-icon/no-image-icon-6.png";

  onselectFile(input: HTMLInputElement) {
    if (input.value != '')
      this.url = input.value;
    else {
      this.url = "https://www.freeiconspng.com/thumbs/no-image-icon/no-image-icon-6.png";
    }
  }
}
