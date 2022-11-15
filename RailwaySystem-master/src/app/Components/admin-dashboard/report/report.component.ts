import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Report } from 'src/app/Models/Report.model';
import { SharedService } from 'src/app/shared.service';
import { FooterService } from 'src/app/SharedService/footer.service';
import { NavbarService } from 'src/app/SharedService/navbar.service';

@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
formValue!:FormGroup;
report:Report = new Report();
reportData:any;
  constructor(private fb:FormBuilder,private shared:SharedService,private nav:NavbarService,private fs:FooterService,private router:Router) { }

  ngOnInit(): void {
    this.nav.hide();
    this.nav.doSomethingElseUseful();
    this.fs.show();
    this.fs.doSomethingElseUseful();
    this.formValue=this.fb.group({
      TrainId:[''],
      
    })
  }
  SearchPassenger(){
    this.shared.report(this.formValue.value.TrainId).subscribe((res)=>{
      console.log(res);
      this.reportData=res;
      if(res==null || Object.keys(res).length===0){
        alert("No Report Found");
      }
      this.formValue.reset();
    })
  }

}
