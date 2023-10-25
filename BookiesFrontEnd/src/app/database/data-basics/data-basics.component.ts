import { Component, OnInit } from '@angular/core';
import { BookiesService } from "../../Service/Bookies.Service";
import { SocialMedia } from "../../Service/Models";
import { Genre } from "../../Service/Models";
import { Tag } from "../../Service/Models";
import { Role } from "../../Service/Models";
import { Relation } from "../../Service/Models";
import { HttpClient } from "@angular/common/http";
import {environment} from "../../../environments/environment";

@Component({
  selector: 'app-data-basics',
  templateUrl: './data-basics.component.html',
  styleUrls: ['./data-basics.component.css']
})

export class DataBasicsComponent implements OnInit{
  socialMedia!:SocialMedia[];
  genre!:Genre[];
  tag!:Tag[];
  role!:Role[];
  relation!:Relation[];


  constructor(private bookiesService:BookiesService, private httpClient:HttpClient){}
  ngOnInit(): void {
      this.getSocialMedia();
      this.getGenre();
      this.getTag();
      this.getRoles();
      this.getRelations();
  }

  SocialMediaName:string="";
  Picture:string = "";
  GenreName:string = "";
  GenreDescription:string = "";
  TagName:string = "";
  TagDescription:string = "";
  RoleName:string="";
  RoleOrder!:number | null;
  RelationName:string="";
  RelationOrder!:number | null;

  url : string = "https://www.freeiconspng.com/thumbs/no-image-icon/no-image-icon-6.png";
  onselectFile(input: HTMLInputElement) {
    if (input.value != '')
      this.url = input.value;
    else {
      this.url = "https://www.freeiconspng.com/thumbs/no-image-icon/no-image-icon-6.png";
    }
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
  AddSocialMedia() {

    let SocialMediaAddVM = {
      socialMediaName:this.SocialMediaName,
      picture:this.Picture
    };

    this.httpClient.post(environment.apiBaseUrl+"SocialMedia/Add", SocialMediaAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getSocialMedia();
          this.SocialMediaName="";
          this.Picture="";
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  UpdateSocialMedia(sm: SocialMedia) {

    this.httpClient.post(environment.apiBaseUrl+"SocialMedia/Update", sm, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getSocialMedia();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  RemoveSocialMedia(id: number) {
    this.httpClient.delete(environment.apiBaseUrl+"SocialMedia/Delete/"+id, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getSocialMedia();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }

  getGenre() {
    fetch(environment.apiBaseUrl+"Genre/GetAllGenre")
      .then(r=>{
          if(r.status!==200){
            alert("Greska"+r.status); return;
          }
          r.json().then(x=>{
            this.genre=x;
          });
        }
      )
      .catch(err=>{
          alert('Greska'+err);
        }
      )
  }
  AddGenre() {
    let GenreAddVM = {
      name:this.GenreName,
      description:this.GenreDescription
    };

    this.httpClient.post(environment.apiBaseUrl+"Genre/AddGenre", GenreAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getGenre();
          this.GenreName="";
          this.GenreDescription="";
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  UpdateGenre(g: Genre) {

    let UpdateGenreVM = {
      id:g.genreID,
      name:g.genreName,
      description:g.genreDescription
    };

    this.httpClient.post(environment.apiBaseUrl+"Genre/Update", UpdateGenreVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getGenre();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  RemoveGenre(genreID: number) {
    this.httpClient.delete(environment.apiBaseUrl+"Genre/Delete/"+genreID, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getGenre();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }

  getTag() {
    fetch(environment.apiBaseUrl+"Tag/GetAllTags")
      .then(r=>{
          if(r.status!==200){
            alert("Greska"+r.status); return;
          }
          r.json().then(x=>{
            this.tag=x;
          });
        }
      )
      .catch(err=>{
          alert('Greska'+err);
        }
      )
  }
  AddTag() {
    let TagAddVM = {
      name:this.TagName,
      description:this.TagDescription
    };

    this.httpClient.post(environment.apiBaseUrl+"Tag/AddTag", TagAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getTag();
          this.TagName="";
          this.TagDescription="";
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  UpdateTag(t: Tag) {

    let UpdateTagVM ={
      id:t.tagID,
      name:t.tagName,
      description:t.tagDescription
    }

    this.httpClient.post(environment.apiBaseUrl+"Tag/Update", UpdateTagVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getTag();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  RemoveTag(tagID: number) {
    this.httpClient.delete(environment.apiBaseUrl+"Tag/Delete/"+tagID, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getTag();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }

  getRoles(){
    fetch(environment.apiBaseUrl+"Roles/GetAllRoles")
      .then(r=>{
          if(r.status!==200){
            alert("Greska"+r.status); return;
          }
          r.json().then(x=>{
            this.role=x;
          });
        }
      )
      .catch(err=>{
          alert('Greska'+err);
        }
      )
  }
  AddRole() {

    let RoleAddVM = {
      roleName:this.RoleName,
      order:this.RoleOrder
    }

    this.httpClient.post(environment.apiBaseUrl+"Roles/Add", RoleAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRoles();
          this.RoleName="";
          this.RoleOrder=null;
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });

  }
  UpdateRole(r: Role) {
    this.httpClient.post(environment.apiBaseUrl+"Roles/Update", r, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRoles();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  RemoveRole(roleID: number) {
    this.httpClient.delete(environment.apiBaseUrl+"Roles/Delete/"+roleID, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRoles();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }

  getRelations(){
    fetch(environment.apiBaseUrl+"Relation/GetAllRelations")
      .then(r=>{
          if(r.status!==200){
            alert("Greska"+r.status); return;
          }
          r.json().then(x=>{
            this.relation=x;
          });
        }
      )
      .catch(err=>{
          alert('Greska'+err);
        }
      )
  }
  AddRelation() {
    let RelationAddVM = {
      relationName:this.RelationName,
      relationOrder:this.RelationOrder
    }

    this.httpClient.post(environment.apiBaseUrl+"Relation/Add", RelationAddVM, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRelations();
          this.RelationName="";
          this.RelationOrder=null;
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  UpdateRelation(r: Relation) {
    this.httpClient.post(environment.apiBaseUrl+"Relation/Update", r, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRelations();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
  RemoveRelation(relationID: number) {
    this.httpClient.delete(environment.apiBaseUrl+"Relation/Delete/"+relationID, {observe:'response'}).subscribe({
      next:response=>{
        if (response.status===200){
          this.getRelations();
        }
      }, error:(error)=>{
        if (error.status===400){
          return error.response;
        }
      }
    });
  }
}
