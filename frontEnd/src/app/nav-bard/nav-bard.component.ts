import { Component} from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav-bard',
  templateUrl: './nav-bard.component.html',
  styleUrls: ['./nav-bard.component.css']
})
export class NavBardComponent {

  constructor(public router: Router) { }

}
