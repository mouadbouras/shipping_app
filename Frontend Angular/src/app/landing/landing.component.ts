import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../model/user.model';

@Component({
  selector: 'app-landing',
  templateUrl: './landing.component.html',
  styleUrls: ['./landing.component.css']
})
export class LandingComponent implements OnInit {
  
  public user : User;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUser().subscribe
    (
      u => 
      {
        this.user = u
      });

  }

}
