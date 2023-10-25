import {Injectable} from "@angular/core";
import {environment} from "../../environments/environment";
import {HttpClient} from "@angular/common/http";
import {SocialMedia} from "./Models";

@Injectable({
  providedIn: 'root'
})

export class BookiesService{
  constructor(private httpClient:HttpClient) {}

  getAllSocialMedia(){
    return this.httpClient.get<SocialMedia[]>(environment.apiBaseUrl+ 'SocialMedia/GetAll');
  }
}
