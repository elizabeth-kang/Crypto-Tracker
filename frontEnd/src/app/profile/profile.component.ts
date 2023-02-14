import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';
import { Profile, ProfileService } from '../profile.service';
import { DashBoardComponent } from '../dash-board/dash-board.component';
import { FormControl } from '@angular/forms';
import { FormBuilder } from '@angular/forms';
import { ApplicationConfig } from '@angular/platform-browser';
import { LocalStorageService } from 'angular-web-storage';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  constructor(private local: LocalStorageService,  private auth: AuthService,private api:ProfileService) {
   }
  

  currentUser: any = null;
  email: string = '';

  imageId: number = 2;
  images: string[] =["../../assets/person-outline.svg","../../assets/sid.png","../../assets/krisholl.png","../../assets/bunny.png","../../assets/bin.png","../../assets/cat.png","../../assets/doge.png","../../assets/hamster.png","../../assets/tigger.png","../../assets/turtle.png"];
  vis: boolean = false;

  changeImage() {
    let id: number = Number((<HTMLSelectElement>document.getElementById('imgId')).value);
    this.local.set('imgId', id);
    this.imageId = id;
    this.vis = false;
  }
  show() {
    this.vis = true;
  }
  getUser() {
    this.currentUser = this.auth.getCurrentUser();
    this.email =this.currentUser.email
    console.log(this.currentUser)
  }
  ngOnInit(): void {
    this.getUser();
  }

}
