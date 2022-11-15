import { Component, OnInit } from '@angular/core';
import { SharedService } from 'src/app/shared.service';
import { NavbarService } from 'src/app/SharedService/navbar.service';

var $:any;

let c = 45;

function draw(){   
  document.documentElement.style.setProperty('--direction', c++ + 'deg');
  requestAnimationFrame(draw);
}

requestAnimationFrame(draw);


@Component({
  selector: 'app-user-dashboard',
  templateUrl: './user-dashboard.component.html',
  styleUrls: ['./user-dashboard.component.css']
})




export class UserDashboardComponent implements OnInit {
  userDetails!:any;

  constructor(private nav:NavbarService,private shared:SharedService) { }

  ngOnInit(): void {
    this.nav.hide();
    this.shared.getUserProfile().subscribe(
      res=>{
       this.userDetails=res;
       console.log(this.userDetails);
       console.log(this.userDetails.UserId);
       localStorage.setItem('userId',JSON.stringify(this.userDetails.UserId));
      },
      err =>{
       console.log(err);
      },
    );
  }

}
