import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup, Validators } from '@angular/forms';
import {map, startWith} from 'rxjs/operators';
import { Observable } from 'rxjs';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from 'src/app/shared/services/api/user.service';
import { SnackbarService } from 'src/app/shared/services/components/snackbar/snackbar.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  form: UntypedFormGroup;
  isRegister = false;

  constructor(private fb: UntypedFormBuilder, 
    private readonly routerService: Router, 
    private readonly userService: UserService,
    private readonly snackBarService: SnackbarService) { }

  ngOnInit(): void {
    this.form = this.fb.group({
      name: ['', [Validators.required]],
      password: ['', [Validators.required]],
    });

    this.isRegister = this.routerService.url == '/register';
  }

  onSubmit(){
    if(this.isRegister){
      this.userService.createUser(this.form.value.name, this.form.value.password).subscribe((message) => {
        this.snackBarService.openSuccessSnackBar("User created");
        this.routerService.navigateByUrl('/');
      }, 
      (error) => {
        this.snackBarService.openErrorSnackBar(error.error);
      });
      
    }
    else{
      this.userService.authenticate(this.form.value.name, this.form.value.password).subscribe((message) => {
        localStorage.setItem('token', message.token);
        this.routerService.navigateByUrl('/task');
      }, 
      (error) => {
        this.snackBarService.openErrorSnackBar(error.error);
      });
    }
  }

  invalidForm(){
    return this.form.invalid;
  }

}
