import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, of, retry } from 'rxjs';

export interface Profile {
  ProfileId: number;
  UserIdFk: number;
  FirstName: string;
  LastName: string;
}

@Injectable({
  providedIn: 'root'
})
export class ProfileService {

  apiUrl = 'https://gamestonks.azurewebsites.net'

  constructor(private http: HttpClient) { }

  GetProfileByUserId(UserIdFk : number): Observable<Profile> {
    return this.http.get<Profile>(this.apiUrl+'/profile/user/' + UserIdFk) as Observable<Profile>;
  }
  GetProfileById(ProfileId : number): Observable<Profile[]> {
    return this.http.get<Profile[]>(this.apiUrl+'/profile/' + ProfileId) as Observable<Profile[]> ;
  }
  GetProfiles(): Observable<Profile[]> {
    return this.http.get<Profile[]>(this.apiUrl+'/profile') as Observable<Profile[]> ;
  }
  CreateProfile(profile : Profile): Observable<Profile> {
    return this.http.post<Profile>(this.apiUrl+'/create/profile', profile) as Observable<Profile>;
  }
  UpdateProfile(profile : Profile): Observable<Profile> {
    return this.http.put<Profile>(this.apiUrl+'/update/profile',profile) as Observable<Profile>;
  }
}
