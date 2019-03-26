import { Injectable } from '@angular/core';
import { User } from '../model/user.model';
import { BehaviorSubject, Observable, Subscriber, Subject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../util/constants.util';


@Injectable({
  providedIn: 'root'
})

export class UserService {
    private subject = new Subject<User>();
    constructor(private http: HttpClient)  {
        
     }

     getUser() {
         return this.subject.asObservable();
     }

     setUser(user: User) {
         this.subject.next(user);
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
