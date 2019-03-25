import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { map } from 'rxjs/operators';
import { Constants } from '../util/constants.util';
import { JsonServiceClient } from '@servicestack/client';

@Injectable({
  providedIn: 'root'
})
export class ServicestackAuthService {

  constructor(private http: HttpClient) {  }

  login(username: string, password: string) {

    var request = new JsonServiceClient(Constants.loginUrl);
    //request.provider = "credentials";
    request.userName = username;
    request.password = password;
    //request.rememberMe = true;

    //const response = await client.post(request);

   
}

logout() {
  // remove user from local storage to log user out
  //localStorage.removeItem('currentUser');
}


}



