
import { Injectable , OnInit} from '@angular/core';
import { LocalStorageService } from 'angular-web-storage';
import { User } from './user.service';

@Injectable({
  providedIn: 'root'
})

export class AuthService {

  constructor(private local : LocalStorageService) { }

  public isAuthenticated() : boolean {
    if(this.local.get('currentUser')) return true;
    return false;
  }

  public getCurrentUser() : User {
    return this.local.get('currentUser');
  }

  public setCurrentUser(user : User) : void {
    if(!user) return;
    this.local.set('currentUser', user);
  }

  public clearCurrentUser() : void {
    this.local.remove('currentUser');
  }
}