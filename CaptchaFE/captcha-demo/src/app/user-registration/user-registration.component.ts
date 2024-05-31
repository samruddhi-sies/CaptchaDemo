import { Component } from '@angular/core';
import { FormGroup,FormControl, Validators } from '@angular/forms';
import { UserRegistrationService } from '../user-registration.service';
import { HttpErrorResponse } from '@angular/common/http';
@Component({
  selector: 'app-user-registration',
  templateUrl: './user-registration.component.html',
  styleUrls: ['./user-registration.component.css']
})
export class UserRegistrationComponent {
  captchaResolved=false;
  captchaResponse=""
  registrationForm = new FormGroup({
    firstName: new FormControl('',Validators.required),
    lastName: new FormControl('',Validators.required),
    email:new FormControl('',Validators.required),
    password:new FormControl('',Validators.required)
  });
  constructor(private userService:UserRegistrationService){}

  onCaptchaResolved(captchaResponse:any): void {
    this.captchaResolved = !!captchaResponse;
    this.captchaResponse=captchaResponse;
  }

  registerUser(data:any) {
    const formData = {
      ...this.registrationForm.value,
      recaptchaToken: this.captchaResponse
    };
    
    this.userService.addStudent(formData).subscribe({
      next:(result)=>{
        alert("User Registered Successfully")
      },
      error:(errorResponse:HttpErrorResponse)=>{
        console.log(errorResponse)
      }
    })
  }

}
