import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { AuthService } from '../service/auth.service';
@Component({
  selector: 'app-dash-board',
  templateUrl: './dash-board.component.html',
  styleUrls: ['./dash-board.component.css']
})
export class DashBoardComponent{

  constructor(private auth: AuthService, private router:Router) { }

  logout() {
    this.auth.clearCurrentUser();
    this.router.navigate(['login']);
  }

  content : string = 'CryptoCurrency';
  switchContent(content: string) : void {
    this.content = content;
  }
}
