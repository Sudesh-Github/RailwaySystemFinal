import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControlName, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { Train } from 'src/app/Models/train.model';
import { SharedService } from 'src/app/shared.service';
import { FooterService } from 'src/app/SharedService/footer.service';
import { NavbarService } from 'src/app/SharedService/navbar.service';

@Component({
  selector: 'app-trains',
  templateUrl: './trains.component.html',
  styleUrls: ['./trains.component.css']
})
export class TrainsComponent implements OnInit {
formValue!:FormGroup;
trainModelObj:Train=new Train()
trainData!:any;
seatData!:any;
  constructor(private fb:FormBuilder,private shared:SharedService,private nav:NavbarService,private fs:FooterService,private router:Router) { }

  ngOnInit(): void {
   
    this.nav.hide();
    this.nav.doSomethingElseUseful();
    this.fs.show();
    this.fs.doSomethingElseUseful();
    this.formValue=this.fb.group({
      ArrivalStation:[''],
      DepartureStation:[''],
      Date: ['']
    })
  }
SearchTrain(){
// // this.trainModelObj.arrivalStation=this.formValue.value.ArrivalStation;
// // this.trainModelObj.departureStation=this.formValue.value.DepartureStation;
// // this.trainModelObj.arrivalDate=this.formValue.value.Date;
this.shared.SearchTrain(this.formValue.value.ArrivalStation,this.formValue.value.DepartureStation,this.formValue.value.Date).subscribe(res=>{
 
 
  console.log(res);
    this.trainData = res;
    this.seatData=res;
    if(res==null || Object.keys(res).length===0){
      alert("No Train Found");
    }
    this.formValue.reset();
   
 
},error=>{
  alert("No Train Found");
});
}

GetTrainById(id:number){
this.trainModelObj.trainId=id;
this.shared.getTrainbyId(id).subscribe((res)=>{
  console.log(res);
  localStorage.setItem('trainId',JSON.stringify(res));
  this.router.navigateByUrl('/login/user/dashboard/add-passenger');
})
}

}