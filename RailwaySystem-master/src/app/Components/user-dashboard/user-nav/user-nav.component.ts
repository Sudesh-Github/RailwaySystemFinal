import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { SharedService } from 'src/app/shared.service';

@Component({
  selector: 'app-user-nav',
  templateUrl: './user-nav.component.html',
  styleUrls: ['./user-nav.component.css']
})
export class UserNavComponent implements OnInit {
  userDetails!:any;
  constructor(private router:Router,private shared:SharedService) { }

  ngOnInit(): void {
    this.shared.getUserProfile().subscribe(
      res=>{
       this.userDetails=res;
       console.log(this.userDetails);
      },
      err =>{
       console.log(err);
      },
    );
  }


  onLogout() {
    localStorage.clear();
    this.router.navigate(['/home']);
  }

}
