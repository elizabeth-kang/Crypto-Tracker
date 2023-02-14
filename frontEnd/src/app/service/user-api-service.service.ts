import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import {environment } from "src/environments/environment"
import { User } from './user.service';

@Injectable({
  providedIn: 'root'
})
export class UserApiServiceService {


  constructor(private http: HttpClient) { }

  url : string = 'https://gamestonks.azurewebsites.net/';

  login(user : User) : Observable<User>{
    return this.http.post(this.url + 'login', user) as Observable<User>;
  }

  register(user : User) : Observable<User>{
    return this.http.post(this.url + 'register', user) as Observable<User>;
  }

  getUserByUserId(userId : number) : Observable<User[]> {
    return this.http.get(this.url + `user/id/${userId}`) as Observable<User[]>;
  }

  
}


