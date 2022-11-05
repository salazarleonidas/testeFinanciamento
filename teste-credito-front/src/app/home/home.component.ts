import { Component, OnInit } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { User } from '../shared//models/user';
import { CookieService } from '../shared/helpers/cookie.service';
import { UserHttpService } from '../services/http/user.http-service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
  providers: [UserHttpService],
})
export class HomeComponent implements OnInit {
  userForm: FormGroup;
  model: User = new User; 
  submittedModel: User = new User; 
  submitted: boolean = false;
  cookieService: CookieService;
  
  constructor(private formBuilder: FormBuilder, 
              private httpService : UserHttpService) {
    this.cookieService = new CookieService;

    this.userForm = this.formBuilder.group({
      username: [this.model.Username, Validators.required],
      password: [this.model.Password, Validators.required]
    });
   }
  
  ngOnInit() {      
  }

  onSubmit({ value, valid }: { value: User, valid: boolean }) {
    this.httpService.login(value).subscribe({
      next: (response) => {
        console.log("Sucesso");
        console.log(response);
        this.submittedModel = response['user'];
        this.submitted = true;

        this.cookieService.setCookie('token', response['token'], 60);
      },
      error: (err) => {
        console.log("Erro");
        console.log(err);
      }
    });
  }

  logout(){
    this.submitted = false;
    this.cookieService.deleteCookie(this.submittedModel.Username);
  }
}