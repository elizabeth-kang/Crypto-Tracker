import { Component, OnInit } from '@angular/core';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-leaderboard',
  templateUrl: './leaderboard.component.html',
  styleUrls: ['./leaderboard.component.css']
})
export class LeaderboardComponent implements OnInit {

  constructor(private auth: AuthService) { }
  currentUser : any = null;
  email : string = '';
  getUser() {
    this.currentUser = this.auth.getCurrentUser();
    this.email =this.currentUser.email
  }

  ngOnInit(): void {
    this.getUser
  }

}
