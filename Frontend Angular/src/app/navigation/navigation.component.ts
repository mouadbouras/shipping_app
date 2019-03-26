import { Component, OnInit } from '@angular/core';
import { UserService } from '../services/user.service';
import { User } from '../model/user.model';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navigation',
  templateUrl: './navigation.component.html',
  styleUrls: ['./navigation.component.css']
})
export class NavigationComponent implements OnInit {
  
  public user : User;

  constructor(private userService: UserService,
              private router : Router 
    ) { }

  ngOnInit() {
    this.userService.getUser().subscribe(
      u => 
      {
        this.user = u
      }
      );    
    } 
      
  onSetStel(){
    var stel = new User();
    stel.Username = "Stel";
    stel.Id = 9;
    this.userService.setUser(stel);
  }
  onSetMouad(){
    var mouad = new User();
    mouad.Username = "Mouad";
    mouad.Id = 28;
    this.userService.setUser(mouad);
  }
    logout(){
      this.userService.setUser(new User());
      this.router.navigateByUrl('/');
    }

}
