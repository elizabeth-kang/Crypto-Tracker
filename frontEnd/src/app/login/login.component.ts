import { Component, OnInit } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';
import { User } from '../service/user.service'; 
import { Router } from '@angular/router';
import { UserApiServiceService } from '../service/user-api-service.service';
import { AuthService } from '../service/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  constructor(private auth: AuthService, private router : Router, private api : UserApiServiceService) { }
 
  email : FormControl = new FormControl('');
  password : FormControl = new FormControl('');

  
  mode : string = 'login';
  modes : any = {
    login: 'Log In',
    register: 'Register'
  }

  loginFailed : boolean = false;
  registerFailed : boolean = false;
  errorMsg : string = ''
  loginHandler : Function = () => {
    this.email.markAsTouched();
    if(this.email.invalid) {
      return;
    }
    let User : User = {
      userId: 0,
      email: this.email.value,
      password: this.password.value,
    };
    if(this.mode == 'login') {
      this.api.login(User).subscribe((res) => {
        if(!res) {
          this.loginFailed = true;
        }
        this.auth.setCurrentUser(res as User);
        this.router.navigateByUrl('/main');
      })
    }
    else {
      this.api.register(User).subscribe({next: (res) => {
        this.auth.setCurrentUser(res as User);
        this.router.navigateByUrl('/main');
      }, error: (err) => {
        if(err.status === 409) {
          this.registerFailed = true;
          this.errorMsg = err.error;
        }
      }})
    }
  }

  switchMode(mode : string) : void {
    this.mode = mode;
    this.password.reset();
    this.loginFailed = false;
    this.registerFailed = false;
  }

  ngOnInit(): void {
    //Skip login page if the user is already logged in
    if(this.auth.isAuthenticated())
    {
      this.router.navigate(['main']);
    }

    // /more typical way of using observable
    // this.username.valueChanges.subscribe((valuechanged) => {
    //   console.log(valuechanged);
    // })
  }
}