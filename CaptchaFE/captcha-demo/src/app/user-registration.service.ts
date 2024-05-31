import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'
@Injectable({
  providedIn: 'root'
})
export class UserRegistrationService {
  url="https://localhost:7062/api/Home";
  constructor(private http:HttpClient) { }
  addStudent(data:any){
    return this.http.post(this.url,data)
  }
}
