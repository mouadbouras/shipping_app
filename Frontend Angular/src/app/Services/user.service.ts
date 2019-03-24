import { Injectable } from '@angular/core';
import { User } from '../model/user.model';
import { BehaviorSubject } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Constants } from '../util/constants.util';


@Injectable({
  providedIn: 'root'
})

export class UserService {

  constructor(private http: HttpClient)  { }

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
