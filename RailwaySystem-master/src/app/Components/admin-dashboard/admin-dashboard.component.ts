import { Component, OnInit } from '@angular/core';
import { FooterService } from 'src/app/SharedService/footer.service';
import { NavbarService } from 'src/app/SharedService/navbar.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css']
})
export class AdminDashboardComponent implements OnInit {

  constructor(private nav:NavbarService,private fs:FooterService) { }

  ngOnInit(): void {
    this.nav.hide();
    this.fs.show();   
    this.fs.doSomethingElseUseful();
  }

}
