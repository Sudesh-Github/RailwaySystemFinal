import { Component, OnInit } from '@angular/core';
import { FormArray, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';

import { passenger } from 'src/app/Models/passenger.model';

import { SharedService } from 'src/app/shared.service';
import { FooterService } from 'src/app/SharedService/footer.service';
import { JQueryStyleEventEmitter } from 'rxjs/internal/observable/fromEvent';

declare var $: any;


$("#testButton").click(function() {
  $("#BuyerForm").clone().appendTo("#container");
});  

@Component({
  selector: 'app-add-passenger',
  templateUrl: './add-passenger.component.html',
  styleUrls: ['./add-passenger.component.css']
})
export class AddPassengerComponent implements OnInit {
  formValue!:FormGroup;
  submitted=false;
  userID!:any;
  get pName() {
    return this.formValue.get('pName');
  }
  get age() {
    return this.formValue.get('age');
  }
  get gender() {
    return this.formValue.get('gender');
  }
  get class() {
    return this.formValue.get('class');
  }
  constructor(private fs:FooterService,private shared:SharedService,private fb:FormBuilder,private router:Router) { }

  ngOnInit(): void {
    this.fs.show();
    this.formValue=this.fb.group({
      pName:['',Validators.required] ,
      age:['',Validators.required],
      gender:[''],
      class:['']
    });
    
    
   
  }

  quantities() : FormArray {  
    return this.formValue.get("pName") as FormArray  
  }  
     
  newQuantity(): FormGroup {  
    return this.fb.group({  
      pName : '',
      age :'',
      gender : '',
      class:''

    })  
  }  
  
      
  addQuantity() {  
    this.quantities().push(this.newQuantity());  
  }  


  pModel:passenger = new passenger(); 
  pData!:any;
  passengers:string;
  addPassenger(){
   
    this.submitted=false;
    let user:any=localStorage.getItem("userId");
    this.userID=JSON.parse(user);
    this.pModel.userId=this.userID;
    this.pModel.pName=this.formValue.value.pName;
    this.pModel.age=this.formValue.value.age;
    this.pModel.gender=this.formValue.value.gender;
    this.pModel.class=this.formValue.value.class;
    this.shared.addPassenger(this.pModel).subscribe((res)=>{
      console.log(res);
      
      localStorage.setItem("passengers",JSON.stringify(res));
      var json=localStorage.getItem("passengers")as string;
     var storeData= JSON.parse(json);
      console.log(storeData.PName);
      this.router.navigateByUrl('/login/user/dashboard/booking');
      
    })
   
     
     
  }

  
  
}

