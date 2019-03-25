import { Injectable } from '@angular/core';
import { User } from '../model/user.model';
import { of,Observable, BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../util/constants.util';


@Injectable({
  providedIn: 'root'
})

export class UserService {

  private user = new User();
  private userObs = new BehaviorSubject<User>(this.user);

  public obj = {  
      id: "4720",  
      name: "Rathrola Prem Kumar",  
      position: "Software Engineer"  
  } 

  constructor(private http: HttpClient)  {
    //this.userObs = of(this.user);
   }


  public setUser(user : User) : void
  {  
    this.userObs.next(user);
  }

  public getUser() : Observable<User>
  {
    return this.userObs.asObservable();
  }


  getAll() {
    //return this.http.get<User[]>(`${config.apiUrl}/users`);
  }

  getById(id: number) {
      //return this.http.get(Constants.baseUrl/users/` + id);
  }

  register(user: User) {
      return this.http.post(Constants.baseUrl + "/register", user);
  }

  update(user: User) {
      //return this.http.put(`${config.apiUrl}/users/` + user.id, user);
  }

  delete(id: number) {
      //return this.http.delete(`${config.apiUrl}/users/` + id);
  }


}
