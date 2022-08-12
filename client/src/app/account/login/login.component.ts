import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, FormGroupName, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { validate } from 'uuid';
import { AccountService } from '../account.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  loginForm : FormGroup;
  returnUrl : string;

  constructor(private accountService : AccountService,private router: Router,private activatedRoute:ActivatedRoute) { }

  ngOnInit(){
    this.returnUrl = this.activatedRoute.snapshot.queryParams.returnUrl || '/shop';
    this.createLoginform();
  }

  createLoginform(){
    this.loginForm = new FormGroup({
      email : new FormControl('' ,[Validators.required,Validators.pattern('^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$')]),
      password: new FormControl('',Validators.required)
    });
  }

  onSubmit(){
    this.accountService.login(this.loginForm.value).subscribe(() => {
      this.router.navigateByUrl(this.returnUrl)
    },
    error => {
      console.log(error);
    });
  }

}
