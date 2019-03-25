import { Injectable } from '@angular/core';

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Constants } from '../util/constants.util';
import { User } from '../model/user.model';
import { UserService } from '../services/user.service';



@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor(private http: HttpClient)
  { 
  }

  login(username: string, password: string) {
        // console.log({ Username: username, Password: password });

        return this.http.post<any>(Constants.baseUrl + "/auth/credentials.json", { UserName: username, Password: password },{withCredentials: true})
          .pipe(map(user => {
              // login successful if there's a jwt token in the response
              // if (user) {
              //     // store user details and jwt token in local storage to keep user logged in between page refreshes
              //     //localStorage.setItem('currentUser', JSON.stringify(user));
              // }                               
              return user;
        }));
  }

  logout() {
      // remove user from local storage to log user out
      //localStorage.removeItem('currentUser');
      //this.userServcie.setUser(null);
  }
}
